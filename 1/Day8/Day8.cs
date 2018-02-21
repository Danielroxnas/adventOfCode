using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Day8
    {

        class Register{

            public Register(string inputKey)
            {
                InputKey = inputKey;
            }
            public string InputKey { get; set; }
            public int InputValue { get; set; }
            public int MaxValue { get; set; }
        }

        const string LESSER = "<";
        const string GREATER = ">";
        const string GREATER_OR_EQUAL = "<=";
        const string LESSER_OR_EQUAL = ">=";
        const string EQUAL = "==";
        const string NOT_EQUAL = "!=";
        private IEnumerable<Register> _registers;

        public void Part1()
        {
            var input = File.ReadAllLines("Day8/Day8.txt").Select(x => x.Split(' ')).ToList();

            _registers = input.GroupBy(x => x[0]).Select(x => new Register(x.Key));

            input.ForEach(x => CheckValues(x, _registers.First(y => y.InputKey == x[4])));
            var max = _registers.Max(x => x.InputValue);
        }

        private void CheckValues(string[] x, Register register)
        {
            var incdec = x[1] == "inc" ? "+" : "-";
            var registerForInput = _registers.First(y => y.InputKey == x[0]);
            switch (x[5])
            {
                case LESSER:
                    if(register.InputValue < int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }

                    break;
                case GREATER:
                    if (register.InputValue > int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }
                    break;
                case GREATER_OR_EQUAL:
                    if (register.InputValue >= int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }
                    break;
                case LESSER_OR_EQUAL:
                    if (register.InputValue <= int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }
                    break;
                case EQUAL:
                    if (register.InputValue == int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }
                    break;
                case NOT_EQUAL:
                    if (register.InputValue != int.Parse(x[6]))
                    {
                        IncOrDec(registerForInput, x, register, incdec);
                    }
                    break;
                default:
                    break;

            }
        }

        private static void IncOrDec(Register registerForInput, string[] x, Register register, string incdec)
        {
            registerForInput.InputValue = incdec == "-"
                ? registerForInput.InputValue - int.Parse(x[2])
                : registerForInput.InputValue + int.Parse(x[2]);
        }
    }
}
