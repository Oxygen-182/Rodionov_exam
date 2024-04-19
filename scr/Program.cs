using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scr
{
    class Program
    {
        class Indications
        {
            public int temper;
            public int vlasz;
            public int davl;
            public Indications (int temper, int vlasz, int davl)
            {
                this.temper = temper;
                this.vlasz = vlasz;
                this.davl = davl;
            }
        }
        class WeatherControl
        {
            public Indications[] indi;
            public WeatherControl (Indications[] indi)
            {
                this.indi = indi;
            }
        }
        static WeatherControl Sort(WeatherControl wc)
        {
            Indications temp;
            for (int i = 0; i < wc.indi.Length; i++)
            {
                for (int j = i + 1; j < wc.indi.Length; j++)
                {
                    if (wc.indi[i].temper > wc.indi[j].temper)
                    {
                        temp = wc.indi[i];
                        wc.indi[i] = wc.indi[j];
                        wc.indi[j] = temp;
                    }
                }
            }
            for (int i = 0; i < wc.indi.Length; i++)
            {
                for (int j = i + 1; j < wc.indi.Length; j++)
                {
                    if (wc.indi[i].vlasz > wc.indi[j].vlasz)
                    {
                        temp = wc.indi[i];
                        wc.indi[i] = wc.indi[j];
                        wc.indi[j] = temp;
                    }
                }
            }
            return wc;
        }
        static void FilePrint(WeatherControl wc)
        {
            using (StreamWriter writer = new StreamWriter(File.Open("result.txt", FileMode.Create)))
            {
                foreach (Indications a in wc.indi)
                {
                    writer.Write($"Температура = {a.temper}\nВлажность = {a.vlasz}\nДавление = {a.davl}\n\n");
                }
            }
        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите размерность массива");
            n = Convert.ToInt32(Console.ReadLine());

            Indications[] masIndi = new Indications[n];
            WeatherControl wc = new WeatherControl(masIndi);
            int temper, vlasz, davl;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nВведите температуру");
                temper = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите влажность");
                vlasz = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите давление");
                davl = Convert.ToInt32(Console.ReadLine());
                wc.indi[i] = new Indications(temper, vlasz, davl);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nТемература = {wc.indi[i].temper}\nВлажноcть = {wc.indi[i].vlasz}\nДавление = {wc.indi[i].davl}\n");
            }

            Console.WriteLine("\nОтсортированный массив:");

            WeatherControl sorted = Sort(wc);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nТемература = {sorted.indi[i].temper}\nВлажноcть = {sorted.indi[i].vlasz}\nДавление = {sorted.indi[i].davl}\n");
            }

            FilePrint(sorted);
        }
    }
}
