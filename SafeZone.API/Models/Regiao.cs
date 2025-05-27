namespace SafeZoneApi.Models
{
    public class Regiao
    {
        // Chave primária privada para EF
        private int _id;
        public int Id => _id;

        // Nome da região (não pode ser nulo)
        public string Nome { get; private set; } = null!;

        // Descrição opcional
        public string? Descricao { get; private set; }

        // Relação com sensores
        public ICollection<Sensor> Sensores { get; private set; } = new List<Sensor>();

        // Construtor sem parâmetros para EF Core
        private Regiao() { }

        // Construtor principal
        public Regiao(string nome, string? descricao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao;
        }

        // Método para atualizar a entidade
        public void Update(string nome, string? descricao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao;
        }
    }
}
