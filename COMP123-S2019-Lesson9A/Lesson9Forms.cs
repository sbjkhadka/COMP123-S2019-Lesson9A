using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson9A
{
    public partial class Lesson9Forms : Form
    {
        public string outputString { get; set; }
        public float outputValue { get; set; }
        public bool decimalExists { get; set; }
        /// <summary>
        /// This is the constructor method
        /// </summary>
        public Lesson9Forms()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Shared event handler for all of the calculator button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorNumbers_Click(object sender, EventArgs e)
        {
            //downcasting sender object into a button object
            Button TheButton = sender as Button;
            var tag = TheButton.Tag.ToString();
            int NumericValue = 0;
            bool numericResult = int.TryParse(tag, out NumericValue);
            if (numericResult)
            {
                if (outputString == "0")
                {
                    outputString = tag;
                }
                else
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }    
            }
            else
            {
                switch (tag)
                {
                    case "back":
                        backButton();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                    case "clear":
                        clearNumericKeyboard();
                        break;
                    case "done":
                        finalizeOutput();
                        break;

                }
            }
            //ResultLabel.Text = selectedButton.Text;
            //switch (selectedButton.Text)
            //{
            //    case "1":
            //        ResultLabel.Text = "1";
            //        break;
            //    default:
            //        break;
            //}
            //try
            //{
            //    int.Parse(TheButton.Text);
            //    ResultLabel.Text = TheButton.Text;
            //}
            //catch
            //{
            //    ResultLabel.Text = "NaN";
            //}
        }

        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }

        private void finalizeOutput()
        {
            if (decimalExists)
            {
                outputString = outputString.Remove(outputString.IndexOf('.') + 2);
            }

            outputValue = float.Parse(outputString);
            if (outputValue < 0.1f)
            {
                outputValue = 0.1f;
            }
            heightLabel.Text = outputValue.ToString();
            clearNumericKeyboard();
            NumberButtonTableLayoutPanel.Visible = false;
        }

        private void backButton()
        {
            var lastChar = outputString.Substring(outputString.Length - 1);
            if (lastChar == ".")
            {
                decimalExists = false;
            }
            outputString.Remove(outputString.Length - 1);
            if (outputString.Length == 0)
            {
                outputString = "0";
            }
            ResultLabel.Text = outputString;
        }

        private void clearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = "0";
            outputValue = 0.0f;
            decimalExists = false;
        }

        private void Lesson9Forms_Load(object sender, EventArgs e)
        {
            clearNumericKeyboard();
        }
    }
}
