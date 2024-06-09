using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5
{
    public class Calc : ICalc
    {
        public event EventHandler<EventArgs>? GotResult;

        public void Add(int i)
        {
            result += i;
            RegisterResult();
        }
        public void Div(int i)
        {
            result /= i;
            RegisterResult();
        }
        public void Mul(int i)
        {
            result *= i;
            RegisterResult();
        }

        public void Sub(int i)
        {
            result -= i;
            RegisterResult();
        }
        public int GetResult()
        {
            return result;
        }
        public void CancelLast()
        {
            if (resultHistory.TryPop(out int _))
            {
                if (resultHistory.Count > 0) result = resultHistory.Peek();
                else result = 0;
                RaiseEvent();
            }
        }
        private int result;
        private Stack<int> resultHistory = [];
        private void RegisterResult()
        {
            resultHistory.Push(result);
            RaiseEvent();
        }
        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }
}