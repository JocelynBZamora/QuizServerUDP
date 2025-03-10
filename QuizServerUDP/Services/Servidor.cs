using QuizServerUDP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace QuizServerUDP.Services
{
    public class Servidor
    {
        
        int puerto = 6000;
        public Servidor()
        {
            var hilo = new Thread(new ThreadStart(Iniciar)) 
            {
                IsBackground = true
            };
            hilo.Start();
        }
        public EventHandler<RespuestasClientModel>? RespuestaResivida;
        void Iniciar()
        {
           UdpClient servidor = new UdpClient(puerto);
            while (true)
            {
                IPEndPoint cliente = new(IPAddress.Any, 0);
                byte[] Buffer = servidor.Receive(ref cliente);
                var json = Encoding.UTF8.GetString(Buffer);

                RespuestasClientModel? dto = JsonSerializer.Deserialize<RespuestasClientModel>(Encoding.UTF8.GetString(Buffer));

                if (dto != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        RespuestaResivida?.Invoke(this, dto);
                    });
                }

            }
        }

    }
}
