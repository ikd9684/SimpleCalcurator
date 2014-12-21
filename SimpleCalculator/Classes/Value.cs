using System;
using System.Reflection;
using System.Text;

namespace SimpleCalculator.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Value
    {
        /// <summary>ゼロ "0"</summary>
        public const string ZERO = "0";

        /// <summary>記号</summary>
        public enum Symbol
        {
            /// <summary>［+/-］正負反転</summary>
            [Value('-')]
            InverSign,
            /// <summary>［.］ピリオド</summary>
            [Value('.')]
            Period,
        }

        /// <summary></summary>
        private StringBuilder InputBuffer = new StringBuilder();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetDecimal()
        {

            if (InputBuffer.Length == 0)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(InputBuffer.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetDecimal(decimal value)
        {
            if (value != 0)
            {
                InputBuffer = new StringBuilder(value.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void AddInput(int input)
        {
            if (input < 0 || 9 < input)
            {
                throw new ArgumentException();
            }

            if (0 < InputBuffer.Length || input != 0)
            {
                InputBuffer.Append(input.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void AddInput(Symbol input)
        {
            if (input == Symbol.InverSign)
            {
                if (InputBuffer.Length == 0)
                {
                    // 入力値が何もなければ
                    InputBuffer.Append(Symbol.InverSign.Value() + ZERO);
                }
                else if (InputBuffer[0] == Symbol.InverSign.Value())
                {
                    // 入力値の先頭に "-" がある場合、先頭の "-" を除去
                    InputBuffer.Remove(0, 1);
                }
                else
                {
                    // 上記以外なら入力値の先頭に "-" を挿入
                    InputBuffer.Insert(0, Symbol.InverSign.Value());
                }
            }
            else if (input == Symbol.Period)
            {
                int dotIndex = InputBuffer.ToString().IndexOf(Symbol.Period.Value());
                if (dotIndex == -1)
                {
                    // 入力値の中に "." が見つからなければ、追加
                    InputBuffer.Append(Symbol.Period.Value());
                }
                else if (dotIndex == InputBuffer.Length - 1)
                {
                    // 末尾に "." があった場合は末尾の "." を除去
                    InputBuffer.Remove(dotIndex, 1);
                }
                // 上記以外は何もしない
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete()
        {
            if (0 < InputBuffer.Length)
            {
                InputBuffer.Remove(InputBuffer.Length - 1, 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            InputBuffer.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return InputBuffer.Length == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (InputBuffer.Length == 0)
            {
                return ZERO;
            }
            else
            {
                return InputBuffer.ToString();
            }
        }

    }

    /// <summary>
    /// カスタム属性
    /// </summary>
    class ValueAttribute : Attribute
    {
        /// <summary>値</summary>
        private char value;
        /// <summary>
        /// 新規にカスタム属性のインスタンスを構築します。
        /// </summary>
        /// <param name="value">値</param>
        public ValueAttribute(char value)
        {
            this.value = value;
        }
        /// <summary>
        /// 値
        /// </summary>
        public char Value
        {
            get
            {
                return this.value;
            }
        }
    }
    /// <summary>
    /// 記号のための enum Symbol の拡張クラス
    /// </summary>
    static class SymbolExtension
    {
        /// <summary>
        /// 記号 の enum が持っている値を返します。
        /// </summary>
        /// <param name="symbol">記号 の enum</param>
        /// <returns>記号 の enum が持っている値</returns>
        public static char Value(this Enum symbol)
        {
            Type type = symbol.GetType();
            string name = Enum.GetName(type, symbol);
            ValueAttribute attribute = (ValueAttribute)type.GetField(name).GetCustomAttribute(typeof(ValueAttribute), false);
            return attribute.Value;
        }
    }

}
