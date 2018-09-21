using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum operation {None, Plus, Minus, Multiply, Divide, Equals, Root, Factorial, Error};
        double currentNumber;
        double previousNumber;
        int decimalPlaces;
        char operationChar;
        operation currentOperation;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCalculator();

        }
        private void InitializeCalculator()
        {
            currentNumber = 0;
            previousNumber = 0;
            decimalPlaces = 0;
            currentOperation = operation.None;
            DisplayArea.Text = currentNumber.ToString();
        }
        private void Decimal(object sender, RoutedEventArgs e)
        {
            if (decimalPlaces > 0)
                return;
            decimalPlaces = 1;
            DisplayArea.Text = DisplayArea.Text + ".";
        }
        private void ClearEntry(object sender, RoutedEventArgs e)
        {
            currentNumber = 0;
            decimalPlaces = 0;
            UpdateDisplay();
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            InitializeCalculator();
        }
        private void PlusButton(object sender, RoutedEventArgs e)
        {
            operationChar = '+';
            Equals(operation.Plus);
        }
        private void MinusButton(object sender, RoutedEventArgs e)
        {
            operationChar = '-';
            Equals(operation.Minus);
        }
        private void MultiplyButton(object sender, RoutedEventArgs e)
        {
            operationChar = '*';
            Equals(operation.Multiply);
        }
        private void DivideButton(object sender, RoutedEventArgs e)
        {
            operationChar = '/';
            Equals(operation.Divide);
        }
        private void EqualsButton(object sender, RoutedEventArgs e)
        {
            Equals(operation.Equals);
        }
        private void Equals(operation nextOp)
        {
            switch (currentOperation)
            {
                case operation.None:
                    previousNumber = currentNumber;
                    break;
                case operation.Equals:
                    break;
                case operation.Plus:
                    previousNumber = previousNumber + currentNumber;
                    break;
                case operation.Minus:
                    previousNumber = previousNumber - currentNumber;
                    break;
                case operation.Multiply:
                    previousNumber = previousNumber * currentNumber;
                    break;
                case operation.Divide:
                    previousNumber = previousNumber / currentNumber;
                    break;
                case operation.Factorial:
                    previousNumber = Factorial(previousNumber);
                    break;
                case operation.Root:
                    previousNumber = Math.Sqrt(previousNumber);
                    break;
            }
            if (currentOperation != operation.Equals)
                currentNumber = 0;
            decimalPlaces = 0;
            currentOperation = nextOp;
            UpdateDisplay();
        }
        private void Number0(object sender, RoutedEventArgs e)
        {
            NumberButton(0);
        }
        private void Number1(object sender, RoutedEventArgs e)
        {
            NumberButton(1);
        }
        private void Number2(object sender, RoutedEventArgs e)
        {
            NumberButton(2);
        }
        private void Number3(object sender, RoutedEventArgs e)
        {
            NumberButton(3);
        }
        private void Number4(object sender, RoutedEventArgs e)
        {
            NumberButton(4);
        }
        private void Number5(object sender, RoutedEventArgs e)
        {
            NumberButton(5);
        }
        private void Number6(object sender, RoutedEventArgs e)
        {
            NumberButton(6);
        }
        private void Number7(object sender, RoutedEventArgs e)
        {
            NumberButton(7);
        }
        private void Number8(object sender, RoutedEventArgs e)
        {
            NumberButton(8);
        }
        private void Number9(object sender, RoutedEventArgs e)
        {
            NumberButton(9);
        }
        private void NumberButton(int input)
        {
            if (decimalPlaces < 1)
                currentNumber = currentNumber * 10 + input;
            else
            {
                currentNumber = currentNumber + (input / Math.Pow(10.0,decimalPlaces));
                decimalPlaces++;
            }

            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            if (currentOperation == operation.Error)
            {
                InitializeCalculator();
                DisplayArea.Text = "Error";
            }
                
            else if (currentOperation == operation.None)
                DisplayArea.Text = currentNumber.ToString();
            else if (currentOperation == operation.Equals)
                DisplayArea.Text = previousNumber.ToString();
            else
                DisplayArea.Text = previousNumber.ToString() + ' ' + operationChar + ' ' + currentNumber.ToString();
        }

        private void RootButton(object sender, RoutedEventArgs e)
        {
            Equals(operation.Root);
            if (previousNumber < 0)
            {
                InitializeCalculator();
                currentOperation = operation.Error;
                UpdateDisplay();
            }
            else
            {
                Equals(operation.Equals);
            }


        }
        private void FactorialButton(object sender, RoutedEventArgs e)
        {
            Equals(operation.Factorial);
            if (previousNumber % 1 > 0 || previousNumber < 0)
            {
                InitializeCalculator();
                currentOperation = operation.Error;
                UpdateDisplay();
            }
            else
            {
                Equals(operation.Equals);
            }
        }

        private double Factorial(double num)
        {
            if (num > 1)
                return num * Factorial(num - 1);
            else
                return 1;
        }
    }
}
