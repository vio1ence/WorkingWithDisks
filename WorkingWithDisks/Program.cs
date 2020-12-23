using System;
using System.IO;

namespace WorkingWithDisks
{
    class Program
    {
        static void Main(string[] args)
        {
            Backup backup = new Backup();
            backup.Message += MessageConsole;
            HDD g = new HDD("Диск G", "blue TB", new Section(8000000000000));//1TB 
            DVD d = new DVD("Диск D", "DVD-18", "DS DL", new Section(136000000000));//17GB 
            Flash s = new Flash("Диск s", "L", new Section(64000000000));//8GB 
            backup.AddDrive(g);
            backup.AddDrive(d);
            backup.AddDrive(s);
            //- расчет общего количества памяти всех устройств;
            Console.WriteLine($"Общая память всех устройств - {backup.GetAllMemoryListDriver()}");
            //- копирование информации на устройства;
            backup.SetFileDriver(4520000000000);//565GB
            Console.Write(backup.GetAllInfoDriver());
            //- расчет времени необходимого для копирования;
            backup.TimingOfCopying(2048000000000);
            //- расчет необходимого количества носителей информации представленных типов для переноса информации.
            backup.TheRightAmountOfMediaForInformation(4520000000000);
        }
        static void MessageConsole(string m)
        {
            Console.Write(m);
        }
    }
}
