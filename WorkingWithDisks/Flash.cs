using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithDisks
{
    class Flash : Storage
    {
        public decimal SpeedUsb3 { get; } = 5000000000; //TODO Usb 3.0 = 5.e+9 Бит
        //private decimal memorySize;
        //private decimal MemoryOccupied = 0;
        private Section section;

        public Flash(string mediaName, string model, Section section) : base(mediaName, model)
        {
            this.section = section;
        }

        public override void CopyDataToDevice(decimal bitfile)
        {
            if (bitfile < 0)
                throw new Exception("Не может быть вес файла меньше 0!\n");
            else if (SpareMemoryOnTheDevice() >= bitfile)
                section.BitBusy += bitfile;
            else if (SpareMemoryOnTheDevice() < bitfile)
                throw new Exception("Недостаточно памяти!\n");
        }

        public override (string mediaName, string model, decimal speed, decimal bitSize, decimal bitBusy) GetInfoDevice()
        {
            return (MediaName, Model, SpeedUsb3, section.BitSize, section.BitBusy);
        }

        public override decimal GettingMemorySize()
        {
            return section.BitSize;
        }

        public override decimal SpareMemoryOnTheDevice()
        {
            return section.BitSize - section.BitBusy;
        }


    }
}
