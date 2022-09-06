using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // calculator class to handle all regular operations of a calculator
    internal class Calculator
    {
        // most methods in this class are overriden with integer and double parameters

        //public char operation field, which can be read and set
        public char Oper { get; set; }

        public Calculator()
        {
            Oper = 'O'; // 'O' a dummy value tested to see if the operation of the current calculator instance has changed
        }

        public int add(int i, int n) { return i + n; }
        public double add(double i, double n) { return i + n; }

        public int subtract(int i, int n) { return i - n; }
        public double subtract(double i, double n) { return i - n; }

        public int multiply(int i, int n) { return i * n; }
        public double multiply(double i, double n) { return i * n; }

        public int divide(int i, int n) { return i / n; }
        public double divide(double i, double n) { return i / n; }

        public int mod(int i, int n) { return i % n; }

        public int operate(int i, int n)
        {
            if (Oper == '/' && n == 0) { throw new DivideByZeroException(); }
            switch (Oper)
            {
                case '+':
                    return add(i, n);
                case '-':
                    return subtract(i, n);
                case '*':
                    return multiply(i, n);
                case '/':
                    return divide(i, n);
                case '%':
                    return mod(i, n);
                default:
                    return 0;
            }
        }

        public double operate(double i, double n)
        {
            if (Oper == '/' && n == 0) { throw new DivideByZeroException(); }
            switch (Oper)
            {
                case '+':
                    return add(i, n);
                case '-':
                    return subtract(i, n);
                case '*':
                    return multiply(i, n);
                case '/':
                    return divide(i, n);
                default:
                    return 0.0;
            }
        }

        // public static class to handle parsing integers and double values
        public static class Parser
        {
            public static int ParseInt(string n)
            {
                int i = 0;
                bool isInt = false;
                try
                {
                    isInt = int.TryParse(n, out i);
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                if (!isInt) return 0;
                return i;
            }

            public static double ParseDouble(string n)
            {
                double i = 0.0;
                bool isDec = false;
                try
                {
                    isDec = double.TryParse(n, out i);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                if (!isDec) return 0;
                return i;
            }
        }
    }
}
