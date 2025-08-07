namespace AgendaContactosConExcepciones
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lstContactos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstContactos = new System.Windows.Forms.ListBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblNombre.Size = new System.Drawing.Size(100, 20);

            this.txtNombre.Location = new System.Drawing.Point(100, 20);
            this.txtNombre.Size = new System.Drawing.Size(180, 22);

            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(30, 60);
            this.lblTelefono.Size = new System.Drawing.Size(100, 20);

            this.txtTelefono.Location = new System.Drawing.Point(100, 60);
            this.txtTelefono.Size = new System.Drawing.Size(180, 22);

            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(100, 100);
            this.btnAgregar.Size = new System.Drawing.Size(180, 30);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.lstContactos.Location = new System.Drawing.Point(30, 150);
            this.lstContactos.Size = new System.Drawing.Size(250, 150);

            this.ClientSize = new System.Drawing.Size(320, 330);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lstContactos);
            this.Text = "Agenda de Contactos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
