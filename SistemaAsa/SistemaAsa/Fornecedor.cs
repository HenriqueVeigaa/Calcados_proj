using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAsa
{
    internal class Fornecedor
    {
        protected int ID {  get; set; }
        protected string Nome_for { get; set; }
        protected string Telefone_for { get; set; }
        protected string Email_comercial {  get; set; }
        protected string CNPJ {  get; set; }
       


        public void GetDadosFornecedor()
        {
            Console.WriteLine("Informe o ID do fornecedor:");
            ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do fornecedor:");
            Nome_for = Console.ReadLine();
            Console.WriteLine("Informe o telefone de contato do fornecedor:");
            Telefone_for = Console.ReadLine();
            Console.WriteLine("Informe o CNPJ");
            CNPJ = Console.ReadLine();
        }
        public void AdicionarFornecedor (MySqlConnection conexao)
        {
            try
            {

                string SQL = "INSERT INTO Fornecedor (Id_fornecedor, Nome_fornecedor,telefone_comercial,email_suporte,cnpj, ) " +
                                    "VALUES (@id_fornecedor,@nome_fornecedor,@telefone_comercial,@email_suporte,@cnpj)";


                using (MySqlCommand cmd = new MySqlCommand(SQL, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_fornecedor", ID);
                    cmd.Parameters.AddWithValue("@nome_fornecedor",Nome_for);
                    cmd.Parameters.AddWithValue("@telefone_ccomercial", Telefone_for);
                    cmd.Parameters.AddWithValue("@email_suporte",Email_comercial);
                    cmd.Parameters.AddWithValue("@cnpj", CNPJ);
                


                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Fornecedor adicionado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar fornecedor: " + ex.Message);
            }

            
        }
        public void ListarFornecedor(MySqlConnection conexao)
        {
            try
            {
                string sql = "SELECT * FROM Fornecedor";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                Console.WriteLine("Consultando fornecedores...");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Nenhum fornecedor encontrado.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine("\nID do Fornecedor: " + reader["id_fornecedor"]);
                        Console.WriteLine("Nome do Fornecedor: " + reader["nome_fornecedor"]);
                        Console.WriteLine("Telefone Comercial : " + reader["telefone_comercial"]);
                        Console.WriteLine("Email Comercial: " + reader["email_suporte"]);
                        Console.WriteLine("CNPJ: " + reader["cnpj"]);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar fornecedores: " + ex.Message);
            }
        }
        public void RemoverFornecedor(MySqlConnection conexao)
        {
            try
            {
                Console.Write("Digite o ID do fornecedor a ser removido: ");
                ID = int.Parse(Console.ReadLine());

                string sql = "DELETE FROM Fornecedor WHERE id_fornecedor = @id_fornecedor";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_fornecedor", ID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Forneceodor removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum fornecedor encontrado com o ID fornecido.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar fornecedor: " + ex.Message);
            }
        }
        public void AtualizarFornecedor(MySqlConnection conexao)
        {
            try
            {
                Console.Write("Digite o ID do fornecedor que deseja atualizar: ");
                ID = int.Parse(Console.ReadLine());

                

                Console.WriteLine("\nInforme o nome do fornecedor:");
                Nome_for = Console.ReadLine();

                Console.WriteLine("\nInforme o telefone do fornecedor: ");
                Telefone_for = Console.ReadLine();

                Console.WriteLine("\nInforme o email do fornecedor:");
                Email_comercial = Console.ReadLine();

                Console.WriteLine("\nInforme o CNPJ: ");
                CNPJ = Console.ReadLine();

                

                string sql = "UPDATE Fornecedor SET nome_fornecedor = @nome_fornecedor, telefone_comercial = @telefone_comercial, email_suporte = @email_suporte, cnpj = @cnpj where id_fornecedor = @id_fornecedor";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {

                    cmd.Parameters.AddWithValue("@id_fornecedor", ID);
                    cmd.Parameters.AddWithValue("@nome_fornecedor", Nome_for);
                    cmd.Parameters.AddWithValue("@telefone_comercial", Telefone_for);
                    cmd.Parameters.AddWithValue("@email_suporte", Email_comercial);
                    cmd.Parameters.AddWithValue("@cnpj", CNPJ);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Fornecedor atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum fornecedor encontrado com o ID fornecido.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar fornecedor: " + ex.Message);
            }
        
    }
    }

    }

