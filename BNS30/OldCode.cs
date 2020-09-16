///*** Поиск, анализ и сортировка номеров в логе ***///
            ArrayList Numbers = new ArrayList(); // Динамический массив элементов (номеров Samp)
            string  Log = Properties.Settings.Default.Log; // Путь к лог файлу Samp (берём из настроек)
            string BNS = Properties.Settings.Default.BNS; // Путь к базе номеров (берём из настроек)
            string  Buffer; // Промежуточные значения
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
            ///*** Удаление старых номеров ***///
            
            ///*** Удаление старых номеров ***///
            for (int i = 0; i < Numbers.Count; i++) // Вывод массива в listBox1
            {
                listBox1.Items.Add(Numbers[i]);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }




 ///*** Поиск, анализ и сортировка номеров в логе ***///
            ArrayList Numbers = new ArrayList(); // Динамический массив элементов (номеров Samp)
            ArrayList NewNumbers = new ArrayList(); // Динамический массив новых элементов (номеров Samp)
            string  Log = Properties.Settings.Default.Log; // Путь к лог файлу Samp (берём из настроек)
            string BNS = Properties.Settings.Default.BNS; // Путь к базе номеров (берём из настроек)
            string  Buffer; // Промежуточные значения
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
                    NewNumbers.Add(Buffer);
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
            NewNumbers.Sort(); // Сортировка массива
            ///*** Поиск, анализ и сортировка номеров в логе ***///
            ///*** Удаление дублей ***///
            int DNumbers = 0; // Счётчик дублей
            for (int i = 1; i < NewNumbers.Count; i++)
            {
                if (NewNumbers[i].ToString() == NewNumbers[i - 1].ToString())
                {
                    NewNumbers[i - 1] = "0";
                    DNumbers++;
                }
            }
            NewNumbers.Sort(); // Сортировка массива
            NewNumbers.RemoveRange(0, DNumbers); // Удаление нулевых элементов массива в диапазоне (0, DNumbers)
            ///*** Удаление дублей ***///
            ///*** Удаление старых номеров ***/// 
            /*
            for (int i = 0; i < NewNumbers.Count; i++)
            {
                Buffer = NewNumbers[i].ToString();
                int Length = Buffer.IndexOf(", т: ") + 9; // Находим индекс элемента
                Buffer = Buffer.Substring(0, Length); // Находим имя контакта
                int Index = Numbers.IndexOf(Buffer); // С каким индексом элемент содержет значение переменной Buffer
                while ()
                if (NewNumbers[i].ToString() != Numbers[Index].ToString()) // Проверяем, одинаковы ли элементы
                {
                    Numbers.Insert(Index, Buffer);
                }

            }
            ///*** Удаление старых номеров ***///
            for (int i = 0; i < Numbers.Count; i++) // Вывод массива в listBox1
            {
               listBox1.Items.Add(Numbers[i]);
               listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }




///*** Поиск, анализ и сортировка номеров в логе ***///
            ArrayList Numbers = new ArrayList(); // Динамический массив элементов (номеров Samp)
ArrayList NewNumbers = new ArrayList(); // Динамический массив новых элементов (номеров Samp)
string Log = Properties.Settings.Default.Log; // Путь к лог файлу Samp (берём из настроек)
string BNS = Properties.Settings.Default.BNS; // Путь к базе номеров (берём из настроек)
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
                    NewNumbers.Add(Buffer);
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
            NewNumbers.Sort(); // Сортировка массива
            ///*** Поиск, анализ и сортировка номеров в логе ***///
            ///*** Удаление дублей ***///
            int DNumbers = 0; // Счётчик дублей
            for (int i = 1; i<NewNumbers.Count; i++)
            {
                if (NewNumbers[i].ToString() == NewNumbers[i - 1].ToString())
                {
                    NewNumbers[i - 1] = "0";
                    DNumbers++;
                }
            }
            NewNumbers.Sort(); // Сортировка массива
            NewNumbers.RemoveRange(0, DNumbers); // Удаление нулевых элементов массива в диапазоне (0, DNumbers)
            ///*** Удаление дублей ***///
            ///*** Удаление старых номеров ***/// 
            for (int i = 0; i<NewNumbers.Count; i++) // Проверка соответствия
            {
                DNumbers = 0; // Счётчик лишних строк
                Buffer = NewNumbers[i].ToString();
int Length = Buffer.IndexOf(", т: "); // Находим индекс элемента ", т: "
Buffer = Buffer.Substring(0, Length); // Находим имя контакта
              //  int Index = Numbers.IndexOf(Buffer); // С каким индексом элемент содержит значение переменной Buffer
                ArrayList Zam = new ArrayList(); // Динамический массив
Zam.Clear();
                for (int k = 0; k<Numbers.Count; k++)
                {
                    if (Numbers[k].ToString().IndexOf(Buffer) != -1)
                    {
                        Zam.Add(k);
                    }
                }
                    if (Zam.Count == 0)
                    {
                        Numbers.Add(NewNumbers[i].ToString());
                    }
                    else
                    {
                        for (int j = 0; j<Zam.Count; j++) 
                        {
                            string In = Zam[j].ToString();
int Index = Convert.ToInt32(In);
Numbers.Insert(Index, NewNumbers[i].ToString());
                        }
                    }
            }
            ///*** Удаление старых номеров ***///
            //////*** Удаление дублей ***///
            Numbers.Sort();
            DNumbers = 0;
            for (int i = 1; i<Numbers.Count; i++)
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
            for (int i = 0; i<Numbers.Count; i++) // Вывод массива в listBox1
            {
                listBox1.Items.Add(Numbers[i]);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            listBox1.Items.Add("NEW//////////");
            for (int i = 0; i<NewNumbers.Count; i++) // Вывод массива в listBox1
            {
                listBox1.Items.Add(NewNumbers[i]);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }