using QuizClientUDP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizClientUDP.Services
{
    internal class RespuestaClient
    {
        private UdpClient cliente = new();
        public string Servidor { get; set; } = "0.0.0.0";

        //public void EnviarRespuesta(RespuestaClient dto)
        //{
          
        //}

        internal void EnviarRespuesta(RespuestaCModel dto)
        {
            var ipe = new IPEndPoint(IPAddress.Parse(Servidor),
                      6000);
            var json = JsonSerializer.Serialize(dto);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            cliente.Send(buffer, buffer.Length, ipe);
        }
    }
}
