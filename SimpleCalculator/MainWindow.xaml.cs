using SimpleCalculator.Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary></summary>
        private BasicCalculator calc;

        /// <summary></summary>
        private Dictionary<string, Operator> operatorDics;
        /// <summary></summary>
        private Dictionary<string, Value.Symbol> symbolDics;

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            calc = new BasicCalculator();
            textBox.Text = calc.Clear();

            operatorDics = new Dictionary<string, Operator>();
            operatorDics.Add("button_equal", BasicOperator.Equal);
            operatorDics.Add("button_add", BasicOperator.Add);
            operatorDics.Add("button_subtract", BasicOperator.Subtract);
            operatorDics.Add("button_multiply", BasicOperator.Multiply);
            operatorDics.Add("button_divide", BasicOperator.Divide);

            symbolDics = new Dictionary<string, Value.Symbol>();
            symbolDics.Add("button_sign", Value.Symbol.InverSign);
            symbolDics.Add("button_dot", Value.Symbol.Period);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickNumberButton(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(((Button)sender).Content.ToString());
            textBox.Text = calc.AddInput(n);
            textBox.ToolTip = textBox.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickOperatorButton(object sender, RoutedEventArgs e)
        {
            string name = ((FrameworkElement)sender).Name;
            Operator ope;
            bool isExists = operatorDics.TryGetValue(name, out ope);
            if (isExists)
            {
                textBox.Text = calc.SetOperator(ope);
                textBox.ToolTip = textBox.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickSymbolButton(object sender, RoutedEventArgs e)
        {
            string name = ((FrameworkElement)sender).Name;
            Value.Symbol symbol;
            bool isExists = symbolDics.TryGetValue(name, out symbol);
            if (isExists)
            {
                textBox.Text = calc.AddInput(symbol);
                textBox.ToolTip = textBox.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickControlButton(object sender, RoutedEventArgs e)
        {
            string name = ((FrameworkElement)sender).Name;

            if (name == "button_del")
            {
                textBox.Text = calc.Delete();
            }
            else if (name == "button_clear")
            {
                textBox.Text = calc.Clear();
            }
            textBox.ToolTip = textBox.Text;
        }
    }
}
