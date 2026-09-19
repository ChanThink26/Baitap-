using System.Globalization;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class Form1 : Form
    {
        private double? firstNumber;
        private string? operation;
        private bool startNewNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button) return;
            string text = button.Text;

            if (double.TryParse(text, out _))
            {
                if (startNewNumber || txtDisplay.Text == "0")
                {
                    txtDisplay.Text = text;
                    startNewNumber = false;
                }
                else
                {
                    txtDisplay.Text += text;
                }
                return;
            }

            if (text == "C")
            {
                ClearCalculator();
                return;
            }

            if (text == "=")
            {
                CalculateResult();
                return;
            }

            if (!double.TryParse(txtDisplay.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
            {
                ShowInvalidInput();
                return;
            }

            firstNumber = number;
            operation = text;
            startNewNumber = true;
        }

        private void CalculateResult()
        {
            if (firstNumber is null || operation is null) return;

            if (!double.TryParse(txtDisplay.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out double secondNumber))
            {
                ShowInvalidInput();
                return;
            }

            double result;
            switch (operation)
            {
                case "+": result = firstNumber.Value + secondNumber; break;
                case "-": result = firstNumber.Value - secondNumber; break;
                case "×": result = firstNumber.Value * secondNumber; break;
                case "÷":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearCalculator();
                        return;
                    }
                    result = firstNumber.Value / secondNumber;
                    break;
                default: return;
            }

            txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
            firstNumber = null;
            operation = null;
            startNewNumber = true;
        }

        private void ClearCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = null;
            operation = null;
            startNewNumber = false;
        }

        private void ShowInvalidInput()
        {
            MessageBox.Show("Please enter a valid number.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ClearCalculator();
        }
    }
}
