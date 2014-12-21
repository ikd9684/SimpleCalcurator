
using System;
using System.Windows;
namespace SimpleCalculator.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class BasicCalculator
    {
        /// <summary>入力値 A</summary>
        private Value ValueA;
        /// <summary>入力値 B</summary>
        private Value ValueB;
        /// <summary>演算子</summary>
        private Operator Ope;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public BasicCalculator()
        {
            ValueA = new Value();
            ValueB = new Value();
            Ope = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string AddInput(int input)
        {
            if (Ope == null)
            {
                ValueA.AddInput(input);
                return ValueA.ToString();
            }
            else
            {
                ValueB.AddInput(input);
                return ValueB.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string AddInput(Value.Symbol input)
        {
            if (Ope == null)
            {
                ValueA.AddInput(input);
                return ValueA.ToString();
            }
            else
            {
                ValueB.AddInput(input);
                return ValueB.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ope_"></param>
        /// <returns></returns>
        public string SetOperator(Operator ope_)
        {
            decimal a = ValueA.GetDecimal();
            decimal b = ValueB.GetDecimal();

            if (Ope == null)
            {
                Ope = ope_;
                return ValueA.ToString();
            }
            else
            {
                try
                {
                    decimal ans = Ope.Invoke(a, b);

                    ValueA.SetDecimal(ans);
                    ValueB.Clear();

                    if (ope_ == BasicOperator.Equal)
                    {
                        Ope = null;
                    }
                    else
                    {
                        Ope = ope_;
                    }

                    return ans.ToString();
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("ゼロで割ることはできません。", "DivideByZeroException");

                    ValueB.Clear();
                    return ValueA.ToString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Clear()
        {
            ValueA.Clear();
            ValueB.Clear();
            Ope = null;

            return Value.ZERO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            if (Ope == null)
            {
                ValueA.Delete();
                return ValueA.ToString();
            }
            else
            {
                ValueB.Delete();
                return ValueB.ToString();
            }
        }
    }

}
