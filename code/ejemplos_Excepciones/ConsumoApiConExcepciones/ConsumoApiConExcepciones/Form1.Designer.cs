namespace ConsumoApiConExcepciones
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnConsumir;
        private System.Windows.Forms.TextBox txtResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnConsumir = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            this.btnConsumir.Location = new System.Drawing.Point(30, 70);
            this.btnConsumir.Size = new System.Drawing.Size(200, 30);
            this.btnConsumir.Text = "Consultar Pokémon";
            this.btnConsumir.Click += new System.EventHandler(this.btnConsumir_Click);

            this.txtResultado.Location = new System.Drawing.Point(30, 30);
            this.txtResultado.Size = new System.Drawing.Size(200, 20);
            this.txtResultado.PlaceholderText = "Nombre del Pokémon";

            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.btnConsumir);
            this.Controls.Add(this.txtResultado);
            this.Text = "API Pokémon";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
