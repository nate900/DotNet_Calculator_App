namespace Calculator
{
    public partial class CalcForm : Form
    {
        private Calculator calc = new Calculator(); // calculator instance
        private string history = ""; // variable to hold previous operations performed
        private char[] operations = { '+', '-', '*', '/', '%' };
        public CalcForm()
        {
            InitializeComponent();
        }

        // start all numeric buttons
        private void btn_1_Click(object sender, EventArgs e)
        {
            current_input.Text += '1';
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            current_input.Text += '2';
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            current_input.Text += '3';
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            current_input.Text += '4';
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            current_input.Text += '5';
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            current_input.Text += '6';
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            current_input.Text += '7';
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            current_input.Text += '8';
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            current_input.Text += '9';
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            current_input.Text += '0';
        }
        // end all numeric buttons

        // start numeric operation buttons
        private void btn_dec_Click(object sender, EventArgs e)
        {
            current_input.Text += '.';
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            calc.Oper = operations[2];
            current_input.Text += operations[2];
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            calc.Oper = operations[3];
            current_input.Text += operations[3];
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            calc.Oper = operations[0];
            current_input.Text += operations[0];
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            calc.Oper = operations[1];
            current_input.Text += operations[1];
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            calc.Oper = operations[4];
            current_input.Text += operations[4];
        }
        // end numeric operation buttons

        // clears current math operation
        private void btn_clear_Click(object sender, EventArgs e)
        {
            current_input.Clear();
        }

        // clears all history
        private void button1_Click(object sender, EventArgs e)
        {
            history = ""; // reset the history string
            history_box.Text = ""; // reset history box
            math_box.Text = ""; // reset math box
        }

        // button that attempts to perform a math operation given the current input
        private void btn_enter_Click(object sender, EventArgs e)
        {
            // refer to the constructor of Calculator to learn what 'O' means
            if(calc.Oper == 'O')
            {
                for (int i = 0; i < operations.Length; i++)
                {
                    if (current_input.Text.Contains(operations[i]))
                    {
                        calc.Oper = operations[i];
                        break;
                    }
                }
            }

            // display error messages to the user if the user has not entered enough data
            if (current_input.Text.Equals(string.Empty) || current_input.Text.Length < 2)
            {
                // create an error form
                Form dialog = new Form();
                dialog.Text = "Error";

                // create a label to hold the error message
                Label l = new Label();
                l.Width = 300;
                l.Height = 50;
                l.Text = "Must enter a numeric operation.";
                dialog.Height = l.Height * 5;
                dialog.Width = l.Width * 2;
                l.Location = new Point((dialog.Width / 2) - (l.Width / 2), (dialog.Height / 2) - l.Height);

                // create a button so the user can close the dialog
                Button button = new Button();
                button.Text = "Close";
                button.Location = new Point((dialog.Width / 2) - (button.Width / 2), (dialog.Height / 2));
                button.Click += (sender, e) =>
                {
                    dialog.Close();
                };

                // add the controls to the form object and show the dialog
                dialog.Controls.Add(button);
                dialog.Controls.Add(l);
                dialog.ShowDialog();
                return;
            }
            // otherwise try to perform a math operation

            if(history != string.Empty) // first attempt of pressing enter button
            {
                history += ";" + current_input.Text;
            }
            else // every attempt after pressing the enter button
            {
                history = current_input.Text;
            }

            // get two strings representing the first numeric value and the second numeric value, seperating them using an operation symbol
            string[] numbers = { "", "" };
            numbers = current_input.Text.Split(calc.Oper); // split the current input into two strings delimited by the operation

            // if either number contains a '.' (decimal point) then parse them both to decimals. Otherwise, treat the operation as integers
            int[] integers = { 0, 0 };
            double[] decimals = { 0.0, 0.0 };
            bool isDec = false;
            if ((numbers[0].Contains('.') || numbers[1].Contains('.')) || calc.Oper == operations[3])
            {
                isDec = true;
                decimals[0] = Calculator.Parser.ParseDouble(numbers[0]);
                decimals[1] = Calculator.Parser.ParseDouble(numbers[1]);
            }
            else
            {
                integers[0] = Calculator.Parser.ParseInt(numbers[0]);
                integers[1] = Calculator.Parser.ParseInt(numbers[1]);
            }

            // perform the calculation and output the result to the user
            try
            {
                if (!isDec)
                {
                    history_box.Text = calc.operate(integers[0], integers[1]).ToString();
                }
                else
                {
                    history_box.Text = calc.operate(decimals[0], decimals[1]).ToString("F");
                }
            }catch(DivideByZeroException error)
            {
                System.Diagnostics.Debug.WriteLine(error.Message);
            }
            
                

            // set the math box equal to the operation trying to be performed
            math_box.Text = current_input.Text +  " = ";
            current_input.Text = "";


            /*print("n1 = " + numbers[0]);
            print("n2 = " + numbers[1]);
            print("History = " + history);
            print("Current input = " + current_input.Text);*/
        }

        private static void print(string s)
        {
            Console.WriteLine(s);
            System.Diagnostics.Debug.WriteLine(s);
        }

        
    }
}