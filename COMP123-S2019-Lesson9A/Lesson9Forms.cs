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
            Button selectedButton = sender as Button;
            //ResultLabel.Text = selectedButton.Text;
            //switch (selectedButton.Text)
            //{
            //    case "1":
            //        ResultLabel.Text = "1";
            //        break;
            //    default:
            //        break;
            //}
            try
            {
                int.Parse(selectedButton.Text);
                ResultLabel.Text = selectedButton.Text;
            }
            catch
            {
                ResultLabel.Text = "NaN";
            }
        }
    }
}
