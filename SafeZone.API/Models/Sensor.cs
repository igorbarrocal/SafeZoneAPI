namespace SafeZoneApi.Models
{
    public class Sensor
    {
        public int Id { get; private set; }  // setter privado

        public string Tipo { get; set; } = null!;
        public string UnidadeMedida { get; set; } = null!;

        // Chave estrangeira para Regiao
        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; } = null!;

        // Construtor padrão necessário para EF Core
        protected Sensor() { }

        // Construtor para criar um novo Sensor (Id será gerado pelo banco)
        public Sensor(string tipo, string unidadeMedida, int regiaoId)
        {
            Tipo = tipo;
            UnidadeMedida = unidadeMedida;
            RegiaoId = regiaoId;
        }
    }
}
