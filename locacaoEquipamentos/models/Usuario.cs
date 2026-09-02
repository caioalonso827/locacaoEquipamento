using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locacaoEquipamentos.models
{

    [Table("usuario")]
    public class usuario
    {
        [Key]
        [Column("id")]
        public int id {  get; set; }

        [Column("nome")]
        public string nome { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("senha")]
        public string senha { get; set; }
    }
}
