using System;
using System.Windows.Forms;

namespace CalculadoraConExcepciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtNumero1.Text);
                double num2 = double.Parse(txtNumero2.Text);
                string op = cmbOperacion.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(op))
                    throw new Exception("Seleccione una operación.");

                double resultado;

                switch (op)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                            throw new DivideByZeroException("No se puede dividir entre cero.");
                        resultado = num1 / num2;
                        break;
                    default:
                        throw new Exception("Operación no válida.");
                }

                lblResultado.Text = $"Resultado: {resultado}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese números válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "División inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
