using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace Combination_with_repetitions
{
    class Program
    {
        static int Index(char[] masN, char x)
        {//поиск номера элемента массива N с заданным значением
            int i = 0;
            while (masN[i] != x)
            {
                i++;
            }
            return i;
        }

        static void Main(string[] args)
        { //Время работы программы 
            DateTime time1 = DateTime.Now;
            for (int i = 0; i < 20000000; i++) { }
            DateTime time2 = DateTime.Now;
            Console.WriteLine("Время выполнения: {0}", (time2 - time1).Milliseconds);

            StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\ConsoleApp7\ConsoleApp7\txt.txt");
            do
            {
                int N;
                do
                {
                    Console.WriteLine("Введите число N: ");
                    N = int.Parse(Console.ReadLine());
                    if ((N > 36) || (N == 1)) Console.WriteLine("N не должно превышать 36 и должно быть больше 1");
                } while ((N > 36) || (N == 1));
                while  (N == 1);
                Console.WriteLine("Введите число K: ");
                int K = int.Parse(Console.ReadLine());

                char[] masN = new char[N];//массив значений N
                char[] masK = new char[K];//массив значений K
                int j = (int)'A';
                for (int i = 0; i < N; i++)//заполняем массив N значениями
                {
                    if (i <= 9) masN[i] = Char.Parse(i.ToString());
                    else
                    {
                        masN[i] = (char)j;
                        j++;
                    }
                }
                for (int i = 0; i < K; i++)//Заполняем массив K нулями
                    masK[i] = '0';

                sw.WriteLine(masK);  //выводим на экран K нулей
                int k = K - 1;//номер последнего элемента массива K (для простоты обращения)
                int min = 1;//номер элемента из массива N, который будет считаться минимальным для данного сочетания
                do
                {
                    for (int i = min; i < N; i++)//прибаляем к последнему элементу единицу до тех пор, пока он не достигнет значения N-1
                    {
                        masK[k] = masN[i];
                        sw.WriteLine(masK);
                    }
                    for (int i = 1; i <= k; i++)//находим первый слева элемент, который равен элементу из массива N под номером N-1, заменяем элемент перед ним на больший на один, а также все последующие на данное значение
                    {
                        if (masK[i] == masN[N - 1])//если элемент равен N-1
                        {
                            masK[i - 1] = masN[Index(masN, masK[i - 1]) + 1];//заменяем предыдущий на больший на 1
                            min = Index(masN, masK[i - 1]);//минимальное значение становится равным предыдущему элементу
                            for (int l = i; l <= k; l++)//все элементы после него заменяем на min
                            masK[l] = masN[min]; 
                            break;
                        }
                    }
                } while ((masK[0] != masN[N - 1]));//пока первый элемент не станет равен элементу из массива N под номером N-1.
                if (K > 1) 
                Console.ReadLine(); //выводим последний вариант
                sw.WriteLine(masK);
                sw.Close();
                Process.GetCurrentProcess().Kill();
            } while (true);
        }
    }
}


