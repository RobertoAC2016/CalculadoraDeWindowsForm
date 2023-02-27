namespace CalculadoraEnWinForms
{
    public partial class Calculadora : Form
    {
        private List<Operacion> operaciones = new List<Operacion>();
        private Operacion operacion = new Operacion();
        private bool haypunto = false;
        public Calculadora()
        {
            InitializeComponent();
            label1.Text = "";
        }
        #region NUMEROS
        private void btn7_Click(object sender, EventArgs e)
        {
            reformateo(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            reformateo(8);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            reformateo(9);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            reformateo(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            reformateo(5);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            reformateo(6);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            reformateo(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            reformateo(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            reformateo(3);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            reformateo(0);
        }
        #endregion
        private void reformateo(int numero)
        {
            if (haypunto)
            {
                txtinput.Text += ",";
                haypunto = false;
            }
            txtinput.Text += numero.ToString();
            if (operacion.operador == null)
                operacion.num1 = double.Parse(txtinput.Text);
            else
                operacion.num2 = double.Parse(txtinput.Text);
        }
        private void btnigual_Click(object sender, EventArgs e)
        {
            //Aqui se realizara la operacion de la calculadora
            operacion.num2 = double.Parse(txtinput.Text);
            var res = 0.0;
            switch (operacion.operador)
            {
                case "/": res = operacion.num1 / operacion.num2; break;
                case "*": res = operacion.num1 * operacion.num2; break;
                case "+": res = operacion.num1 + operacion.num2; break;
                case "-": res = operacion.num1 - operacion.num2; break;
            }
            operacion.res = res;
            label1.Text = $"{operacion.num1}{operacion.operador}{operacion.num2}={res}";
            txtinput.Text = "";
            //Para el historico de operaciones
            operaciones.Add(operacion);
            operacion = new Operacion();
        }
        private void btndot_Click(object sender, EventArgs e)
        {
            //var txt = txtinput.Text ?? "";
            //if (!txt.Trim().Contains(".")) txtinput.Text += "."; ;
            if (operacion.operador == null)
                label1.Text = $"{operacion.num1}.0{operacion.operador ?? " "}{operacion.num2}={operacion.res}";
            else
                label1.Text = $"{operacion.num1}{operacion.operador ?? " "}{operacion.num2}.0={operacion.res}";
            haypunto = true;
        }
        private void btndiv_Click(object sender, EventArgs e)
        {
            label1.Text = $"{operacion.num1}{operacion.operador ?? " "}{operacion.num2}={operacion.res}";
            txtinput.Text = "";
            operacion.operador = "/";
        }
        private void btnx_Click(object sender, EventArgs e)
        {
            label1.Text = $"{operacion.num1}{operacion.operador ?? " "}{operacion.num2}={operacion.res}";
            txtinput.Text = "";
            operacion.operador = "*";
        }
        private void btnresta_Click(object sender, EventArgs e)
        {
            label1.Text = $"{operacion.num1}{operacion.operador ?? " "}{operacion.num2}={operacion.res}";
            txtinput.Text = "";
            operacion.operador = "-";
        }
        private void btnplus_Click(object sender, EventArgs e)
        {
            label1.Text = $"{operacion.num1}{operacion.operador??" "}{operacion.num2}={operacion.res}";
            txtinput.Text = "";
            operacion.operador = "+";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtinput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtinput.Text = (txtinput.Text.Length > 0) ? txtinput.Text.Substring(0, txtinput.Text.Length-1) : string.Empty;
            if (operacion.operador == null)
                operacion.num1 = double.Parse(txtinput.Text);
            else
                operacion.num2 = double.Parse(txtinput.Text);
            label1.Text = $"{operacion.num1}{operacion.operador ?? " "}{operacion.num2}={operacion.res}";
        }
    }
    public class Operacion
    {
        public double num1 { get; set; }
        public String operador { get; set; }
        public double num2 { get; set; }
        public double res { get; set; }
    }
}
