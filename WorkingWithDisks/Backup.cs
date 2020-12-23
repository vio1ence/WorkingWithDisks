using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithDisks
{
    class Backup
    {
        public List<Storage> driver;
        public event Action<string> Message;
        public Backup()
        {
            driver = new List<Storage>();
        }

        public Backup(List<Storage> driver)
        {
            this.driver = driver;
        }
        public void AddDrive(Storage storage)
        {
            driver.Add(storage);
        }
        //- расчет общего количества памяти всех устройств;
        public decimal GetAllMemoryListDriver()
        {
            decimal MemorySum = 0;
            foreach (var item in driver)
                MemorySum += item.GettingMemorySize();

            return MemorySum;
        }
        //- копирование информации на устройства;
        public void SetFileDriver(decimal sizeFileBit)
        {
            foreach (var item in driver)
                CheckingForExceptions(() => item.CopyDataToDevice(sizeFileBit));
        }
        private void CheckingForExceptions(Action act)
        {
            try
            {
                act();
            }
            catch (Exception e)
            {
                Message?.Invoke(e.Message);
            }
        }
        public string GetAllInfoDriver()
        {
            string result = "";
            foreach (var i in driver)
            {
                var dr = i.GetInfoDevice();
                result +=
                    $"Название диска:{dr.mediaName}\n" +
                    $"Модель:{dr.model}\n" +
                    $"Скорость:{dr.speed}\n" +
                    $"Размер памяти:{dr.bitSize}\n" +
                    $"Занято памяти:{dr.bitBusy}\n\n";
            }
            if (result != "") return result;
            else return "В списке нет дисков\n";
        }
        //- расчет времени необходимого для копирования;
        public void TimingOfCopying(decimal sizeFileBit)
        {
            int i = 1;
            foreach (var item in driver)
            {
                var dr = item.GetInfoDevice();
                Message?.Invoke($"№{i++} Диска, Расчет времени необходимого для копирования:{(int)(sizeFileBit / dr.speed)} сек\n");
            }
        }
        //- расчет необходимого количества носителей информации представленных типов для переноса информации.
        public void TheRightAmountOfMediaForInformation(decimal sizeFileBit)
        {
            bool flag = false;
            decimal temp = sizeFileBit;
            int result = 1;
            foreach (var item in driver)
            {
                var dr = item.GetInfoDevice();
                if (dr.bitSize > temp)
                {
                    flag = true;
                    break;
                }
                else
                {
                    result++;
                    temp -= dr.bitSize;
                }
            }
            if (!flag)
            {
                Message?.Invoke("Текущего списка не хватит для переноса информации\n");
            }
            else
            {
                Message?.Invoke($"Кол-во дисков из списка потребуется для переноса:{result}\n");
            }
        }

    }
}
