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

                if (input != "0")
                {
                    calcOutput.Text += button.CommandParameter.ToString();
                    input += button.CommandParameter.ToString();
                }
                

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
                input = "";
                string opString = button.CommandParameter.ToString();
                operation = opString[0]; 
            }
        }

        public void ClearOutput(object sender, EventArgs e)
        {
            calcOutput.Text = "0";
            input = "";
            operation = (char)0;
            lOperand = rOperand = 0;
        }

        public void OpEval(object sender, EventArgs e)
        {
            switch(operation)
            {
                case '+':
                    lOperand += rOperand;
                    break;
                case '-':
                    lOperand -= rOperand;
                    break;
                case 'X':
                    lOperand *= rOperand;
                    break;
                case '/':
                    lOperand /= rOperand;
                    break;    
            }
            rOperand = 0;
            
            calcOutput.Text = Convert.ToString(lOperand);
        }

    }

}
