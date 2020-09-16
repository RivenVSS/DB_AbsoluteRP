using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace BNS30 // Base Number Samp 3.0
{
    public partial class Form1 : Form
    {
        ArrayList Numbers = new ArrayList(); // Динамический массив элементов (номеров Samp)
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка "Найти"
        {
            //listBox1.Items.Add(Convert.ToString(textBox1.Text)); // Добаление строки в список
            string text = Convert.ToString(textBox1.Text);
            if (text != "")
            {
                for (int i = 1; i < Numbers.Count; i++)
                {
                    if (Numbers[i].ToString().Contains(text))
                    {
                        listBox1.Items.Add(Numbers[i]);
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                }
                textBox1.Clear();
                textBox1.Select(); // Активное поле ввода
            }
            else
            {
                listBox1.Items.Add("Вы не ввели ник.");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e) // При запуске программы
        {
            ///*** Поиск, анализ и сортировка номеров в логе ***///
            try
            {
                int New = 0; // Новые элементы
                Numbers.Clear();
                string Log = BigDateAbsolute.Properties.Settings.Default.Log; // Путь к лог файлу Samp (берём из настроек)
                string BNS = BigDateAbsolute.Properties.Settings.Default.BNS; // Путь к базе номеров (берём из настроек)
                string Buffer; // Промежуточные значения
                FileStream LogSamp = new FileStream(Log, FileMode.Open); // Открытие файла
                StreamReader RLogSamp = new StreamReader(LogSamp, Encoding.Default); // Открытие потока для чтения из файла
                while (!RLogSamp.EndOfStream) // ! - Not , (пока не закончился файл)
                {
                    Buffer = RLogSamp.ReadLine(); // Читаем промежуточное значение
                    if (Buffer.Contains("Контакт: ")) // Имеется ли элемент в строке ?
                    {
                        int Index = Buffer.IndexOf("Контакт: ") + 9; // Находим индекс элемента и прибавляем 9 (для исключения элемента "Контакт: ")
                        int Length = Buffer.Length - Index; // Находим длину нужной подстроки
                        Buffer = Buffer.Substring(Index, Length); // Присваиваем Buffer подстроку (Начальный индекс, Длина)
                        Numbers.Add(Buffer);
                        New++;
                    }
                }
                RLogSamp.Close();
                FileStream Base = new FileStream(BNS, FileMode.Open); // Открытие файла
                StreamReader RBase = new StreamReader(Base, Encoding.Default); // Открытие потока для чтения из файла
                while (!RBase.EndOfStream) // Запись БД номеров в массив
                {
                    Buffer = RBase.ReadLine();
                    Numbers.Add(Buffer);
                }
                RBase.Close();
                int DNumbers = 0; // Счётчик дублей
                Numbers.Sort(); // Сортировка массива
                                ///*** Поиск, анализ и сортировка номеров в логе ***///
                                ///*** Удаление дублей ***///
                for (int i = 1; i < Numbers.Count; i++)
                {
                    if (Numbers[i].ToString() == Numbers[i - 1].ToString())
                    {
                        Numbers[i - 1] = "0";
                        DNumbers++;
                    }
                }
                Numbers.Sort(); // Сортировка массива
                Numbers.RemoveRange(0, DNumbers); // Удаление нулевых элементов массива в диапазоне (0, DNumbers)
                                                  ///*** Удаление дублей ***///
                                                  ///*** Запись в BNS ***///
                FileStream WriteBase = new FileStream(BNS, FileMode.Create);
                StreamWriter WBase = new StreamWriter(WriteBase, Encoding.Default);
                WriteBase.Seek(0, SeekOrigin.End);
                for (int i = 0; i < Numbers.Count; i++) // Вывод массива в BNS
                {
                    WBase.WriteLine(Numbers[i]);
                }
                WBase.Close();
                ///*** Запись в BNS ***///
                listBox1.Items.Add("Добавление новых элементов завершено.");
                New = New - DNumbers;
                listBox1.Items.Add("Всего: " + Numbers.Count + " Новых: " + New);
                listBox1.Items.Add("Введите ник или часть ника...");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                textBox1.Select(); // Активное поле ввода
            } catch
            {
                listBox1.Items.Add("Неверно указан путь.");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) // Добаление строки в список Enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Для корректной работы Enter
                string text = Convert.ToString(textBox1.Text);
                if (text != "")
                {
                    listBox1.Items.Add("-----------------------------");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    for (int i = 1; i < Numbers.Count; i++)
                    {
                        if (Numbers[i].ToString().Contains(text))
                        {
                            listBox1.Items.Add(Numbers[i]);
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        }
                    }
                    textBox1.Clear();
                    textBox1.Select(); // Активное поле ввода
                }
                else
                {
                    listBox1.Items.Add("Вы не ввели ник.");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Settings = new Form2(); // Объявление формы
            Settings.Show(); // Вывод формы
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Если нажатая кнопка это ПКМ
            {
                if (listBox1.IndexFromPoint(e.X, e.Y) != -1) // Если в точке X,Y есть элемент (-1 если нету)
                {
                    listBox1.SetSelected(listBox1.IndexFromPoint(e.X, e.Y), true);  // Выделяем элемент в точке (x,y)
                    listBox1.ContextMenuStrip.Show(listBox1, new Point(e.X, e.Y)); // Вызываем контекстное меню в точке (x,y)
                }
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) // Если есть выделеный элемент
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString()); // Копируем в буффер обмена
            }
        }
    }
}
