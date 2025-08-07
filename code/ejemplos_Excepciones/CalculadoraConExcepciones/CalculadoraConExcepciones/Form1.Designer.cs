namespace CalculadoraConExcepciones
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.ComboBox cmbOperacion;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtNumero1.Location = new System.Drawing.Point(30, 30);
            this.txtNumero1.Size = new System.Drawing.Size(100, 22);

            this.txtNumero2.Location = new System.Drawing.Point(180, 30);
            this.txtNumero2.Size = new System.Drawing.Size(100, 22);

            this.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperacion.Items.AddRange(new object[] { "+", "-", "*", "/" });
            this.cmbOperacion.Location = new System.Drawing.Point(135, 30);
            this.cmbOperacion.Size = new System.Drawing.Size(40, 24);

            this.btnCalcular.Location = new System.Drawing.Point(30, 70);
            this.btnCalcular.Size = new System.Drawing.Size(250, 30);
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            this.lblResultado.Location = new System.Drawing.Point(30, 120);
            this.lblResultado.Size = new System.Drawing.Size(250, 25);
            this.lblResultado.Text = "Resultado: ";

            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.cmbOperacion);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblResultado);
            this.Text = "Calculadora con Excepciones";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
