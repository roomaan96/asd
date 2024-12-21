using System;
using System.Drawing;
using System.Windows.Forms;

namespace TATdyetyf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int k = 0;
        string[] quest = (Properties.Resources.вопросы).Split('\n');//генерация списка вопросов и вариантов ответа из файла
        string[] otv = (Properties.Resources.Ответы).Split('\n');//генерация списка правильных ответов из файла.
        string[] user = new string[15];
        public static string ry = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Начать")//Проверяет корректность введенных данных перед тестированием.
            {
                if ((textBox1.Text).Split(' ').Length == 2)
                {
                    Form2.name = textBox1.Text;//передает имя пользователя для записи.
                    button1.Text = "Далее";
                    button1.PerformClick();//инициализация поторного нажатия кнопки, с уже измененными свойствами.
                }
                else if (textBox1.Text != "")//некорректный ввод данных.
                {
                    MessageBox.Show("Данные введены некорректно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else//данные не введены.
                {
                    MessageBox.Show("Введите данные", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button1.Text == "Начать заново")//для начала нового теста.
            {
                button1.Text = "Начать";
                //значение переменных по умолчанию.
                p = 0;
                b = 0;
                k = 0;
                ry = "";
                //Обновление данных после старого теста.
                labely.Visible = false;
                labely.Enabled = false;
                label1.Visible = false;
                label1.Enabled = false;
                label2.Visible = false;
                label2.Enabled = false;
                label3.Visible = false;
                label3.Enabled = false;
                label4.Visible = false;
                label4.Enabled = false;
                //включение ввода данных.
                textBox1.Visible = true;
                textBox1.Enabled = true;
                label1.BackColor = Color.Transparent;
                label2.BackColor = Color.Transparent;
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
            }
            else//Переключение на следующий вопрос.
            {
                //Активация метки с вопросом.
                labely.Visible = true;
                labely.Enabled = true;
                label1.Visible = true;
                label1.Enabled = true;
                label2.Visible = true;
                label2.Enabled = true;
                label3.Visible = true;
                label3.Enabled = true;
                label4.Visible = true;
                label4.Enabled = true;
                textBox1.Visible = false;
                textBox1.Enabled = false;
                label1.BackColor = Color.Transparent;
                label2.BackColor = Color.Transparent;
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                if (k < quest.Length && p == 0)//количество показанных вопросов.
                {
                    p++;//если = 1, то ответ на вопрос не был получен и переклбчение на другой невозможно.
                    labely.Text = quest[k].Split(':')[0];//отображение вопроса в метке.
                    for (int i = 1; i < 5; i++)//отображение вариантов ответа.
                    {
                        this.Controls[$"label{i}"].Text = quest[k].Split(':', '|')[i];
                    }
                    k++;
                }
                else if (k >= quest.Length)//все вопросы показаны.
                {
                    for (int i = 0; i < otv.Length; i++)
                    {
                        //форматирование строк
                        string l = otv[i].Replace("\r", String.Empty);
                        string r = user[i].Replace("\r", String.Empty);
                        if (l == r)//сравнение правильного и пользовательского ответа.
                        {
                            ry += "yes" + " ";//подготовка данных для передачи в следующую форму.
                            b++;//количество баллов увеличено.
                        }
                        else ry += "no" + " ";
                    }
                    result = $"Количество очков: {b}";//запись баллов для вывода.
                    Form form = new Form2();//инициализация формы 2
                    form.ShowDialog();//активация формы 2
                    button1.Text = "Начать заново";
                }
            }
        }

        public static string result;//объявление глобальной переменной.
        int b = 0;//количество баллов по умолчанию.
        int p = 0;
        private void label4_Click(object sender, EventArgs e)//запись выбранного варианта ответа пользователем.
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            (sender as Label).BackColor = Color.Red;//подкрашивание выбранного варианта.
            if (p == 1)//ответ на предыдущий вопрос получен.
            {
                user[k - 1] = (sender as Label).Text;//Запись полученного ответа.
                p = 0;
            }
        }

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)//Дублирует "Начать заново".
        {
            button1.Text = "Начать заново";
            button1.PerformClick();
        }
    }
}
