using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizServerUDP.Model
{
    public class RespuestasClientModel
    {
        public string Nombre { get; set; } = null!;
        public int NumRespuesta { get; set; }
        public string IpJugador { get; set; } = null!;
    }
}
