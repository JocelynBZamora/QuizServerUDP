using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using QuizServerUDP.Model;
using QuizzServer.Model;
using QuizzServer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizServerUDP.ViewModel
{
    public partial class PreguntasVM : ObservableRecipient, IRecipient<NavegacionModel>
    {
        [ObservableProperty]
        public List<string> respuestas = new();
        [ObservableProperty]
        public string pregunta;
        private List<Q_AModel> preguntaItems = new();

        public PreguntasVM()
        {
            IsActive = true;
            eventoshelper.setSeccion += (e => { cargarPeguntas_Respuestas(e); });

        }
        public void cargarPeguntas_Respuestas(string seccion)
        {
            string json = File.ReadAllText(@"Model\Q&A.json");
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var preguntas = JsonSerializer.Deserialize<Root>(json, opciones);

            if (seccion == "Español")
            {

            }
            else if (seccion == "Matematicas")
            {

            }
            else if (seccion == "Historia")
            {

            }
            else
            {

            }
        }
        public void Receive(NavegacionModel message)
        {
            cargarPeguntas_Respuestas(message.seccion);
        }
    }
}
