namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string input = ""; // the number you inputted in the calculator as a string 
        char lastOperation = ' ';

        public MainPage()
        {
            InitializeComponent();
        }

        public void handleClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (calcOutput.Text == "0" && button.Text != ".")
                {
                    calcOutput.Text = "";
                }

                // Extract the value associated with the clicked button
                calcOutput.Text += button.Text;

                if (button.Text != ".")
                {
                    input += button.Text;
                }
                else
                {
                    if (!input.Contains("."))
                    {
                        input += button.Text;
                    }
                }
            }
        }

        public void HandleOperation(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Store the operation
                lastOperation = button.Text[0];

                // Store the current input
                input += " " + lastOperation + " ";

                // Update the display
                calcOutput.Text = input;
            }
        }

        public void Calculate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    var result = new System.Data.DataTable().Compute(input, null);
                    calcOutput.Text = result.ToString();
                    input = result.ToString();
                }
                catch (Exception ex)
                {
                    calcOutput.Text = "Error";
                }
            }
        }

        public void ClearOutput(object sender, EventArgs e)
        {
            calcOutput.Text = "0";
            input = "";
        }

        public void DeleteLastCharacter(object sender, EventArgs e)
        {
            if (calcOutput.Text != "0" && !string.IsNullOrEmpty(calcOutput.Text))
            {
                calcOutput.Text = calcOutput.Text.Remove(calcOutput.Text.Length - 1);
                input = input.Remove(input.Length - 1);
            }

            if (string.IsNullOrEmpty(calcOutput.Text))
            {
                calcOutput.Text = "0";
            }
        }
    }
}