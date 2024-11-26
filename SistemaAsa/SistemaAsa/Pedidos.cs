using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAsa
{
    using MySql.Data.MySqlClient;
    using System;

    internal class Estoque
    {
        public int Id { get; set; }
        protected int Id_produto { get; set; }
        protected int Id_fornecedor { get; set; }
        protected int Qtd_estoque { get; set; }

  
        

        public void GetDadosEstoque()
        {
         

            Console.WriteLine("Informe o ID do produto:");
            Id_produto = int.Parse(Console.ReadLine());

            

            Console.WriteLine("\nInforme a quantidade disponível do produto no estoque:");
            Qtd_estoque = int.Parse(Console.ReadLine());
        }

        
        

        public void AtualizarEstoque(MySqlConnection conexao)
        {
            try
            {
          
                string comandoSQL = "UPDATE Estoque SET qntd_estoque = qntd_estoque + @qntd_estoque WHERE prod_id = @prod_id";

                using (MySqlCommand cmd = new MySqlCommand(comandoSQL, conexao))
                {
                    cmd.Parameters.AddWithValue("@prod_id", Id_produto);
                    cmd.Parameters.AddWithValue("@qtnd_estoque", Qtd_estoque);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Estoque atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar estoque: " + ex.Message);
            }
        }


        public void RemoverEstoque(MySqlConnection conexao)
        {
            try
            {
                string comandoSQL = "UPDATE Estoque SET Qntd_estoque = Qntd_estoque - @qntd_estoque WHERE prod_id = @pro_id AND qntd_estoque >= @qntd_estoque";

                using (MySqlCommand cmd = new MySqlCommand(comandoSQL, conexao))
                {
                    cmd.Parameters.AddWithValue("@prod_id", Id_produto);
                    cmd.Parameters.AddWithValue("@qntd_estoque", Qtd_estoque);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Estoque removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade insuficiente ou produto não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao remover estoque: " + ex.Message);
            }
        }

        public void ListarEstoque(MySqlConnection conexao)
        {
            try
            {

                string sql = "SELECT produto.id_prod, produto.nome_prod, produto.preco_prod, estoque.qntd_estoque " +
                             "FROM Produto " +
                             "INNER JOIN Estoque ON produto.id_prod = estoque.ProdId";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                Console.WriteLine("Consultando estoque...");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Nenhum produto encontrado no estoque.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine("\nID Produto: " + reader["Id"]);
                        Console.WriteLine("Nome: " + reader["Nome"]);
                        Console.WriteLine("Preço: " + reader["Preco"]);
                        Console.WriteLine("Quantidade no Estoque: " + reader["Quantidade"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar estoque: " + ex.Message);
            }
        }




    }
}

