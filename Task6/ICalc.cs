using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5
{
    public interface ICalc
    {
        public event EventHandler<EventArgs>? GotResult;
        public void Add(int i);
        public void Add(double i);
        public void Sub(int i);
        public void Sub(double i);
        public void Div(int i);
        public void Div(double i);
        public void Mul(int i);
        public void Mul(double i);
        public void CancelLast();
        public bool TryGetIntResult(out int result);
        public double GetResult();
    }
}