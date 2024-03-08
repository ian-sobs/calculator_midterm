namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string input = ""; // the number you inputted in the calculator as a string 
        char operation = (char)0;
        float lOperand, rOperand;

        public MainPage()
        {
            InitializeComponent();
        }

        public void handleClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if(calcOutput.Text == "0")
                {
                    calcOutput.Text = "";
                }
                // Extract the value associated with the clicked button
                calcOutput.Text += button.CommandParameter.ToString();
                input += button.CommandParameter.ToString();
                

                if(operation != (char)0)
                {
                    rOperand = float.Parse(input);
                }
                else
                {
                    lOperand = float.Parse(input);
                }
            }
        }

        public void HandleOperation(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                calcOutput.Text = "0";
                string opString = button.CommandParameter.ToString();
                operation = opString[0]; 
            }
        }

        public void ClearOutput(object sender, EventArgs e)
        {
            calcOutput.Text = "0";
            input = "";
        }


    }

}
