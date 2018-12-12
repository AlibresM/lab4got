using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string FileName = "";

        int snum = 0;
        int wnum = 0;
        public void Save()
        {
            if(FileName == "")
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Текстовые файлы | *.txt";
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    File.WriteAllText(dialog.FileName, textBox.Text);
                    FileName = dialog.FileName;
                }
            }
            else
            {
                try
                {
                    File.WriteAllText(FileName, textBox.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }               
            }
            
        }
        public void SaveAs()
        {           
            var dialog = new SaveFileDialog();            
            dialog.Filter = "Текстовые файлы | *.txt";           
            var result = dialog.ShowDialog();
            if (result == true)
            {                
                File.WriteAllText(dialog.FileName, textBox.Text);
                FileName = dialog.FileName;
            }            
        }

        public void Open()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы | *.txt";
            var result = dialog.ShowDialog();
            if (result == true)
            {
                textBox.Text = File.ReadAllText(dialog.FileName);
                FileName = dialog.FileName;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Open();
            textBox.UndoLimit = 0;
            textBox.UndoLimit = 100;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.Undo();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Redo();            
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {       
            var about = new Window1();           
            about.Show();
        }
       

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            var newdialog = new NewDialog();
            newdialog.ShowDialog();

            switch (newdialog.res)
            {
                case 0: textBox.Clear(); FileName = ""; break;
                case 1: Save(); textBox.Clear(); FileName = ""; break;
                case 2: break;
                default: break;
            }
            textBox.UndoLimit = 0;
            textBox.UndoLimit = 100;
        }

       

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            snum = 0;
            wnum = 0;
            char[] textarray = textBox.Text.ToCharArray();

            for (int i = 0; i < textarray.Length; i++)
            {
                if (textarray[i] == ' ') wnum++;
                wordnum.Text = (wnum + 1).ToString();
                snum = textarray.Length;
                symbolnum.Text = snum.ToString();
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
