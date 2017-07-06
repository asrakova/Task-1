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
            string text = "";
            string Text = "";

            StreamReader fs = new StreamReader(@"INPUT.TXT");
            string MainStr = fs.ReadLine().ToLower();
            string temp = fs.ReadLine();            // Читаем строку из файла во временную переменную
            char symEnter = Convert.ToChar(13);
            while (temp != null)                    // Если достигнут конец файла, прерываем считывание
            {
                text += temp + Environment.NewLine;       // Пишем считанную строку в итоговую переменную
                Text += temp.ToLower() + "  ";
                temp = fs.ReadLine();
            }


            char sym = Convert.ToChar(9);

            char[] ch = { sym, ' ' };
            string[] ArrStr = Text.Split(ch, StringSplitOptions.None);
            Text = string.Join(" ", ArrStr);
            int index = Text.IndexOf(MainStr);
            while (index != -1)
            {
                Text = Text.Substring(0, index) + '@' + Text.Substring(index);
                text = text.Substring(0, index) + '@' + text.Substring(index);
                index = Text.IndexOf(MainStr, index + 2);
            }
            Console.WriteLine(text);
            Console.WriteLine(Text);
            Console.ReadLine();
        }
    }
}
