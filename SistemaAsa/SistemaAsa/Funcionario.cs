using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;

namespace SistemaAsa
{
    internal class Funcionario
    {
        public int ID_func { get; set; }
        protected string Nome_func { get; set; }
        protected string CPF { get; set; }
        protected string Email_func { get; set; }
        protected string Senha_func { get; set; }

        protected string cargo_func { get; set; }

        public void GetDados()
        {
            Console.WriteLine("Informe o ID do funcionario:");
            ID_func = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInforme o nome do funcionario:");
            Nome_func = Console.ReadLine();
            Console.WriteLine("\nInforme o CPF do funcionario:");
            CPF = Console.ReadLine();
            Console.WriteLine("Informe o cargo:");
            cargo_func = Console.ReadLine();
            Console.WriteLine("\nInforme o email do funcionario:");
            Email_func = Console.ReadLine();
            Console.WriteLine("\nPor fim, informe a senha do funcionario:");
            Senha_func = Console.ReadLine();
        }



        public void AdicionarFuncionario(MySqlConnection conexao)
        {
            try
            {
                // Definindo o comando SQL
                string comandoSQL = "INSERT INTO funcionario(id_funcionario, nome_funcionario,cpf,cargo_funcionario,email_comercial, senha_funcionario) " +
                                    "VALUES (@id_funcionario, @nome_funcionario,@cpf,@cargo_funcionario, @email_comercial, @senha_funcionario)";

                // Criando o comando
                using (MySqlCommand cmd = new MySqlCommand(comandoSQL, conexao))
                {
                    // Adicionando parâmetros
                    cmd.Parameters.AddWithValue("@id_funcionario", ID_func);
                    cmd.Parameters.AddWithValue("@nome_funcionario", Nome_func);
                    cmd.Parameters.AddWithValue("@cpf", CPF);
                    cmd.Parameters.AddWithValue("@cargo_funcionario", cargo_func);
                    cmd.Parameters.AddWithValue("@email_comercial", Email_func);
                    cmd.Parameters.AddWithValue("@senha_funcionario", Senha_func);

                    // Executando o comando
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Cliente adicionado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar cliente: " + ex.Message);
            }
        }

        public void ListarFuncionario(MySqlConnection conexao)
        {


          try
                {
   

    
    string sql = "SELECT * FROM FUNCIONARIO";
    MySqlCommand cmd = new MySqlCommand(sql, conexao);
    
    Console.WriteLine("Executando consulta...");
    
    
    MySqlDataReader reader = cmd.ExecuteReader();

   
    while (reader.Read())
    {
                    
       
        Console.WriteLine("\n\nID: " + reader["id_funcionario"]);
        Console.WriteLine("Nome: " + reader["nome_funcionario"]);
        Console.WriteLine("CPF: " + reader["cpf"]);
        Console.WriteLine("Cargo :" + reader["cargo_funcionario"]);
        Console.WriteLine("Email: " + reader["email_comercial"]);


    }
                if (!reader.HasRows) {
                    Console.WriteLine("Nenhum funcionario encontrado");
                }

                reader.Close(); 
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao buscar dados: " + ex.Message);
}
finally
{
   
        conexao.Close();
        
    }
}

        public void DeletarFuncionario(MySqlConnection conexao)
        {
            try
            {
                Console.WriteLine("Digite o ID do funcionario a ser removido:");
                ID_func = int.Parse(Console.ReadLine()); 
                string sql = "DELETE FROM FUNCIONARIO WHERE id_funcionario=@id_funcionario";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    
                    
                    cmd.Parameters.AddWithValue("@id_funcionario",ID_func);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Funcionário removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum funcionário encontrado com o ID especificado.");
                    }
                }
            
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro:"+ex.Message);
            }
        }

        public void AtualizarFuncionario(MySqlConnection conexao)
        {
            try
            {
                Console.Write("Digite o ID do funcionario que deseja atualizar: ");
                ID_func = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do funcionário: ");
                string Nome_func = Console.ReadLine();

                Console.Write("Digite o CPF do funcionário: ");
                string CPF = Console.ReadLine();

                Console.Write("Digite o e-mail do funcionário: ");
                string Email_func = Console.ReadLine();

                Console.Write("Digite o cargo do funcionário: ");
                string cargo_func = Console.ReadLine();

                Console.Write("Digite a senha do funcionário: ");
                string Senha_func = Console.ReadLine();







                string sql = "UPDATE funcionario SET Nome_funcionario = @nome_funcionario, cpf = @cpf, email_comercial= @email_comercial, cargo_funcionario= @cargo_funcionario, senha_funcionario=@senha_funcionario WHERE Id_funcionario = @id_funcionario";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_funcionario", ID_func);
                    cmd.Parameters.AddWithValue("@nome_funcionario",Nome_func);
                    cmd.Parameters.AddWithValue("cpf", CPF);
                    cmd.Parameters.AddWithValue("@email_comercial", Email_func);
                    cmd.Parameters.AddWithValue("@cargo_funcionario", cargo_func);
                    cmd.Parameters.AddWithValue("@senha_funcionario", Senha_func);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados do funcionário atualizados com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum funcionário encontrado com o ID fornecido.");
                    }


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro:"+ex.Message);
            }
        }

        }
    }











