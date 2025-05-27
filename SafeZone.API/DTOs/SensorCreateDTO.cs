namespace SafeZoneApi.DTOs
{
    public class SensorCreateDTO
    {
        public string Tipo { get; set; } = null!;
        public string UnidadeMedida { get; set; } = null!;
        public int RegiaoId { get; set; }
    }
}
