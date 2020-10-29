using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace _5823
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();
            Logger.Log.Info("Запуск программы.");
            try
            {
                int M2 = 0; int M3 = 0; int M6 = 0; int MAX = 0;
                Console.WriteLine("Введите длину цепочки: ");
                int chain = Convert.ToInt32(Console.ReadLine());
                Logger.Log.Info($"Prog: Получена длина цепочки, она есть {chain}");
                Console.WriteLine("Введите последовательность чисел, разделяя их клавишей Enter: ");
                for (int i = 0; i < chain; i++)
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    Logger.Log.Info($"Prog: Получен элемент последовательности, он есть {input}");
                    if (((input % 2) == 0) & ((input % 3) > 0) & (input > M2)) { M2 = input; }
                    if (((input % 3) == 0) & ((input % 2) > 0) & (input > M3)) { M3 = input; }
                    if ((input % 6 == 0) & (input > M6))
                    {
                        if (M6 > MAX) { MAX = M6; M6 = input; }
                    }
                    else
                    {
                        if (input > MAX) { MAX = input; }
                    }
                }
                Console.WriteLine("Введите контрольное число: ");
                int control = Convert.ToInt32(Console.ReadLine());
                Logger.Log.Info($"Prog: Получено контрольное число, оно есть {control}");
                int result;
                if ((M2 * M3) < (M6 * MAX)) { result = M6 * MAX; }
                else { result = M2 * M3; }
                Console.WriteLine($"Вычисленное контрольное значение: {result}");
                if (control == result) { Console.WriteLine("Контроль пройден"); Logger.Log.Info("Prog: Контроль пройден"); }
                else { Console.WriteLine("Контроль не пройден"); Logger.Log.Info("Prog: Контроль не пройден"); }
                Console.ReadKey();
            }
            catch
            {
                Logger.Log.Info("Программа аварийно завершилась.");
            }
            finally
            {
                Logger.Log.Info("Конец программы.");
            }
        }
    }
}
