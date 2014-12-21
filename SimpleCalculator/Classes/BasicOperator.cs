
namespace SimpleCalculator.Classes
{
    /// <summary>
    /// 演算子のデリゲート
    /// </summary>
    /// <param name="a">変数 a</param>
    /// <param name="b">変数 b</param>
    /// <returns>演算結果</returns>
    delegate decimal Operator(decimal a, decimal b);

    /// <summary>
    /// 四則演算
    /// </summary>
    class BasicOperator
    {
        /// <summary>イコール「＝」</summary>
        public static Operator Equal = (a, b) => a;

        /// <summary>足し算の演算子</summary>
        public static Operator Add = (a, b) => a + b;
        /// <summary>引き算の演算子</summary>
        public static Operator Subtract = (a, b) => a - b;
        /// <summary>かけ算の演算子</summary>
        public static Operator Multiply = (a, b) => a * b;
        /// <summary>割り算の演算子</summary>
        public static Operator Divide = (a, b) => a / b;
    }

}
