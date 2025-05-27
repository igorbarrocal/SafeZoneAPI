namespace SafeZoneApi.Models
{
    public class Sensor
    {
        public int Id { get; private set; }  

        public string Tipo { get; set; } = null!;
        public string UnidadeMedida { get; set; } = null!;

        
        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; } = null!;

        
        protected Sensor() { }

        
        public Sensor(string tipo, string unidadeMedida, int regiaoId)
        {
            Tipo = tipo;
            UnidadeMedida = unidadeMedida;
            RegiaoId = regiaoId;
        }
    }
}
