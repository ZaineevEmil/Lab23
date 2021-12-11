using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab23
{
    class Program
    {
        static void Main(string[] args)
        {
            //Расчет факториала
            Console.WriteLine("Введите число у которого требется расчитать факториал:");
            int n = Convert.ToInt32(Console.ReadLine());

            FactorialAsync(n);

            Console.WriteLine("Расчет контрольного значение факториала начался.");
            int FactorialСheck(int N)
            {
                if (N == 1 || N == 0) return 1;
                return N * FactorialСheck(N - 1);
            }
            int check = FactorialСheck(n);
            Console.WriteLine("Расчет контрольного значение факториала закончился. Контрольное значение факториала = {0}", check);
            
            Console.ReadKey();
        }

        static void Factorial(object f)
        {
            int n = Convert.ToInt32(f);
            Console.WriteLine("Испытываемый метод расчета факториала начал работу.");
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            Console.WriteLine("Испытываемый метод расчета факториала закончил работу. Ответ = {0}", result);
        }

        static async void FactorialAsync(int n)
        {
            Action<object> action = new Action<object>(Factorial);
            await Task.Factory.StartNew(action, n);
        }

    }
}
