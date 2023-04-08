using ComplexLibrary;
using System.CodeDom;

namespace ComplexWinForms
{
    public partial class Form1 : Form
    {
        public ComplexNumber FirstNumber { get; set; } = new ComplexNumber(0, 0);
        public ComplexNumber SecondNumber { get; set; } = new ComplexNumber(0, 0);
        public Operation Operator { get; set; } = Operation.Add;
        public ComplexNumber Result { get; set; } = new ComplexNumber(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate()
        {
            FirstNumber = ComplexNumber.TryParse(textBox1.Text);
            SecondNumber = ComplexNumber.TryParse(textBox2.Text);
            Result = ComplexCalculator.Calculate(FirstNumber, SecondNumber, Operator);
            textBox3.Text = Result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operator = Operation.Add;
            Calculate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Operator = Operation.Subtract;
            Calculate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Operator = Operation.Multiply;
            Calculate();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Operator = Operation.Divide;
            Calculate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            FirstNumber = new ComplexNumber(0, 0);
            SecondNumber = new ComplexNumber(0, 0);
            Result = new ComplexNumber(0, 0);
        }
    }
}