using System;
using System.Collections.Generic;
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
                Console.WriteLine($"\nПоказатели номер {i+1}\nТемература = {wc.indi[i].temper}\nВлажномть = {wc.indi[i].vlasz}\nДавление = {wc.indi[i].davl}\n");
            }
        }
    }
}
