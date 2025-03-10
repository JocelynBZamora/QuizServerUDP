using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using QuizServerUDP.Model;
using QuizServerUDP.Services;
using QuizzServer.Model;
using QuizzServer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizServerUDP.ViewModel
{
    public partial class MainVM : ObservableRecipient, IRecipient<NavegacionModel>
    {
        public string IP { get; set; } = "0.0.0.0";
        [ObservableProperty]
        public string vista = "Secciones";
        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private int respuestaSeleccionada;
        [ObservableProperty]
        public int puntaje = 0;
        public ObservableCollection<UsuarioSModel> Usuarios { get; set; } = new();
        List<UsuarioSModel> usuarios = new();//persistente
        Servidor server = new();

        public MainVM()
        {
            //Ip del servidor
            var ips = Dns.GetHostAddresses(Dns.GetHostName());
            IP = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).
                Select(x => x.ToString()).FirstOrDefault() ?? "0.0.0.0";

            //para que envie y resiva
            IsActive = true;
            ActualizarNombre();
            server.RespuestaResivida += EntradaJugador;
        }

        private void EntradaJugador(object? sender, RespuestasClientModel obj)
        {


            //guarda y muestra el nombre del usuario
            if (!string.IsNullOrWhiteSpace(obj.Nombre))
            {

                foreach (var item in usuarios)
                {
                    var usuario = item.Nombre;
                    if (obj.Nombre == usuario)
                    {
                        //mensaje de usuario ya usado
                    }
                    else
                    {

                        UsuarioSModel u = new();
                        u.Nombre = obj.Nombre;
                        usuarios.Add(u);
                    }
                }

            }
            ActualizarNombre();
            Guardar();
        }


        private void Guardar()
        {
            //crea el archivo json
            var archivo = File.Create("usuarios.json");
            JsonSerializer.Serialize(archivo, usuarios);
            archivo.Close();
        }
        public void ActualizarNombre()
        {
            foreach (var u in usuarios)
            {
                Usuarios.Add(u);
            }

        }

        public void Receive(NavegacionModel message)
        {
            Vista = message.vista;
            if (message.seccion != null)
            {
                eventoshelper.setSeccion?.Invoke(message.seccion);
            }
        }

    }
}
