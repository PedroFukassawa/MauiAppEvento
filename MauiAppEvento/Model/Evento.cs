using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppEvento.Model
{
    public class Evento
    {
        public int QntParticipantes { get; set; }
        public Decimal CustoPorParticipante { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }

        public TimeSpan Duracao
        {
            get => DataTermino - DataInicio;
        }

        public decimal CustoTotal
        {
            get => QntParticipantes * CustoPorParticipante;
        }
    }
}
