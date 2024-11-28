using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace SistemaAsa
{
    internal class Cliente
    {

        protected string nome_cli { get; set; }
        protected string CPF { get; set; }

        protected string email_pessoal { get; set; }

        protected string senha_cli { get; set; }
        protected int IdPed {  get; set; }

        protected string RG { get; set; }

        protected int ID { get; set; }
        protected int ProdID {  get; set; }
        protected string metodopagamento {  get; set; }
       

        public void GetDadosCli()
        {

            Console.WriteLine("\nInforme seu Nome:");
            nome_cli = Console.ReadLine();
            Console.WriteLine("Informe seu CPF:");
            CPF = Console.ReadLine();
            Console.WriteLine("Informe seu email pessoal:");
            email_pessoal = Console.ReadLine();
            Console.WriteLine("Informe a senha:");
            senha_cli = Console.ReadLine();
            Console.WriteLine("Informe seu RG:");
            RG = Console.ReadLine();

        }
        public void AdicionarCliente(MySqlConnection conexao)
        {
            try
            {


                string sql = "INSERT INTO cliente(nome_cliente,cpf,email_pessoal,senha_cliente,RG)" +
                    "VALUES(@nome_cliente,@cpf,@email_pessoal,@senha_cliente,@RG)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome_cliente", nome_cli);
                    cmd.Parameters.AddWithValue("@cpf",CPF);
                    cmd.Parameters.AddWithValue("@email_pessoal", email_pessoal);
                    cmd.Parameters.AddWithValue("@senha_cliente", senha_cli);
                    cmd.Parameters.AddWithValue("@RG",RG);



                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Cliente adicionado com sucesso.\n");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar cliente!" + ex.Message);
            }



        }
        public void ListarCliente(MySqlConnection conexao)
        {
            try
            {



                string sql = "SELECT * FROM cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                Console.WriteLine("Executando consulta...");


                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {


                    Console.WriteLine("\n\nID: " + reader["id_cliente"]);
                    Console.WriteLine("Nome: " + reader["nome_cliente"]);
                    Console.WriteLine("CPF: " + reader["cpf"]);
                    Console.WriteLine("Email :" + reader["email_pessoal"]);
                    Console.WriteLine("Senha: " + reader["senha_cliente"]);
                    Console.WriteLine("RG " + reader["RG"]);


                }
                if (!reader.HasRows)
                {
                    Console.WriteLine("Nenhum cliente encontrado\n");
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

        public void GetDadosPed()
        {
            Console.WriteLine("\nDigite o ID do pedido:");
            IdPed = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o ID do cliente:");
             ID = int.Parse(Console.ReadLine());
            Console.WriteLine("\nDigite o ID do produto a ser comprado:");
            ProdID = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInforme o metodo de pagamento:");
            metodopagamento = Console.ReadLine();
        }

        public void FazerPedido(MySqlConnection conexao)
        {

            try
            {


                string sql = "INSERT INTO pedido(id_pedido,cliente_id,produto_id,metodo_pagamento)" +
                    "VALUES(@id_pedido,@cliente_id,@produto_id,@metodo_pagamento)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_pedido", IdPed);
                    cmd.Parameters.AddWithValue("@cliente_id", ID);
                    cmd.Parameters.AddWithValue("@produto_id", ProdID);
                    cmd.Parameters.AddWithValue("@metodo_pagamento", metodopagamento);



                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Pedido feito com sucesso.\n");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer o pedido!" + ex.Message);
            }

        }
        public void ListarPedidos(MySqlConnection conexao) {

            try
            {



                string sql = "SELECT * FROM pedido";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                Console.WriteLine("Executando consulta...");


                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {


                    Console.WriteLine("\n\nID Pedido: " + reader["id_pedido"]);
                    Console.WriteLine("ID Cliente: " + reader["cliente_id"]);
                    Console.WriteLine("ID Produto: " + reader["produto_id"]);
                    Console.WriteLine("Método de Pagamento:: " + reader["metodo_pagamento"]);
                   


                }
                if (!reader.HasRows)
                {
                    Console.WriteLine("Nenhum pedido encontrado\n");
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

    }
    }
    

