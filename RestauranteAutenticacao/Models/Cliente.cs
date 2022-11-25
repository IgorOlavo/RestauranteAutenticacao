using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestauranteAutenticacao.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        [StringLength(35)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Endereco é obrigatório")]
        [Display(Name = "Endereco: ")]
        [StringLength(100)]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        [Display(Name = "Telefone: ")]
        [StringLength(14)]
        public string telefone { get; set; }

        public ICollection<Pedido> pedidos { get; set; }
    }
}
