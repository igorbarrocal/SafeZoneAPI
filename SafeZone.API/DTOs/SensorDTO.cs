namespace SafeZoneApi.DTOs
{
    public class SensorDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string UnidadeMedida { get; set; } = null!;
        public int RegiaoId { get; set; }
    }
}
