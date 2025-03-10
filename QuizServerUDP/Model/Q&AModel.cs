using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizServerUDP.Model
{
    public class Q_AModel
    {
        public string Pregunta { get; set; } = null!;
        public List<string> Respuestas { get; set; } = new();
        public int RespuestaCorrecta { get; set; }
    }
    public class Root
    {
        public List<Q_AModel> Historia { get; set; } = new();
        public List<Q_AModel> Español { get; set; } = new();
        public List<Q_AModel> Matemáticas { get; set; } = new();
        [JsonPropertyName("Ciencias Naturales")]
        public List<Q_AModel> CienciasNaturales { get; set; } = new();
    }
}
