using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locacaoEquipamentos.models
{

    [Table("equipamentos")]
    public class equipamentos
    {

        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
    }
}
