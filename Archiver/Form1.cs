using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;


namespace Archiver
{
    public partial class Form1 : Form
    {
        public List<string> PathList = new List<string>();//список путей к файлам
        public List<string> NameList = new List<string>();//список имен файлов
        public bool _switch = false;//определяет что добавлялось последним (файл или архив), чтобы
                                   //определить, очищать ли списки

        Archiver ar = new Archiver();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddFilesBtn_Click(object sender, EventArgs e)//добавляем файлы для сжатия
        {


            if (!_switch && PathList.Any())//если была нажата кнопка Доб. архив
                                          //и список не пустой
            {
                PathList.Clear();
                NameList.Clear();
            }

            listBoxFiles.Enabled = true;

            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "All files|*.*";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                PathList.AddRange(openFileDialog1.FileNames);
                PathList = PathList.Distinct().ToList();//удаляем повторы

                NameList.AddRange(openFileDialog1.SafeFileNames);
                NameList = NameList.Distinct().ToList();
            }

            listBoxFiles.Items.Clear();
            for (int i = 0; i < NameList.Count; i++)
            {
                listBoxFiles.Items.Add(NameList[i]);
            }
            _switch = true;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (NameList.Any())
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                if (_switch)
                {
                    saveFileDialog1.Filter = "Compressed file (*.compr)|*.compr";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        string FileName = saveFileDialog1.FileName;
                        ar.compression(PathList, FileName);
                        MessageBox.Show("Архивация завершена");
                    }
                }
                else
                {
                    saveFileDialog1.FileName = NameList[0].Substring(0, NameList[0].Length - 6);
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string FileName = saveFileDialog1.FileName;
                            ar.decompression(PathList[0], FileName);
                             MessageBox.Show("Разархивация завершена");
                        } 
                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DelFilesBtn_Click(object sender, EventArgs e)//удаляем выбранные файлы
        {
            if (listBoxFiles.SelectedItems.Count > 0)
            {
                var indices = listBoxFiles.SelectedIndices;
                List<int> TmpInd = new List<int>();      

                foreach (int index in indices)
                {
                    TmpInd.Add(index);
                }

                TmpInd.Reverse();

                for (int i = 0; i < TmpInd.Count; i++)
                {
                    NameList.RemoveAt(TmpInd[i]);
                    PathList.RemoveAt(TmpInd[i]);
                }
                TmpInd.Clear();

                listBoxFiles.Items.Clear();
                for (int i = 0; i < NameList.Count; i++)
                {
                    listBoxFiles.Items.Add(NameList[i]);
                }
            }
        }

        private void AddArchiveBtn_Click(object sender, EventArgs e)//выбираем архив для разархивации
        {
            if (PathList.Any())
            {
                PathList.Clear();
                NameList.Clear();
            }

            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Compressed files|*.compr";
            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                PathList.Add(openFileDialog1.FileName);
                PathList = PathList.Distinct().ToList();

                NameList.Add(openFileDialog1.SafeFileName);
                NameList = NameList.Distinct().ToList();
            }

            listBoxFiles.Items.Clear();

            if (NameList.Any())  listBoxFiles.Items.Add("Содержимое архива \"" + NameList[0]+ "\":");
            listBoxFiles.Enabled = false;

            if (NameList.Any())
            {
                string[] caption = ar.filis_in_archive(PathList[0]);
                for (int i = 0; i < caption.Count(); i++)
                    listBoxFiles.Items.Add(caption[i]);

            }
            _switch = false;
        }
    }

    public class Archiver
    {
        byte KEYBYTE = 255;

        public void compression(List<string> PathList, string destinationPath)
        {
            int[] arr_size = new int[PathList.Count];//массив размеров файлов после сжатия(для заголовка)

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("tmp")))//сжимаем файлы и записывем все во временный файл
            {
                int file_size = 0;

                for (int k = 0; k < PathList.Count; k++)
                {
                    byte[] bytes = File.ReadAllBytes(PathList[k]);
                                                                    //Алгоритм RLE
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        byte currentRow = 0;
                        byte firstChar = bytes[i];

                        for (int j = i; j < bytes.Length; j++)
                        {
                            if (bytes[j] == firstChar)
                                currentRow++;
                            else
                                break;
                            if (currentRow == 255) break;
                        }

                        if (currentRow > 3 || firstChar == KEYBYTE)
                        {
                            writer.Write(KEYBYTE);
                            writer.Write(currentRow);
                            writer.Write(firstChar);
                            file_size += 3;
                            i += currentRow - 1;
                        }
                        else
                        {
                            writer.Write(firstChar);
                            file_size++;
                        }
                    }
                    arr_size[k] = file_size;
                    file_size = 0;
                }
            }

            using (BinaryWriter writer2 = new BinaryWriter(File.OpenWrite(destinationPath)))//записываем заголовок в главынй файл
            {
                for (int i = 0; i < PathList.Count; i++)
                {
                    FileInfo fi1 = new FileInfo(PathList[i]);
                    byte[] str = Encoding.Default.GetBytes('|' + fi1.Name + '|' + arr_size[i]);//  "|имя файла|размер после сжатия"
                    for (int j = 0; j < str.Length; j++)
                        writer2.Write(str[j]);
                }

                writer2.Write('\n');// отделить заголовок

                byte[] bytes = File.ReadAllBytes("tmp");

                for (int i = 0; i < bytes.Length; i++)// из временного файла в главный
                    writer2.Write(bytes[i]);
            }
            File.Delete("tmp");
        }

        public void decompression(string ArchName, string destinationPath)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(ArchName)))
            {
                int num_files = 0;
                int caption_size = 0;
                byte[] bytes = File.ReadAllBytes(ArchName);//считали весь файл в массив

                for (int i = 0; i < bytes.Length; i++)//находим границу заголовка
                {
                    if (bytes[i] != '\n')
                    {
                        if (bytes[i] == '|') num_files++;
                        caption_size++;
                    }
                    else break;
                }
                num_files = num_files / 2;// количество файлов

                byte[] tmp = new byte[caption_size];//массив для заголовка

                for (int i = 0; i < caption_size; i++)//помещаем заголовок в новый массив для работы с ним
                {
                    tmp[i] = bytes[i];
                }

                string cap = Encoding.Default.GetString(tmp);// маасив с заголовком в строку

                string[] caption = cap.Split(new char[] { '|' });// в новом массиве отдельно содержатся имя файла и его размер

                Directory.CreateDirectory(destinationPath);//новая папка для разархивированный файлов

                caption_size += 1;// пропускаем символ '\n'

                for (int k = 0; k < num_files; k++)
                {
                    string desPath = destinationPath + "\\" + caption[k + 1 + k];//путь по которому будут создаваться разархивированные файлы

                    int fsize;// для хранения размеров файлов

                    Int32.TryParse(caption[k + 2 + k], out fsize);//преобразуем размер_файла(string) в размер_файла(int)

                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(desPath)))
                    {
                        for (int i = caption_size; i < caption_size + fsize; i++)
                        {
                            byte b = bytes[i];
                            if (b == KEYBYTE) // если закодирована очередная последовательность
                            {
                                int count = bytes[++i];
                                byte _b = bytes[++i];

                                for (int j = 0; j < count; j++)
                                    writer.Write(_b);
                            }
                            else
                            {
                                writer.Write(b);
                            }
                        }
                    }
                    caption_size += fsize;
                }
            }
        }

        public string[] filis_in_archive(string Archiv_name)
        {
            List<byte> bytes = new List<byte>();
            List<string> fnames = new List<string>();
            string[] fail = new string[1];
            byte temp;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Archiv_name)))
            {
                int i = 0;

                temp = reader.ReadByte();
                if (temp != '|')
                {
                    fail[0] = "Архив поврежден";
                    return fail;
                }

                while (true)
                {
                    temp = reader.ReadByte();
                    if (temp != '\n')
                    {
                        bytes.Add(temp);
                        i++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            string cap = Encoding.Default.GetString(bytes.ToArray());// маасив с заголовком в строку

            string[] caption = cap.Split(new char[] { '|' });// в новом массиве отдельно содержатся имя файла и его размер
            string[] _caption = new string[caption.Count() / 2];
            int k = 1;
            for (int i = 0; i < _caption.Count(); i++)
            {
                _caption[i] = caption[k + i - 1];
                k++;
            }
            return _caption;
        }
    }
}
