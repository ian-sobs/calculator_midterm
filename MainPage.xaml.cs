namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string input = ""; // the number you inputted in the calculator as a string 

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
                input += button.CommandParameter.ToString();
                calcOutput.Text += button.CommandParameter.ToString();

                
            }
        }

        public void handleOperation()
        {

        }


    }

}
