using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuizClientUDP.Model;
using QuizClientUDP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizClientUDP.ViewModel
{
    internal class RespuestaVM:INotifyPropertyChanged
    {

        public RespuestaCModel dto { get; set; } = new();
        public string IP { get; set; } = "0.0.0.0";
        RespuestaClient ClienteUDP = new();


        public RelayCommand EnviarUsuarioCommand { get; set; }
        public RelayCommand EnviarRespuestaCommand { get; set; }
        public RespuestaVM()
        {
            EnviarUsuarioCommand = new RelayCommand(EnviarUsuario);
            EnviarRespuestaCommand = new RelayCommand(EnviarRespuesta);
        }
        void Iniciar()
        {
        }
        private void EnviarUsuario()
        {
            if (dto.Nombre != string.Empty)
            {
                ClienteUDP.Servidor = IP;
                var ipclient = Dns.GetHostAddresses(Dns.GetHostName());
                dto.IpJugador = ipclient[0].ToString();
                ClienteUDP.EnviarRespuesta(dto);

            }
        }
        private void EnviarRespuesta()
        {
            if (dto.NumRespuesta >= 1 && dto.NumRespuesta <= 4)
            {

                ClienteUDP.EnviarRespuesta(dto);
            }

        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
