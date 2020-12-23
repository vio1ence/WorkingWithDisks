using System;

namespace WorkingWithDisks
{
    class Section
    {
        private decimal bitBusy;
        private decimal bitSize;

        public decimal BitSize { get => bitSize; set { if (value > 0) bitSize = value; else throw new Exception("Секция не может иметь размер меньше 1 бита!\n"); } }
        public decimal BitBusy { get => bitBusy; set { if (value < BitSize) bitBusy = value; else throw new Exception("Недостаточно памяти!\n"); } }

        public Section(decimal bitSize)
        {
            BitSize = bitSize;
            bitBusy = 0;
        }

        public Section(decimal bitSize, decimal bitBusy) : this(bitSize)
        {
            BitBusy = bitBusy;
        }
    }
}
