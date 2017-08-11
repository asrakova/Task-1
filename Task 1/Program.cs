using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Переменные для работы с текстом
            string text = "";
            string copyText = "";

            //Пробельные символы
            char symEnter = Convert.ToChar(13);
            char symTab = Convert.ToChar(9);
            char[] ch = { symTab, ' ', symEnter };

            int index = 0;  // Индекс

            // Файлы
            StreamReader fileRead = new StreamReader("input.txt");
            StreamWriter fileWrite = new StreamWriter("output.txt");

            // Считывание запроса и перевод в нижний регистр
            string MainStr = fileRead.ReadLine().ToLower();
           
            // Считывание текста
            string temp = fileRead.ReadLine();
            while (temp != null)
            {
                text += temp + symEnter;
                temp = fileRead.ReadLine();
            }

            // Разбивка текста на слова по пробельным символам
            string[] arrWords = text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            // Массив для пробельных символов
            string[] arrSym = new string[200];
            copyText = text;
            // В копии текста удаляем слова, сохраняя пробельные символы в массив
            copyText = copyText.Remove(0, arrWords[0].Length);
            for (int i = 1; i < arrWords.Length; i++)
            {
                index = copyText.IndexOf(arrWords[i][0]);
                arrSym[i - 1] = copyText.Remove(index);
                copyText = copyText.Remove(0, arrWords[i].Length + index);
            }

            // Соединяем слова в текст с пробелами
            text = string.Join(" ", arrWords);
            // Копию текста переводим в нижний регистр
            copyText = text.ToLower();
            // Ищем запрос в копии текста и добавляем символ @ в оба текста
            index = copyText.IndexOf(MainStr);
            while (index != -1)
            {
                copyText = copyText.Substring(0, index) + '@' + copyText.Substring(index);
                text = text.Substring(0, index) + '@' + text.Substring(index);
                index = copyText.IndexOf(MainStr, index + 2);
            }

            // Разбиваем полученный основной текст по пробелам
            arrWords = text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            // Соединяем полученные слова с пробельными символами
            text = arrWords[0];
            for (int i = 1; i < arrWords.Length; i++)
                text += arrSym[i - 1] + arrWords[i];
            text += symEnter;
      
            // Выводим ответ в файл
            index = text.IndexOf(symEnter);
            while (index != -1)
            {
                copyText = text.Substring(0, index);
                fileWrite.WriteLine(copyText);
                text = text.Substring(index + 1);
                index = text.IndexOf(symEnter);
            }

            // Закрытие файлов
            fileWrite.Close();
            fileRead.Close();
        }
    }
}
