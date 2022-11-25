using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestauranteAutenticacao.Models
{
    public enum Status { Entregue, Preparacao }

    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Bebida: ")]
        public Bebida bebida { get; set; }
        [ForeignKey("Bebida")]
        [Display(Name = "Bebida: ")]
        public int bebidaid { get; set; }


        [Display(Name = "Marmita: ")]
        public Marmita marmitas { get; set; }
        [ForeignKey("Marmita")]
        [Display(Name = "Marmita: ")]
        public int marmitaid { get; set; }


        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }
        [ForeignKey("Cliente")]
        [Display(Name = "Endereco do Cliente: ")]
        public int clienteid { get; set; }


        [Display(Name = "Andamento do Pedido: ")]
        public Status status { get; set; }

        [Display(Name = "Tempo de Preparo: ")]
        public string tempoPedido { get; set; }
    }
}
