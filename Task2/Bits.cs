using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Bits : IBitModifiable
    {
        public long Value { get; private set; }

        public int Size { get; private set; }

        public Bits(byte value)
        {
            Value = value;
            Size = sizeof(byte);
        }

        public Bits(int value)
        {
            Value = value;
            Size = sizeof(int);
        }

        public Bits(long value)
        {
            Value = value;
            Size = sizeof(long);
        }

        public bool TryGetInt(out int value)
        {
            if (Size <= sizeof(int))
            {
                value = (int)this;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool TryGetByte(out byte value) 
        {
            if (Size <= sizeof(byte))
            {
                value = (byte)this;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public static explicit operator byte(Bits bits) => (byte)bits.Value;

        public static explicit operator int(Bits bits) => (int)bits.Value;

        public static implicit operator long(Bits bits) => bits.Value;

        public static implicit operator Bits(byte value) => new(value);

        public static implicit operator Bits(int value) => new(value);

        public static implicit operator Bits(long value) => new(value);

        public bool this[int index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

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
    }
}