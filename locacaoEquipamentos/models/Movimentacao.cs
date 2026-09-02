using locacaoEquipamentos.models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace locacaoEquipamentos.models
{

    [Table("movimentacao")]
    public class movimentacao
    {

        [Key]
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int equipamento_id { get; set; }

        public Tipo tipo { get; set; }

        public int quantidade { get; set; }

        [JsonIgnore]
        public usuario usuario { get; set; }

        [JsonIgnore]
        public equipamentos equipamento { get; set; }


    }
}
