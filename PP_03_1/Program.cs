using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_03_1
{
    class Program
    {
        static int sleep = 1000;
        static int countPhil = 6;
        static bool[] flag = new bool[countPhil];

        static void Main(string[] args)
        {
            Thread[] th = new Thread[countPhil];

            lock (flag)
            {
                for (int i = 0; i < countPhil; i++)
                {
                    th[i] = new Thread(philEat);
                    th[i].Start(i);
                }
            }
            Console.ReadKey();
        }

        private static void eat()
        {
            for (int i = 0; i < countPhil; i++)
            {
                if (flag[i])
                {
                    Console.WriteLine("Филосов " +  i + " ест" );
                }
            }
            Console.WriteLine();
        }

        private static void philEat(object i)
        {
            int number = ((int)i);
            int philLeft;
            int philRight;
            if (number - 1 < 0)
            {
                philLeft = countPhil - 1;
            }else
            {
                philLeft = number - 1;
            }
            if (number + 1 == countPhil)
            {
                philRight = 0;
            }else
            {
                philRight = number + 1;
            }
            
            while (true) {
                
                if ((flag[philLeft] == false) && (flag[philRight] == false) && (flag[philRight] == false))
                {
                    flag[number] = true;
                    eat();
                    Thread.Sleep(sleep);
                }
                flag[number] = false;
                Thread.Sleep(100);
                
            }
        }
    }
}
