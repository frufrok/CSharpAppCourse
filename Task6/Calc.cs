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
            if (TryGetIntResult(out int value)) result = value / i;
            else result /= i;
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
        public void CancelLast()
        {
            if (resultHistory.TryPop(out double _))
            {
                if (resultHistory.Count > 0) result = resultHistory.Peek();
                else result = 0;
                RaiseEvent();
            }
        }
        private double result;
        private Stack<double> resultHistory = [];
        private void RegisterResult()
        {
            resultHistory.Push(result);
            RaiseEvent();
        }
        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void Add(double i)
        {
            result += i;
            RegisterResult();
        }

        public void Sub(double i)
        {
            result -= i;
            RegisterResult();
        }

        public void Div(double i)
        {
            result /= i;
            RegisterResult();
        }

        public void Mul(double i)
        {
            result *= i;
            RegisterResult();
        }

        public bool TryGetIntResult(out int result)
        {
            if (this.result % 1 == 0)
            {
                result = (int)this.result;
                return true;
            }
            else 
            {
                result = 0;
                return false;
            }
        }

        public double GetResult()
        {
            return result;
        }
    }
}