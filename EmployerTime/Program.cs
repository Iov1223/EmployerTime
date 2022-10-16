using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Indexers_lab
{

    interface ICounter
    {
        int count { get; }
        void BriefPrint();
    }
    interface IWhenCreated
    {
        DateTime Created { get; }
    }
    interface IWorkToDisk
    {
        string filename { get; }
        bool SaveToDisk();
        bool ReadFromDisk();
    }
    class Program
    {
        public void ProgramOperation()
        {
            Console.Write("Введите имя работника: ");
            string Name = Console.ReadLine();
            var worker1 = new EmployerTime(Name + ".txt");
            string hours;
            int time;
            bool res;
            for (int i = 0; i < 7; i++)
            {
                bool isCorrect = false;
                do
                {
                    Console.Write("Отработанно в {0} - ", Enum.GetName(typeof(DayOfWeek), i));
                    hours = Console.ReadLine();
                    res = int.TryParse(hours, out time);
                    if (res && time >= 0 && time <= 24)
                    {
                        worker1[i] = time;
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Что-то пошло не так. Попробуйте снова (ввод от 0 до 24):");
                    }
                } while (isCorrect == false);
            }
            Console.WriteLine();
            //worker1.BriefPrint();
            if (worker1.SaveToDisk())
            {
                Console.WriteLine("Запись прошла успешна.\n");
            }
            else
            {
                Console.WriteLine("Запись не удалась.\n");
            }

            if (worker1.ReadFromDisk())
            {
                Console.WriteLine("Чтение выполнено успешно.\n");
            }
            else
            {
                Console.WriteLine("Чтение не удалось.\n");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ProgramOperation();
        }
    }
}
