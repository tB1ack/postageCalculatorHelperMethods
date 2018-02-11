using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace challengePostageCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                resultLabel.Text = "";
            }
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataCheck();
        }

        private void dataCheck()
        {
            if (widthTextBox.Text != "" && heightTextBox.Text != "" && (groundRadioButton.Checked || airRadioButton.Checked || nextDayRadioButton.Checked))
            {
                determineSize();
            }
        }

        private void determineSize()
        {
            int size = 0;

            if (int.TryParse(lengthTextBox.Text, out int length))
            {
                if (!int.TryParse(widthTextBox.Text, out int width) || !int.TryParse(heightTextBox.Text, out int height))
                {
                    return;
                }

                size = width * height * length;
            }
            else
            {
                if (!int.TryParse(widthTextBox.Text, out int width) || !int.TryParse(heightTextBox.Text, out int height))
                {
                    return;
                }

                size = width * height;
            }

            calculatePostage(size);
            
        }

        private void calculatePostage(int volume)
        {
            double postalCost = 1;

            if (groundRadioButton.Checked)
            {
                postalCost = volume *.15;
            }
            else if (airRadioButton.Checked)
            {
                postalCost = volume * .25;
            }
            else if (nextDayRadioButton.Checked)
            {
                postalCost = volume * .45;
            }
            printPostage(postalCost);
            
        }

        private void printPostage(double cost)
        {
            resultLabel.Text = String.Format("Your parcel will cost ${0:N2} to ship.", cost);
        }

    }

}