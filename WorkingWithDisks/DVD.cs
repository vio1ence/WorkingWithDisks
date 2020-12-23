using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithDisks
{
    class DVD : Storage
    {
        public decimal ReadingSpeed { get; } = 1385000;
        public decimal RecordingSpeed { get; } = 1385000;
        public string Type { get; set; }
        private Section section;

        public DVD(string mediaName, string model, string type, Section section) : base(mediaName, model)
        {
            this.section = section;
            Type = type;
        }

        public override void CopyDataToDevice(decimal bitfile)
        {
            if (bitfile < 0)
                throw new Exception("Не может быть вес файла меньше 0!\n");
            section.BitBusy += bitfile;
        }

        public override (string mediaName, string model, decimal speed, decimal bitSize, decimal bitBusy) GetInfoDevice()
        {
            return (MediaName, Model, ReadingSpeed, section.BitSize, section.BitBusy);
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
