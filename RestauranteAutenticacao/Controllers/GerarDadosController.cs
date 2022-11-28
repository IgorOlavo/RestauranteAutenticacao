using Microsoft.AspNetCore.Mvc;
using RestauranteAutenticacao.Models;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.AccessControl;
using System;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace RestauranteAutenticacao.Controllers
{
    public class GerarDadosController : Controller
    {
        private readonly Contexto contexto;

        public GerarDadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult gerarCliente()
        {

            contexto.Database.ExecuteSqlRaw("delete from Cliente");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Cliente', RESEED, 0)");


            Random randNum = new Random();

            string[] vNomesMas = { "Miguel", "Arthur", "Théo", "Heitor", "Gael", "Davi", "Bernardo", "Gabriel", "Ravi", "Noah", "Samuel", "Pedro", "Benício", "Benjamin", "Matheus", "Isaac", "Anthony", "Joaquim", "Lucas", "Lorenzo", "Rafael", "Nicolas", "Henrique", "Murilo", "João Miguel", "Lucca", "Guilherme", "Henry", "Bryan", "Gustavo", "Felipe", "Pietro", "Levi", "Daniel", "JoãoPedro", "Bento", "Vicente", "Leonardo", "Caleb", "Pedro Henrique", "Matteo", "Enzo Gabriel", "João", "Antônio", "Emanuel", "Enzo", "Davi Lucca", "Caio", "Eduardo", "João Lucas", "Thomas", "Cauã", "Vitor", "José", "Enrico", "Augusto", "João Gabriel", "Francisco", "Otávio", "Yuri", "Valentim", "Vinícius", "Davi Lucas", "Rael", "Mathias", "Theodoro", "Yan", "João Guilherme", "Nathan", "Arthur Miguel", "Oliver", "Anthony Gabriel", "Ryan", "Luiz Miguel", "Erick", "João Vitor", "Luan", "Thiago", "Apollo", "Ícaro", "Breno", "Arthur Gabriel", "Derick", "Kauê", "Martin", "Luiz Felipe", "Raul", "Liam", "Davi Miguel", "Pedro Lucas", "José Miguel", "Josué", "Pedro Miguel", "Micael", "Yago", "Dominic", "Vitor Hugo", "Luiz Henrique", "Estevão", "Davi Luiz" };
            string[] vNomesFem = { "Julia", "Sophia", "Isabella", "Maria Eduarda", "Manuela", "Giovanna", "Alice", "Laura", "Luiza", "Beatriz", "Mariana", "Yasmin", "Gabriela", "Rafaela", "Maria Clara", "Maria Luiza", "Ana Clara", "Isabelle", "Lara", "Ana Luiza", "Letícia", "Ana Julia", "Valentina", "Nicole", "Sarah", "Vitória", "Isadora", "Lívia", "Helena", "Ana Beatriz", "Lorena", "Clara", "Larissa", "Emanuelly", "Heloisa", "Marina", "Melissa", "Gabrielly", "Eduarda", "Maria Fernanda", "Rebeca", "Amanda", "Alícia", "Bianca", "Lavínia", "Fernanda", "Ester", "Carolina", "Emily", "Cecília", "Maria Júlia", "Pietra", "Ana Carolina", "Milena", "Marcela", "Laís", "Natália", "Maria", "Bruna", "Camila", "Luana", "Ana Laura", "Catarina", "Maria Vitória", "Maria Alice", "Olivia", "Agatha", "Mirella", "Sophie", "Stella", "Stefany", "Isabel", "Kamilly", "Elisa", "Luna", "Eloá", "Joana", "Mariane", "Bárbara", "Juliana", "Rayssa", "Alana", "Ana Sophia", "Ana Lívia", "Caroline", "Brenda", "Evelyn", "Débora", "Raquel", "Maitê", "Ana", "Nina", "Maria Sophia", "Maria Cecília", "Luiz", "Antonella", "Jennifer", "Betina", "Mariah", "Sabrina" };
            string[] vEndereco = {"Rua Adão Ricardo Negrão Pineda", "Rua Alfredo C. Rocha", "Rua Alfredo Garcia", "Rua Amando Valério", "Rua Amazonas", "Rua Amâncio de Góes", "Rua André Maurício Marques", "Rua Angelo Brigano", "Rua Antônio Alonso", "Rua Antônio Côco", "Rua Antônio Correia Filho", "Rua Antônio da Silva Onça", "Rua Antônio Danelo", "Rua Antônio Monteiro", "Rua Argentina", "Rua Arthur M. de Oliveira", "Rua Augusto dos Santos", "Rua Ézio Antônio Tirolli", "Rua Bahia", "Rua Barão do Rio Branco", "Rua Benedito Correa da Silva", "Rua Benedito Pereira Pontes", "Rua Benjamin Ortega Moreno", "Rua Bolívia", "Rua Canaan Tannus", "Rua Candido Dias Mello", "Rua Carlos Manfio", "Rua Cherubin de Mattos", "Rua Coronel Afonso Negrão", "Rua D", "Rua das Acácias", "Rua das Camélias", "Rua das Dalias", "Rua das Hortências", "Rua das Margaridas", "Rua das Orquídeas", "Rua das Palmeiras", "Rua das Rosas", "Rua das violetas", "Rua Dolores Parra Garcia", "Rua dos Jacintos", "Rua dos Lírios", "Rua dos Trabalhadores", "Rua Doutor Geraldo Coelho", "Rua Doutor Ney de Souza Cruz", "Rua Duque de Caxias", "Rua Edgard Luzio Filho", "Rua Eduardo Ferreira", "Rua Eduardo Zacarelli", "Rua Emílio Rorato", "Rua Estados Unidos", "Rua Eugenia Baldi", "Rua Feliciano Scalada", "Rua Francisco Cardoso dos Santos", "Rua Francisco Elias da Silva", "Rua Francisco Florêncio", "Rua Francisco Golçalves Gil", "Rua Francisco Holmo", "Rua Francisco Mariano Sobrinho", "Rua Francisco Severino da Costa", "Rua Geremias de Mattos", "Rua Gilson Calandrielo de Paula", "Rua Gregório Telles", "Rua Guilherme Magrinelli", "Rua Hardlo Frandsen", "Rua Helio Gobetti", "Rua Henrique Alberto Silva", "Rua Hermantina P. de Oliveira", "Rua Horácio da Silva Leite", "Rua Idalécio M. de Lima", "Rua Irineu de Oliveira", "Rua Itamar Prada", "Rua J. Holmo", "Rua Jacila Pachiani Prioli", "Rua Jeronimo Alves Júnior", "Rua Joaquim Amancio Ferreira", "Rua Joaquim Moreira da Silva", "Rua Joaquim Nascimento Lourenço", "Rua Joaquim Silvério da Cruz", "Rua João A. Meyer", "Rua João Carlos de Almeida", "Rua João Flauzino", "Rua João Isidoro Leandro", "Rua Tereziano dos Santos", "Rua Tonin B. Bergamaschi", "Rua Uruguai", "Rua Valdemar Leone", "Rua Vereador Clóvis de Camargo Bueno", "Rua Vereador Lopes", "Rua Wady Zugaiar", "Rua Wilson José Ramires", "ua Santos Dumont", "Rua Satyro Molitor", "Rua São João", "Rua São José", "Rua São Judas Tadeu", "Rua São Mateus", "Rua São Paulo", "Rua Tereziano dos Santos", "Rua Tonin B. Bergamaschi"};

            for (int i = 0; i < 100; i++) {
                Cliente cliente = new Cliente();
                cliente.nome = (i % 2 == 0) ? vNomesMas[i / 2] : vNomesFem[i / 2];
                cliente.telefone = "1899" + randNum.Next(100000000, 999999999).ToString();
                cliente.endereco = vEndereco[randNum.Next(1, 100)] + ", " + randNum.Next(1, 600).ToString();
                contexto.Cliente.Add(cliente);
            }
            contexto.SaveChanges();

            return  View(contexto.Cliente.ToList());
        }

        public IActionResult gerarMarmita()
        {
            contexto.Database.ExecuteSqlRaw("delete from Marmita");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Marmita', RESEED, 0)");

            Random randNum = new Random();

            string[] vCardapio = { "Arroz, Feijao, Frango, Farrofa, Polenta, Batata Cuzida, Ovo", "Arroz, Feijao, Costela Bolvina, Farrofa, Polenta, Repolho Refogado", "Arroz, Feijao, Bisteca de Porco, Salsicha, Refogado de Legumes, Pure de Batata", "Arroz, Feijao, Enroladinho de Salsicha, Farrofa, Polenta, Ovo Frito, Pure de Batata", "Arroz, Feijao, Bife, Acebolado, Farrofa, Polenta, Batata Cuzida, Ovo" };

            Array tamanhos = Enum.GetValues(typeof(Tamanho));

            for(int i  = 0; i < 100; i++)
            {
                Marmita marmita = new Marmita();
                marmita.descricao = vCardapio[randNum.Next(0, 5)];
                marmita.tamanho = (Tamanho)tamanhos.GetValue(randNum.Next(tamanhos.Length));
                if (marmita.tamanho == Tamanho.P) { marmita.preco = 18; }
                else if (marmita.tamanho == Tamanho.M) { marmita.preco = 22; }
                else if (marmita.tamanho == Tamanho.G) { marmita.preco = 28; }
                else if (marmita.tamanho == Tamanho.GG) { marmita.preco = 35; }

                contexto.Marmita.Add(marmita);
            }

            contexto.SaveChanges();

            return View(contexto.Marmita.ToList()); 
        }

        public IActionResult gerarPedido()
        {
            contexto.Database.ExecuteSqlRaw("delete from Pedido");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Pedido', RESEED, 0)");
            Random randNum = new Random();

            Array tempo = Enum.GetValues(typeof(Status));

            for (int i = 0; i < 100; i++)
            {
                Pedido pedido = new Pedido();

                pedido.clienteid = randNum.Next(1, 100);
                Cliente cliente = contexto.Cliente.Find(pedido.clienteid);

                pedido.bebidaid = randNum.Next(1, 5);
                Bebida bebida = contexto.Bebida.Find(pedido.bebidaid);

                pedido.quantidadebebida = randNum.Next(1, 100);

                pedido.marmitaid = randNum.Next(1, 100);
                Marmita marmita = contexto.Marmita.Find(pedido.marmitaid);

                pedido.status = (Status)tempo.GetValue(randNum.Next(tempo.Length));
                if (pedido.status == Status.Preparacao)
                {
                    pedido.tempoPedido = randNum.Next(15, 120).ToString();
                }

                contexto.Pedido.Add(pedido);

            }
            contexto.SaveChanges();

            return View(contexto.Pedido.OrderBy(o => o.id).ToList());
        }

    }
}
