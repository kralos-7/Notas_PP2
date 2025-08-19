using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Agenda
{
    public class Contacto
    {
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Email { get; set; } = "";
        public string Notas { get; set; } = "";
    }

    public partial class Form1 : Form
    {
        // UI
        TextBox txtNombre, txtTelefono, txtEmail, txtNotas, txtBuscar;
        Button btnNuevo, btnAgregar, btnActualizar, btnEliminar, btnGuardar, btnCargar, btnExportarPDF;
        DataGridView grid;

        // Datos en memoria
        List<Contacto> contactos = new();

        string RutaDatos => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "agenda.json");

        public Form1()
        {
            // ⚡ IMPORTANTE: configurar licencia Community (gratuita)
            QuestPDF.Settings.License = LicenseType.Community;

            Text = "Agenda Minimalista";
            Width = 840;
            Height = 560;
            StartPosition = FormStartPosition.CenterScreen;

            // Buscar
            var lblBuscar = new Label { Text = "Buscar:", Left = 12, Top = 14, AutoSize = true };
            txtBuscar = new TextBox { Left = 70, Top = 10, Width = 280 };
            txtBuscar.TextChanged += (s, e) => RefrescarGrid();

            // Grid
            grid = new DataGridView
            {
                Left = 12,
                Top = 40,
                Width = 800,
                Height = 280,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false
            };
            grid.CellClick += (s, e) => CargarSeleccionEnFormulario();

            // Labels & TextBoxes
            int leftLabel = 12, leftInput = 100, topBase = 330, sep = 32, inputW = 320;

            var lblNombre = new Label { Left = leftLabel, Top = topBase + sep * 0, Text = "Nombre:", AutoSize = true };
            txtNombre = new TextBox { Left = leftInput, Top = topBase + sep * 0, Width = inputW };

            var lblTelefono = new Label { Left = leftLabel, Top = topBase + sep * 1, Text = "Teléfono:", AutoSize = true };
            txtTelefono = new TextBox { Left = leftInput, Top = topBase + sep * 1, Width = inputW };

            var lblEmail = new Label { Left = leftLabel, Top = topBase + sep * 2, Text = "Email:", AutoSize = true };
            txtEmail = new TextBox { Left = leftInput, Top = topBase + sep * 2, Width = inputW };

            var lblNotas = new Label { Left = leftLabel, Top = topBase + sep * 3, Text = "Notas:", AutoSize = true };
            txtNotas = new TextBox { Left = leftInput, Top = topBase + sep * 3, Width = inputW };

            // Botones
            int leftBtn = 450, topBtn = topBase, btnW = 150, btnH = 30, bSep = 36;
            btnNuevo = new Button { Left = leftBtn, Top = topBtn + bSep * 0, Width = btnW, Height = btnH, Text = "Nuevo" };
            btnAgregar = new Button { Left = leftBtn, Top = topBtn + bSep * 1, Width = btnW, Height = btnH, Text = "Agregar" };
            btnActualizar = new Button { Left = leftBtn, Top = topBtn + bSep * 2, Width = btnW, Height = btnH, Text = "Actualizar" };
            btnEliminar = new Button { Left = leftBtn, Top = topBtn + bSep * 3, Width = btnW, Height = btnH, Text = "Eliminar" };

            btnGuardar = new Button { Left = leftBtn + 180, Top = topBtn + bSep * 1, Width = btnW, Height = btnH, Text = "Guardar JSON" };
            btnCargar = new Button { Left = leftBtn + 180, Top = topBtn + bSep * 2, Width = btnW, Height = btnH, Text = "Cargar JSON" };
            btnExportarPDF = new Button { Text = "Exportar PDF", Left = leftBtn, Top = topBtn + bSep * 4, Width = btnW, Height = btnH };

            btnNuevo.Click += (s, e) => LimpiarFormulario();
            btnAgregar.Click += (s, e) => Agregar();
            btnActualizar.Click += (s, e) => Actualizar();
            btnEliminar.Click += (s, e) => Eliminar();
            btnGuardar.Click += (s, e) => Guardar();
            btnCargar.Click += (s, e) => Cargar();
            btnExportarPDF.Click += (s, e) => ExportarPDF();

            Controls.AddRange(new Control[] {
                lblBuscar, txtBuscar, grid,
                lblNombre, txtNombre, lblTelefono, txtTelefono,
                lblEmail, txtEmail, lblNotas, txtNotas,
                btnNuevo, btnAgregar, btnActualizar, btnEliminar, btnGuardar, btnCargar, btnExportarPDF
            });

            ConfigurarGrid();
            // Auto-cargar si existe archivo
            if (File.Exists(RutaDatos)) Cargar();
        }

        void ConfigurarGrid()
        {
            grid.Columns.Clear();
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "Telefono" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Notas", DataPropertyName = "Notas" });
            RefrescarGrid();
        }

        void RefrescarGrid()
        {
            string q = txtBuscar?.Text?.Trim().ToLower() ?? "";
            var datos = string.IsNullOrWhiteSpace(q)
                ? contactos
                : contactos.Where(c =>
                    (c.Nombre ?? "").ToLower().Contains(q) ||
                    (c.Telefono ?? "").ToLower().Contains(q) ||
                    (c.Email ?? "").ToLower().Contains(q) ||
                    (c.Notas ?? "").ToLower().Contains(q))
                  .ToList();

            grid.DataSource = null;
            grid.DataSource = datos.Select(c => new Contacto
            {
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Email = c.Email,
                Notas = c.Notas
            }).ToList();
        }

        void CargarSeleccionEnFormulario()
        {
            if (grid.CurrentRow == null) return;
            var nombre = grid.CurrentRow.Cells[0].Value?.ToString() ?? "";
            var tel = grid.CurrentRow.Cells[1].Value?.ToString() ?? "";
            var email = grid.CurrentRow.Cells[2].Value?.ToString() ?? "";
            var notas = grid.CurrentRow.Cells[3].Value?.ToString() ?? "";

            txtNombre.Text = nombre;
            txtTelefono.Text = tel;
            txtEmail.Text = email;
            txtNotas.Text = notas;
        }

        bool Validar(out string msg)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                msg = "El nombre es obligatorio.";
                return false;
            }
            msg = "";
            return true;
        }

        void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNotas.Text = "";
            txtNombre.Focus();
            grid.ClearSelection();
        }

        void Agregar()
        {
            if (!Validar(out var m)) { MessageBox.Show(m, "Validación"); return; }
            contactos.Add(new Contacto
            {
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Notas = txtNotas.Text.Trim()
            });
            RefrescarGrid();
            LimpiarFormulario();
        }

        void Actualizar()
        {
            if (!Validar(out var m)) { MessageBox.Show(m, "Validación"); return; }
            if (grid.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un contacto en la lista.", "Atención");
                return;
            }
            var nombreSeleccion = grid.CurrentRow.Cells[0].Value?.ToString();
            var contacto = contactos.FirstOrDefault(c => c.Nombre == nombreSeleccion);
            if (contacto == null)
            {
                MessageBox.Show("No se encontró el contacto seleccionado.", "Error");
                return;
            }
            contacto.Nombre = txtNombre.Text.Trim();
            contacto.Telefono = txtTelefono.Text.Trim();
            contacto.Email = txtEmail.Text.Trim();
            contacto.Notas = txtNotas.Text.Trim();

            RefrescarGrid();
        }

        void Eliminar()
        {
            if (grid.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un contacto a eliminar.", "Atención");
                return;
            }
            var nombre = grid.CurrentRow.Cells[0].Value?.ToString();
            var contacto = contactos.FirstOrDefault(c => c.Nombre == nombre);
            if (contacto == null) return;

            if (MessageBox.Show($"¿Eliminar \"{contacto.Nombre}\"?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                contactos.Remove(contacto);
                RefrescarGrid();
                LimpiarFormulario();
            }
        }

        void Guardar()
        {
            try
            {
                var json = JsonSerializer.Serialize(contactos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(RutaDatos, json);
                MessageBox.Show($"Guardado en:\n{RutaDatos}", "OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error");
            }
        }

        void Cargar()
        {
            try
            {
                if (!File.Exists(RutaDatos))
                {
                    MessageBox.Show("No hay archivo para cargar todavía.", "Info");
                    return;
                }
                var json = File.ReadAllText(RutaDatos);
                var lista = JsonSerializer.Deserialize<List<Contacto>>(json) ?? new List<Contacto>();
                contactos = lista;
                RefrescarGrid();
                MessageBox.Show("Datos cargados.", "OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error");
            }
        }

        void ExportarPDF()
        {
            // PDF generado usando QuestPDF (MIT License) - https://www.questpdf.com
            string rutaPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "agenda.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Header
                    page.Header()
                        .Text("Agenda de Contactos")
                        .SemiBold()
                        .FontSize(18)
                        .AlignCenter();

                    // Contenido (Tabla)
                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            // Encabezado
                            table.Header(header =>
                            {
                                header.Cell().Text("Nombre").Bold();
                                header.Cell().Text("Teléfono").Bold();
                                header.Cell().Text("Email").Bold();
                                header.Cell().Text("Notas").Bold();
                            });

                            // Filas de datos
                            foreach (var c in contactos)
                            {
                                table.Cell().Text(c.Nombre);
                                table.Cell().Text(c.Telefono);
                                table.Cell().Text(c.Email);
                                table.Cell().Text(c.Notas);
                            }
                        });

                    // Footer con número de página correcto
                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Página ");
                            text.CurrentPageNumber();
                            text.Span(" de ");
                            text.TotalPages();
                        });
                });
            })
            .GeneratePdf(rutaPDF);

            MessageBox.Show($"PDF generado correctamente en:\n{rutaPDF}", "Éxito");
        }
    }


}
