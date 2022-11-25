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
        [StringLength(40)]
        public string descricao { get; set; }

        [Display(Name = "Preco: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float preco { get; set; }

        public ICollection<Pedido> pedidos { get; set; }
    }
}
