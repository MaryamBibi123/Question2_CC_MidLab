using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Question2_CC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string registrationNumber = regNumberTextBox.Text; // Registration number input
            string firstName = firstNameTextBox.Text; // First name input
            string lastName = lastNameTextBox.Text; // Last name input
            string favoriteMovie = favMovieTextBox.Text; // Favorite movie input

            // Validate inputs
            if (registrationNumber.Length < 2 || firstName.Length < 2 || lastName.Length < 2 || favoriteMovie.Length < 2)
            {
                MessageBox.Show("Please provide valid inputs.");
                return;
            }

            // Extract required characters
            string regDigits = Regex.Match(registrationNumber, @"\d{2}").Value; // First two digits
            char secondFirstNameLetter = firstName.Length >= 2 ? firstName[1] : 'X'; // Second letter
            char secondLastNameLetter = lastName.Length >= 2 ? lastName[1] : 'X'; // Second letter
            string movieChars = favoriteMovie.Substring(0, 2); // First two letters of favorite movie

            // Special characters, excluding '#'
            string specialChars = "!$%&*@^";
            Random rand = new Random();
            char special1 = specialChars[rand.Next(specialChars.Length)];
            char special2 = specialChars[rand.Next(specialChars.Length)];

            // Combine parts to form the password
            StringBuilder passwordBuilder = new StringBuilder();
            passwordBuilder.Append(regDigits);
            passwordBuilder.Append(secondFirstNameLetter);
            passwordBuilder.Append(secondLastNameLetter);
            passwordBuilder.Append(movieChars);
            passwordBuilder.Append(special1);
            passwordBuilder.Append(special2);

            // Add random letters to meet the length of 14 characters
            while (passwordBuilder.Length < 14)
            {
                char randChar = (char)rand.Next(65, 91); // Random uppercase letter
                passwordBuilder.Append(randChar);
            }

            // Shuffle the password
            string password = new string(passwordBuilder.ToString().OrderBy(x => rand.Next()).ToArray());

            // Display the password
            passwordTextBox.Text = password;
        }

      
    }
}
