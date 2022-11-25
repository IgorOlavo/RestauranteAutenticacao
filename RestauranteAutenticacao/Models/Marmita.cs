using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestauranteAutenticacao.Models
{
    public enum Tamanho { P, M, G, GG }
    public class Marmita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Descricao: ")]
        public string descricao { get; set; }

        [Display(Name = "Tamanho: ")]
        public Tamanho tamanho { get; set; }

        [Display(Name = "Preco: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float preco { get; set; }

        public ICollection<Pedido> pedidos { get; set; }
    }
}
