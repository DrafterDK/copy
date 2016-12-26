using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Копировальщик
{
    public partial class Form1 : Form
    {
        string path_in = null;
        string path_out = null;
        int max_count=0;
       public string file_name = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numb_del = 0;
            int numb_copy = 0;
            string file_name = "" ;
            try
            {
               
                DirectoryInfo outut_dir = new DirectoryInfo(path_out);
                DirectoryInfo input_dir = new DirectoryInfo(path_in);
                              
                label3.Visible = false;
                foreach (FileInfo file in input_dir.GetFiles())
                {
                       max_count++;

                }
             //  MessageBox.Show("" + max_count);
                progressBar1.Maximum = max_count;

                if (checkBox1.Checked)
                {


                    foreach (FileInfo file in outut_dir.GetFiles())
                    {
                        file.Delete();
                        numb_del++;

                    }


                    Trey.BalloonTipIcon = ToolTipIcon.Info;
                    Trey.BalloonTipTitle = "Удаление";
                    Trey.BalloonTipText = "Удаление завершено";
                    Trey.ShowBalloonTip(5000);
                }

               
                FileInfo[] fi = input_dir.GetFiles();
                try
                {
                    foreach (FileInfo i in fi)
                    {

                        i.CopyTo(path_out + i.Name);
                        numb_copy++;
                        progressBar1.Value = numb_copy;
                        file_name = i.Name;
                    }
                    Trey.BalloonTipIcon = ToolTipIcon.Info;
                    Trey.BalloonTipTitle = "Копирование";
                    Trey.BalloonTipText = "Копирование завершено";
                    Trey.ShowBalloonTip(5000);
                    label3.Visible = true;
                    max_count = 0;
                }
                catch
                {
                    MessageBox.Show(null, "Файл источника есть в приемнике", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    max_count = 0;
                }

                            

            }

            catch 
            {
              
                Trey.BalloonTipIcon = ToolTipIcon.Info;
                Trey.BalloonTipTitle = "Ошибка";
                Trey.BalloonTipText = "Будте внимательней";
                Trey.ShowBalloonTip(5000);
               // MessageBox.Show(""+ Convert.ToString(e));
                MessageBox.Show(null, "Не указаны все пути", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        


        private void button2_Click_1(object sender, EventArgs e)
        {                    
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path_in = dialog.SelectedPath;
            path_in = path_in + "\\";
            label2.Text = path_in;
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path_out = dialog.SelectedPath;
            path_out = path_out + "\\";
            label4.Text = path_out;
     
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

