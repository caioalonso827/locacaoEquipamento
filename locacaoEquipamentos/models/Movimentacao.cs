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

        [Column("usuario_id")]
        public int usuario_id { get; set; }

        [Column("equipamento_id")]
        public int equipamento_id { get; set; }


        [Column("tipo")]
        public Tipo tipo { get; set; }

        [Column("quantidade")]
        public int quantidade { get; set; }


        [Column("usuario")]
        [JsonIgnore]
        public usuario usuario { get; set; }


        [Column("equipamento")]
        [JsonIgnore]
        public equipamentos equipamento { get; set; }


    }
}
