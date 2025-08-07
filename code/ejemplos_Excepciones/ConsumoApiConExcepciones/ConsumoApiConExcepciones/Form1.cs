using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ConsumoApiConExcepciones
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConsumir_Click(object sender, EventArgs e)
        {
            try
            {
                string pokemon = txtResultado.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(pokemon))
                {
                    MessageBox.Show("Ingresa el nombre de un Pokémon.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string url = $"https://pokeapi.co/api/v2/pokemon/{pokemon}";
                string respuesta = await httpClient.GetStringAsync(url);

                JObject json = JObject.Parse(respuesta);
                string nombre = json["name"]?.ToString();
                string altura = json["height"]?.ToString();
                string peso = json["weight"]?.ToString();

                MessageBox.Show($"Nombre: {nombre}
Altura: {altura}
Peso: {peso}", "Datos del Pokémon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión o Pokémon no encontrado: " + ex.Message, "Error HTTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("La solicitud tardó demasiado: " + ex.Message, "Tiempo de espera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
