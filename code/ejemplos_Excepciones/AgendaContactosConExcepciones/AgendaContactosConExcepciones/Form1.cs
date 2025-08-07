using System;
using System.Windows.Forms;

namespace AgendaContactosConExcepciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
                    throw new ArgumentException("Nombre y teléfono son obligatorios.");

                if (!long.TryParse(telefono, out _))
                    throw new FormatException("El teléfono debe ser numérico.");

                lstContactos.Items.Add($"{nombre} - {telefono}");

                txtNombre.Clear();
                txtTelefono.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
