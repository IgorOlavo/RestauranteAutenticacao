using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestauranteAutenticacao.Models
{
    public class Bebida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        [Display(Name = "Preco: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "Campo Preco é obrigatório")]
        public float preco { get; set; }


        [Display(Name = "Quantidade: ")]
        [Range(1, 100, ErrorMessage = "Quantidade em Estoque maior que o Maximo")]
        public int quantidade { get; set; }


        public ICollection<Pedido> pedidos { get; set; }
    }
}
