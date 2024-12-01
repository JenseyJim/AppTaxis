namespace AppTaxiSol.Api.Dtos
{
    public class DetalleViajeDto
    {
        public DateTime Fecha { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ViajeId { get; set; }
    }
}
