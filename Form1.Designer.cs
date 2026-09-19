using System.Drawing;
using System.Windows.Forms;

namespace quanlysinhvien
{
    partial class Form1
    {
        private TextBox txtDisplay = null!;

        private void InitializeComponent()
        {
            Text = "Calculator";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(280, 350);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            txtDisplay = new TextBox
            {
                Location = new Point(15, 15),
                Size = new Size(250, 40),
                Font = new Font("Segoe UI", 18),
                Text = "0",
                TextAlign = HorizontalAlignment.Right
            };
            Controls.Add(txtDisplay);

            string[,] labels =
            {
                { "7", "8", "9", "÷" },
                { "4", "5", "6", "×" },
                { "1", "2", "3", "-" },
                { "0", "C", "=", "+" }
            };

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    Button button = new Button
                    {
                        Text = labels[row, column],
                        Size = new Size(55, 50),
                        Location = new Point(15 + column * 62, 75 + row * 60),
                        Font = new Font("Segoe UI", 12)
                    };
                    button.Click += Button_Click;
                    Controls.Add(button);
                }
            }
        }
    }
}