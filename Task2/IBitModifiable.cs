using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface IBitModifiable
    {
        bool GetBitByIndex(int index);
        void SetBitByIndex(int index, bool value);
        int GetBitsCount();
        bool[] GetBits();
        string GetBitsString();
    }
}