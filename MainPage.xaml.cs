namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string input = ""; // the number you inputted in the calculator as a string 
        char operation = (char)0;
        float lOperand, rOperand;
        bool pointSet = false;

        public MainPage()
        {
            InitializeComponent();
        }

        public void handleClick(object sender, EventArgs e)
        {

            if (sender is Button button)
            {
                string num = button.CommandParameter.ToString();
     /*           if (operation != (char)0)
                {*/
                    calcOutput.Text = "";
              /*  }*/
                // Extract the value associated with the clicked button

                if (input != "0")
                {
                    if (num == "." && !pointSet)
                    {
                        pointSet = true;
                        if (calcOutput.Text == "0" || input == "")
                        {
                            input = "0";
                        }
                        input += num;
                    }
                    else if (num != ".")
                    {
                        input += num;
                    }
                }
                else if (num != "0")
                {
                    if (num == "." && !pointSet)
                    {
                        pointSet = true;
                        input += num;
                    }
                    else if (num != ".")
                    {
                        input = num;
                    }
                }
                calcOutput.Text = input;

                if (operation != (char)0 && input[input.Length - 1] != '.' && !string.IsNullOrEmpty(input))
                {

                    rOperand = float.Parse(input);
                }
                else if(operation == (char)0 && input[input.Length - 1] != '.' && !string.IsNullOrEmpty(input))
                {
                    lOperand = float.Parse(input);
                }
            }
        }

        public void HandleOperation(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                pointSet = false;
                if(operation != (char)0)
                {
                    calculate();
                    calcOutput.Text = Convert.ToString(lOperand);
                }
                else
                {
                    calcOutput.Text = "0";
                }
                
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
            pointSet = false;
        }

        public void OpEval(object sender, EventArgs e)
        {
            calculate();
            rOperand = 0;
            input = "";
            operation = (char)0;
            calcOutput.Text = Convert.ToString(lOperand);
        }

        public void calculate()
        {
            switch (operation)
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
            lOperand = (float)Math.Round(lOperand, 4);
        }

        public void DeleteNum(object sender, EventArgs e)
        {
            if(calcOutput.Text != "0")
            {
                int inputLength = input.Length;
                char lastChar = '\0';
                if(inputLength > 0)
                {
                    lastChar = input[inputLength - 1];
                    input = input.Remove(inputLength - 1);
                }
                

                if (lastChar == '.')
                {
                    pointSet = false;
                }

                
                if(input.Length > 0){
                    calcOutput.Text = input;
                }
                else
                {
                    calcOutput.Text = "0";
                }

                if (operation != (char)0 && input.Length > 0 && input[input.Length - 1] != '.')
                {

                    rOperand = float.Parse(input);
                }
                else if (operation == (char)0 && input.Length > 0 && input[input.Length - 1] != '.')
                {
                    lOperand = float.Parse(input);
                }
            }
        }

    }

}
