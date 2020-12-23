using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithDisks
{
    abstract class Storage
    {
        public string MediaName { get; set; }
        public string Model { get; set; }

        protected Storage(string mediaName, string model)
        {
            MediaName = mediaName;
            Model = model;
        }


        //получение объема памяти
        public abstract decimal GettingMemorySize();
        //копирование данных (файлов/папок) на устройство
        public abstract void CopyDataToDevice(decimal bitfile);
        //получение информации о свободном объеме памяти на устройстве
        public abstract decimal SpareMemoryOnTheDevice();
        //получение общей/полной информации об устройстве
        public abstract (string mediaName, string model, decimal speed, decimal bitSize, decimal bitBusy) GetInfoDevice();
    }
}
