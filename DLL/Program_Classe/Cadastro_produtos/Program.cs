using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeProdutos;

namespace Cadastro_produtos
{
    class Program
    {
        static void Main()
        {
            Cliente c1 = new Cliente();

            c1.CadastrarCliente();

            //Alterar os dados de conexão para os dados do banco de dados final
            string stringconexao = "Server=127.0.0.1;Database=asaP;uid=root;pwd=;port=3306;";

            Prod_repo repository = new Prod_repo(stringconexao);

            while (true)
            {
                Console.WriteLine("\nEscolha uma operação:");
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Listar produtos");
                Console.WriteLine("3. Atualizar produto");
                Console.WriteLine("4. Deletar produto");
                Console.WriteLine("5. Sair");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        AdicionarProduto(repository);
                        break;
                    case "2":
                        ListarProdutos(repository);
                        break;
                    case "3":
                        AtualizarProduto(repository);
                        break;
                    case "4":
                        DeletarProduto(repository);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void AdicionarProduto(Prod_repo repository)
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade do produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade
            };

            repository.AdicionarProduto(produto);
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        static void ListarProdutos(Prod_repo repository)
        {
            List<Produto> produtos = repository.ObterProdutos();

            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado.");
                return;
            }

            Console.WriteLine("\nLista de Produtos:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade: {produto.Quantidade}");
            }
        }

        static void AtualizarProduto(Prod_repo repository)
        {
            Console.Write("Digite o ID do produto a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o novo preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite a nova quantidade do produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto
            {
                Id = id,
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade
            };

            repository.AtualizarProduto(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
        }

        static void DeletarProduto(Prod_repo repository)
        {
            Console.Write("Digite o ID do produto a ser deletado: ");
            int id = int.Parse(Console.ReadLine());

            repository.DeletarProduto(id);
            Console.WriteLine("Produto deletado com sucesso!");
        }
    }
}
