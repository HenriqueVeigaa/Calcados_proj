using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroDeProdutos
{
    //Atualizar comandos para se adequar às novas tabelas
    public class Prod_repo
    {
        private readonly string _connectionString;

        public Prod_repo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AdicionarProduto(Produto produto)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES (@Nome, @Preco, @Quantidade)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Produto> ObterProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nome, Preco, Quantidade FROM Produtos";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtos.Add(new Produto
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Preco = reader.GetDecimal("Preco"),
                                Quantidade = reader.GetInt32("Quantidade")
                            });
                        }
                    }
                }
            }

            return produtos;
        }
        public void AtualizarProduto(Produto produto)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", produto.Id);
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeletarProduto(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Produtos WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
