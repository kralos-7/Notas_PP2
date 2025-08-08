using System;
using System.IO;
using System.Windows.Forms;

namespace EditorTextoWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtContenido.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtContenido.Text);
                MessageBox.Show("Archivo guardado correctamente");
            }
        }
    }
}
