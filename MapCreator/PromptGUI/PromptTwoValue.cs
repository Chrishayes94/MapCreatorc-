using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapCreator.PromptGUI
{
    public class PromptTwoValue
    {
        public struct Values
        {
            public decimal Width;
            public decimal Height;

            public Values(decimal w, decimal hy)
            {
                this.Width = w;
                this.Height = hy;
            }
        }

        public static Values ShowDialog(string text, string caption)
        {
            return ShowDialog(text, caption, 0, 0);
        }

        public static Values ShowDialog(string text, string caption, int currentWidth, int currentHeight)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 175;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 150, Maximum = 4096, Value = currentWidth };
            NumericUpDown inputBox2 = new NumericUpDown() { Left = 250, Top = 50, Width = 150, Maximum = 4096, Value = currentHeight };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(inputBox2);
            prompt.ShowDialog();
            return new Values(inputBox.Value, inputBox2.Value);
        }
    }
}
