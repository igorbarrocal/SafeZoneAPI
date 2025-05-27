namespace SafeZoneApi.Models
{
    public class Regiao
    {
       
        private int _id;
        public int Id => _id;

        
        public string Nome { get; private set; } = null!;

       
        public string? Descricao { get; private set; }

        
        public ICollection<Sensor> Sensores { get; private set; } = new List<Sensor>();

        
        private Regiao() { }

       
        public Regiao(string nome, string? descricao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao;
        }

        
        public void Update(string nome, string? descricao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao;
        }
    }
}
