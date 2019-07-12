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
    public partial class CalculatorForm : Form
    {
        //class properties
        public string outputString { get; set; }
        public float outputValue { get; set; }
        public bool decimalExists { get; set; }
        /// <summary>
        /// This is the constructor method
        /// </summary>
        public CalculatorForm()
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
            int numericValue = 0;
            bool numericResult = int.TryParse(tag, out numericValue);
            if (numericResult)
            {
                int maxSize = (decimalExists) ? 5 : 3;
                if (outputString == "0")
                {
                    outputString = tag;
                }
                else
                {
                    if (outputString.Length < maxSize)
                    {
                        outputString += tag;
                    }  
                }
                ResultLabel.Text = outputString;
            }
            else
            {
                switch (tag)
                {
                    case "back":
                        RemoveLastCharacterFromResultLabel();
                        break;
                    case "done":
                        finalizeOutput();
                        break;
                    case "clear":
                        ClearNumericKeyboard();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }   
        }

        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }
        /// <summary>
        /// finalizes and converts the output string to floating point value
        /// </summary>
        private void finalizeOutput()
        {
            //if (decimalExists)
            //{
            //    int charactersToRemove = (outputString.IndexOf('.') + 2 <= outputString.Length)? 
            //        outputString.IndexOf('.') + 2: outputString.IndexOf('.') + 1;
              
            //    outputString = outputString.Remove(charactersToRemove);
            //}

            outputValue = float.Parse(outputString);
            outputValue = (float)Math.Round(outputValue, 1);
            if (outputValue < 0.1f)
            {
                outputValue = 0.1f;
            }
            heightLabel.Text = outputValue.ToString();
            //ClearNumericKeyboard();
            NumberButtonTableLayoutPanel.Visible = false;
        }
        /// <summary>
        /// removes the last character from the the result label
        /// </summary>
        private void RemoveLastCharacterFromResultLabel()
        {
            var lastChar = outputString.Substring(outputString.Length - 1);
            if (lastChar == ".")
            {
                decimalExists = false;
            }
            outputString = outputString.Remove(outputString.Length - 1);
            if (outputString.Length == 0)
            {
                outputString = "0";
            }
            ResultLabel.Text = outputString;
        }

        /// <summary>
        /// Resets the numeric keyboard and related variables
        /// </summary>
        private void ClearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = "0";
            outputValue = 0.0f;
            decimalExists = false;
        }
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            ClearNumericKeyboard();
            //NumberButtonTableLayoutPanel.Visible = false;
        }
       
      
        /// <summary>
        /// event handler for height label click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heightLabel_Click(object sender, EventArgs e)
        {
            NumberButtonTableLayoutPanel.Visible = true;
        }
    }
}
