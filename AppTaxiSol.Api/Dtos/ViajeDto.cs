﻿namespace AppTaxiSol.Api.Dtos
{
    public class ViajeDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int Calificacion { get; set; }
        public int TaxiId { get; set; }
        public int UserId { get; set; }
    }
}
