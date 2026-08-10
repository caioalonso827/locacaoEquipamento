using locacaoEquipamentos.models.Enum;
using System.Text.Json.Serialization;

namespace locacaoEquipamentos.models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int usuario_id { get; set; }
        public int equipamento_id { get; set; }

        public Tipo Tipo { get; set; }

        public int Quantidades { get; set; }

        [JsonIgnore]
        public Usuario usuario { get; set; }

        [JsonIgnore]
        public Equipamento equipamento { get; set; }


    }
}
