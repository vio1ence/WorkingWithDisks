using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithDisks
{
    class HDD : Storage
    {
        public decimal SpeedUsb2 { get; } = 480000;
        List<Section> sections;

        public HDD(string mediaName, string model, Section memorySize) : base(mediaName, model)
        {
            sections = new List<Section>();
            sections.Add(memorySize);
        }
        public HDD(string mediaName, string model, List<Section> memorySize) : base(mediaName, model)
        {
            sections = memorySize;
        }

        public override decimal GettingMemorySize()
        {
            decimal sum = 0;
            foreach (var i in sections)
            {
                sum += i.BitSize;
            }
            return sum;
        }

        public override void CopyDataToDevice(decimal bitfile)
        {
            if (bitfile < 0)
                throw new Exception("Не может быть вес файла меньше 0!\n");
            bool flagOperation = true;
            foreach (var i in sections)
            {
                try
                {
                    i.BitBusy += bitfile;
                    flagOperation = false;
                    break;
                }
                catch (Exception)
                {

                }
            }
            if (flagOperation)
            {
                throw new Exception("Нет разделов с достаточным количеством памяти для файла\n");
            }
        }

        public override decimal SpareMemoryOnTheDevice()
        {
            decimal sum = 0;
            foreach (var i in sections)
            {
                sum += (i.BitSize - i.BitBusy);
            }
            return sum;
        }

        public override (string mediaName, string model, decimal speed, decimal bitSize, decimal bitBusy) GetInfoDevice()
        {
            return (MediaName, Model, SpeedUsb2, GettingMemorySize(), GettingMemorySize() - SpareMemoryOnTheDevice());
        }
    }
}
