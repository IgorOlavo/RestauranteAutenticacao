namespace RestauranteAutenticacao.Models.Consultas
{
    public class PedidoQuerry
    {
        public int id { get; set; }
        public string marmita { get; set; }
        public string cliente { get; set; }
        public string endereco { get; set;}
        public string status { get; set;  }
        public string preparo { get; set; }
        public string bebida { get; set;  }
        public float preco  { get; set;    }

    }
}
