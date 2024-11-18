using System;
using MySql.Data.MySqlClient;

namespace CadastroDeProdutos
{
    public class Cliente
    {
        // Propriedades da classe Cliente
        protected string Nome { get; set; }
        protected string Cpf { get; set; }
        protected string Email { get; set; }
        protected string Senha { get; set; }
        protected string Data_Nasc { get; set; }

        // Método para capturar os dados do usuário e inserir no banco de dados
        public void CadastrarCliente()
        {
            // Captura os dados do usuário
            Console.WriteLine("Digite seu nome:");
            Nome = Console.ReadLine();

            Console.WriteLine("Digite seu CPF (somente números):");
            Cpf = Console.ReadLine();


            Console.WriteLine("Digite seu e-mail:");
            Email = Console.ReadLine();

            Console.WriteLine("Digite sua senha:");
            Senha = Console.ReadLine();

            Console.WriteLine("Digite sua data de nascimento (dd/mm/aaaa):");
            Data_Nasc = Console.ReadLine();

            MySqlConnection conexao = new MySqlConnection();
            try
            {
                // String de conexão com o banco de dados MySQL
                string stringconexao = "server=127.0.0.1;database=asaP;uid=root;pwd=;port=3306;";


                
                {
                   
                    conexao.Open();
                    Console.WriteLine("Conectado ao banco de dados com sucesso!");

                    // Comando SQL para inserir os dados na tabela clientes
                     string query = @"
                        INSERT INTO cliente (nome_cliente, cpf, email_pessoal, senha_cliente, data_nasc_cliente) 
                        VALUES (@Nome, @Cpf, @Email, @Senha, STR_TO_DATE(@Data_Nasc, '%d/%m/%Y'))
                    ";
                     
                    using (var cmd = new MySqlCommand(query, conexao))
                    {
                      
                        // Parâmetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@Nome", Nome);
                        cmd.Parameters.AddWithValue("@Cpf", Cpf);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Senha", Senha);
                        cmd.Parameters.AddWithValue("@Data_Nasc", Data_Nasc); // A data será convertida com STR_TO_DATE

                        // Executa o comando
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Cliente cadastrado com sucesso!");
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Erro específico do MySQL
                Console.WriteLine("Erro de banco de dados: " + ex.Message+ex.Number);
            }

            finally
            {
                // Fechar a conexão
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                    Console.WriteLine("Conexão fechada.");
                }
            }

        }
    }

 
    }

