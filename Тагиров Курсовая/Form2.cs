using System;
using System.IO;
using System.Windows.Forms;

namespace TATdyetyf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string[] t = Form1.ry.Split(' ');
        private void Form2_Load(object sender, EventArgs e)
        {
            labelr.Text = Form1.result;
            for (int i = 1; i < 13; i++)
            {
                this.Controls[$"label{i}"].Text = t[i - 1];
            }
            label13.Text = DateTime.Now.ToString("yyyy.MM.dd, HH.mm.ss");
        }
        public static string name = String.Empty;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.AppendAllText(@"D:\resultat.txt", "\n <---------------------------------------------->");
            File.AppendAllText(@"D:\resultat.txt", name);
            File.AppendAllText(@"D:\resultat.txt", " ");
            File.AppendAllLines(@"D:\resultat.txt", t);
            File.AppendAllText(@"D:\resultat.txt", DateTime.Now.ToString("yyyy.MM.dd, HH.mm.ss"));
            File.AppendAllText(@"D:\resultat.txt", "<----------------------------------------------> \n");
        }
    }
}
