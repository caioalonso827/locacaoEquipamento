using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locacaoEquipamentos.models
{

    [Table("usuario")]
    public class usuario
    {
        [Key]
        public int id;
        public string nome;
        public string email;
        public string senha;
    }
}
