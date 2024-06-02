using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Bits : IBitModifiable
    {
        public Bits(byte value)
        {
            Value = value;
        }
        public byte Value { get; private set; }
        public bool GetBitByIndex(int index)
        {
            return (Value & (1 << index)) != 0;
        }

        public bool[] GetBits()
        {
            int n = this.GetBitsCount();
            bool[] result = new bool[n];
            for (byte i = 0; i < n; i++)
            {
                result[i] = this.GetBitByIndex(n - i - 1);
            }
            return result;
        }

        public int GetBitsCount()
        {
            var log = Math.Log(Value, 2);
            return Value == 0 ? 1 : (int)Math.Ceiling(log) + (log % 1 == 0 ? 1 : 0);
        }

        public string GetBitsString()
        {
            StringBuilder result = new();
            this.GetBits().ToList().ForEach(x => result.Append(x ? 1 : 0));
            return result.ToString();
        }

        public override string ToString()
        {
            return this.GetBitsString();
        }

        public void SetBitByIndex(int index, bool value)
        {
            if (value)
            {
                Value |= (byte)(1 << index);
            }
            else
            {
                Value &= (byte)~(1 << index);
            }
        }
        public bool this[int index] => GetBitByIndex(index);
        public static implicit operator byte(Bits bits) => bits.Value;
        public static explicit operator Bits(byte value) => new(value);
    }
}