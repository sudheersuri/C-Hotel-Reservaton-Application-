using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Casablanca
{
    public partial class checkinForm : Form
    {
        string title, firstName, lastName, address, city, country, postalCode, province, email, Phone, dateOfArrival, nights, noOfPeopleText;
        int noOfPeople,noOfNights;
        Boolean proceed;
        public checkinForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.FormBorderStyle=FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// bookBtn_Click function calls validatefields and books a room if no errors 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookBtn_Click(object sender, EventArgs e)
        {
            proceed = validateFields();
            if (proceed)
            {
                title = (string)titleComboBox.Text;
                city = (string)cityComboBox.Text;
                province = (string)provinceComboBox.Text;
                dateOfArrival = (string)arrivalDatePicker.Text;
                province = (string)provinceComboBox.Text;
                nights = (string)nightsTxtBox.Text;
                firstName = firstNameTxtBox.Text;
                lastName = lastNameTxtBox.Text;
                address = streetTxtBox.Text;
                noOfPeopleText = peopleComboBox.Text;
                try
                {
                    noOfPeople= int.Parse(peopleComboBox.Text);
                    noOfNights = int.Parse(nights);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(String.Concat("Conversion Failed due to ",exception.Message));
                }

                DateTime arrivaldate = arrivalDatePicker.Value;
                DateTime departureDate=arrivaldate.AddDays(noOfNights);

                if (noOfPeople==1)
                    msgLabel.Text = string.Concat("Hi ", title, " ", firstName, " ", lastName, ", Welcome to Casablanca, we booked a room \nwith California King Bed");
                else if (noOfPeople >= 1 && noOfPeople <= 4)
                    msgLabel.Text = string.Concat("Hi ", title, " ", firstName, " ", lastName, ", Welcome to Casablanca, we booked a room \n with 2 Queen Beds");
                else if (noOfPeople > 4)
                    msgLabel.Text = string.Concat("Hi ", title, " ", firstName, " ", lastName, ", Welcome to Casablanca, we booked a \nFamily Suite");

                msgLabel.Text = String.Concat(msgLabel.Text, "\n\nAccording  to your booking","\n\nYour date of arrival is ",arrivaldate,"\n\nYour departure date is ",departureDate);
                
                firstNameTxtBox.Text = String.Empty;
                lastNameTxtBox.Text = String.Empty;
                streetTxtBox.Text = String.Empty;
                phoneTxtBox.Text = String.Empty;
                countryTxtBox.Text = String.Empty;
                postalTxtBox.Text = String.Empty;
                emailTxtBox.Text = String.Empty;
                nightsTxtBox.Text = String.Empty;
                peopleComboBox.SelectedIndex = 0;
                countryTxtBox.Text = "Canada";
            }
     
        }
        /// <summary>
        /// validates all fields; checks their format, checks length of the field etc
        /// </summary>
        /// <returns>
        /// True, if all fields are given in right format 
        /// False, if atleast one field has wrong format
        /// </returns>
        private Boolean validateFields()
        {
            int check = 1;
            msgLabel.Text = String.Empty;
            if (firstNameTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nFirst Name can't be empty");
                firstNameTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if(hasNums(firstNameTxtBox.Text))
            {
                msgLabel.Text= string.Concat(msgLabel.Text, "\nFirst Name cant have Numbers");
                firstNameTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                firstNameTxtBox.BackColor = Color.White;
            }

            if (lastNameTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nLast Name can't be empty");
                lastNameTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if (hasNums(lastNameTxtBox.Text))
            {

                msgLabel.Text = string.Concat(msgLabel.Text, "\nLast Name cant have Numbers");
                lastNameTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                lastNameTxtBox.BackColor = Color.White;
            }
            if (streetTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nAddress cant be empty");
                streetTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                streetTxtBox.BackColor = Color.White;
            }
            
            if (countryTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nCountry cant be empty");
                countryTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if (hasNums(countryTxtBox.Text))
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nCountry cant have numbers");
                countryTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                countryTxtBox.BackColor = Color.White;
            }

            if (phoneTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nPhone number cant be empty ");
                phoneTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if (hasChars(phoneTxtBox.Text))
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nPhone number cant have alphabets");
                phoneTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if (phoneTxtBox.Text.Length!=10)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nPhone number must have 10 numbers");
                phoneTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                phoneTxtBox.BackColor = Color.White;
            }
            if (postalTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nPostal cant be empty");
                postalTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                postalTxtBox.BackColor = Color.White;
            }
            if (emailTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nEmail ID cant be empty");
                emailTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else if(!emailTxtBox.Text.Contains("@"))
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nEmail ID must have @");
                emailTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                emailTxtBox.BackColor = Color.White;
            }
            if (nightsTxtBox.Text == String.Empty)
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nNumber of nights must be entered");
                nightsTxtBox.BackColor = Color.Red;
                check = 0;
            }

            else if(hasChars(nightsTxtBox.Text))
            {
                msgLabel.Text = string.Concat(msgLabel.Text, "\nNumber of nights cannot have alphabets");

                nightsTxtBox.BackColor = Color.Red;
                check = 0;
            }
            else
            {
                nightsTxtBox.BackColor = Color.White;
            }

            if (check==1)
                return true;
            else
                return false;

        }
        /// <summary>
        /// hasChars function checks validates inputstring for alphabets
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns>
        /// True , if inputstring has characters
        /// False, if inputstring has no characters
        /// </returns>
        private Boolean hasChars(string inputstring)
        {
            string pattern = @"[a-zA-Z]";
            
            Match match = Regex.Match(inputstring, pattern);
            if (match.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// hasNums function checks validates inputstring for numbers
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns>
        /// True , if inputstring has numbers
        /// False, if inputstring has no numbers
        /// </returns>
        private Boolean hasNums(string inputstring)
        {
            string pattern = @"[0-9]";
            Match match = Regex.Match(inputstring, pattern);
            if (match.Success)
                return true;
            else
                return false;
        }       
    }    
}
