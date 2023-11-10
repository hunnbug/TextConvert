using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TextConvert
{
    internal class OOPHell
    {
        public void doloyTrusi()
        {
            Console.WriteLine("введите путь до файла который вы хотите открыть: ");
            string path = Console.ReadLine();

            if (path.EndsWith(".txt"))
            {
                opentxt(path);
            }
            if (path.EndsWith(".json"))
            {
                openjson(path);
            }
            if (path.EndsWith(".xml"))
            {
                openxml(path);
            }
        }
        private Figure createfigurefromtxt(string path)
        {
            Figure figure = new Figure();

            string[] t = File.ReadAllLines(path);
            figure.name = t[0];
            figure.width = t[1];
            figure.height = t[2];
            return figure;
        }

        private string opentxt(string path)
        {
            string text = File.ReadAllText(path);
            Console.Clear();
            Console.WriteLine("содержимое файла:\t|F1 - сохранить файл|\t|Escape - выход из программы|\n");
            Console.WriteLine(text);
            Figure fig = createfigurefromtxt(path);

            Console.WriteLine("нажмите любую кнопку кроме перечисленных выше для продолжения");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.F1)
            {
                ubeyteMenya(text, fig);
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            return text;
        }
        private List<Figure> openjson(string path)
        {
            Console.Clear();
            Console.WriteLine("содержимое файла:\t|F1 - сохранить файл|\t|Escape - выход из программы|\n");

            string text = File.ReadAllText("C:\\Users\\feldo\\Desktop\\ff.json");
            List<Figure> list = JsonConvert.DeserializeObject<List<Figure>>(text);
            foreach (var param in list)
            {
                Console.WriteLine(param.name);
                Console.WriteLine(param.width);
                Console.WriteLine(param.height);
            }
            Console.WriteLine("нажмите любую кнопку кроме перечисленных выше для продолжения");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.F1)
            {
                ubeyteMenya(null, null);
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            return list;
        }
        private void openxml(string path)
        {
            Figure figure = new Figure();

            Console.Clear();
            Console.WriteLine("содержимое файла:\t|F1 - сохранить файл|\t|Escape - выход из программы|\n");

            XmlSerializer xml = new XmlSerializer(typeof(Figure));
            using (FileStream fs = new FileStream("C:\\Users\\feldo\\Desktop\\f.xml", FileMode.Open))
            {
                figure = (Figure)xml.Deserialize(fs);
            }
            Console.WriteLine(figure.name);
            Console.WriteLine(figure.width);
            Console.WriteLine(figure.height);

            Console.WriteLine("нажмите любую кнопку кроме перечисленных выше для продолжения");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.F1)
            {
                ubeyteMenya(null, null);
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        private void ubeyteMenya(string text, Figure figure)
        {
            Console.WriteLine("введите путь до файла, в который вы хотите сохранить");
            string path = Console.ReadLine();

            if (path.EndsWith(".txt"))
            {
                if(text != null)
                {
                    File.WriteAllText(path, text);
                }
                if(figure != null)
                {
                    string json = JsonConvert.SerializeObject(figure);
                    File.WriteAllText(path, json);
                }
            }
            
        }
    }
}
