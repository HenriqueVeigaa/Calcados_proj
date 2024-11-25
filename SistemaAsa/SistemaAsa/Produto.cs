using MySql.Data.MySqlClient;
using System;

namespace SistemaAsa
{
    internal class Produto
    {
        
        public int Id { get; set; }
        protected string Nome { get; set; }
        protected decimal Preco { get; set; }

        protected int Tamanho {  get; set; }

        protected string Modelo {  get; set; }

        protected string Solado {  get; set; }
        protected string Adicionais_prod {  get; set; }

        
        public void GetDadosProd()
        {
            Console.WriteLine("Informe o ID do produto:");
            Id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o nome do produto:");
            Nome = Console.ReadLine();

            Console.WriteLine("\nInforme o tamanho do produto: ");
            Tamanho =int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o modelo do produto:");
            Modelo = Console.ReadLine();

            Console.WriteLine("\nInforme o tipo de solado: ");
            Solado = Console.ReadLine();

            Console.WriteLine("Informe se o produto possuí informações adicionais:");
            Adicionais_prod = Console.ReadLine();

            Console.WriteLine("\nInforme o preço do produto:");
            Preco = decimal.Parse(Console.ReadLine());

           
        }

        
        public void AdicionarProduto(MySqlConnection conexao)
        {
            try
            {
                
                string SQL = "INSERT INTO Produto (Id_prod, Nome_prod,tamanho_prod,modelo_prod,solado_prod,adicionais_prod,preco_prod ) " +
                                    "VALUES (@id_prod, @nome_prod,@tamanho_prod,@modelo_prod,@solado_prod,@prod_adicionais, @preco_prod)";

                
                using (MySqlCommand cmd = new MySqlCommand(SQL, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_prod", Id);
                    cmd.Parameters.AddWithValue("@nome_prod", Nome);
                    cmd.Parameters.AddWithValue("@tamanho_prod",Tamanho);
                    cmd.Parameters.AddWithValue("@modelo_prod", Modelo);
                    cmd.Parameters.AddWithValue("@solado_prod", Solado);
                    cmd.Parameters.AddWithValue("@prod_adicionais", Adicionais_prod);
                    cmd.Parameters.AddWithValue("@preco_prod", Preco);


                   
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Produto adicionado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar produto: " + ex.Message);
            }
        }

       
        public void ListarProdutos(MySqlConnection conexao)
        {
            try
            {
                string sql = "SELECT * FROM Produto";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                Console.WriteLine("Consultando produtos...");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Nenhum produto encontrado.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine("\nID do Produto: " + reader["id_prod"]);
                        Console.WriteLine("Nome do Produto: " + reader["nome_prod"]);
                        Console.WriteLine("Tamanho do Produto: " + reader["tamanho_prod"]);
                        Console.WriteLine("Modelo do Produto: " + reader["modelo_prod"]);
                        Console.WriteLine("Solado do Produto: " + reader["solado_prod"]);
                        Console.WriteLine("Adicionais: " + reader["adicionais_prod"]);
                        Console.WriteLine("Preço: " + reader["preco_prod"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar produtos: " + ex.Message);
            }
        }

        
        public void DeletarProduto(MySqlConnection conexao)
        {
            try
            {
                Console.Write("Digite o ID do produto a ser removido: ");
                Id = int.Parse(Console.ReadLine());

                string sql = "DELETE FROM Produto WHERE id_prod = @id_prod";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_prod", Id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Produto removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum produto encontrado com o ID fornecido.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar produto: " + ex.Message);
            }
        }

        
        public void AtualizarProduto(MySqlConnection conexao)
        {
            try
            {
                Console.Write("Digite o ID do produto que deseja atualizar: ");
                Id = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInforme o nome do produto:");
                Nome = Console.ReadLine();

                Console.WriteLine("\nInforme o tamanho do produto: ");
                Tamanho = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInforme o modelo do produto:");
                Modelo = Console.ReadLine();

                Console.WriteLine("\nInforme o tipo de solado: ");
                Solado = Console.ReadLine();

                Console.WriteLine("Informe se o produto possuí informações adicionais:");
                Adicionais_prod = Console.ReadLine();

                Console.WriteLine("\nInforme o preço do produto:");
                Preco = decimal.Parse(Console.ReadLine());

                string sql = "UPDATE Produto SET nome_prod = @nome_prod, tamanho_prod = @tamanho_prod, modelo_prod = @modelo_prod, solado_prod = @solado_prod, adicionais_prod = @prod_adicionais, preco_prod = @preco_prod where id_prod = @id_prod";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {

                    cmd.Parameters.AddWithValue("@id_prod", Id);
                    cmd.Parameters.AddWithValue("@nome_prod", Nome);
                    cmd.Parameters.AddWithValue("@tamanho_prod", Tamanho);
                    cmd.Parameters.AddWithValue("@modelo_prod", Modelo);
                    cmd.Parameters.AddWithValue("@solado_prod", Solado);
                    cmd.Parameters.AddWithValue("@prod_adicionais", Adicionais_prod);
                    cmd.Parameters.AddWithValue("@preco_prod", Preco);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Produto atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum produto encontrado com o ID fornecido.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar produto: " + ex.Message);
            }
        }
    }
}
