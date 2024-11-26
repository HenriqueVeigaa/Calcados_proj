using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaAsa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringConexao = "server=127.0.0.1;uid=root;pwd=;database=asaP;";

           
            MySqlConnection conexao = new MySqlConnection(stringConexao);

            // Instanciando a classe Cliente
            Funcionario f1 = new Funcionario();
            Produto p1 = new Produto();
            Estoque e1 = new Estoque();
            Fornecedor forn = new Fornecedor();
            bool continuar = true;
            while (continuar)
            {
                try
                {
                    // Abrindo a conexão
                    conexao.Open();


                    
                    Console.WriteLine("---Bem-Vindo---\n\nO que deseja acessar?\n1-Tela de Funcionario\n2-Tela de Produtos\n3-Tela de Estoque\n4-Tela de Fornecedores\n5-Tela de Pedidos\nQ-Sair do Sistema");

                    string op1 = Console.ReadLine();

                    switch (op1)
                    {
                        case "1":
                            Console.WriteLine("O que deseja fazer?\n1-Cadastrar Funcionarios\n2-Listar Funcionarios\n3-Demitir Funcionarios\n4-Atualizar dados");
                            int op2 = int.Parse(Console.ReadLine());

                            if (op2 == 1)
                            {
                                f1.GetDados();
                                f1.AdicionarFuncionario(conexao);
                            }
                            if(op2 == 2)
                            {
                                f1.ListarFuncionario(conexao);
                            }
                            if (op2 == 3)
                            {
                                f1.DeletarFuncionario(conexao);
                            }
                            if(op2 == 4)
                            {
                                f1.AtualizarFuncionario(conexao);
                            }
                            break;
                        case "2": Console.WriteLine("O que deseja fazer?\n1-Cadastrar Produtos\n2-Listar Produtos Disponiveis\n3-Deletar Produtos\n4-Atualizar dados");
                            int op3 = int.Parse(Console.ReadLine());
                            if (op3 == 1)
                            {
                                p1.GetDadosProd();
                                p1.AdicionarProduto(conexao);
                            }
                            if(op3 == 2)
                            {
                                p1.ListarProdutos(conexao);
                            }
                            if(op3 == 3)
                            {
                                p1.DeletarProduto(conexao);
                            }
                            if(op3 == 4)
                            {
                                p1.AtualizarProduto(conexao);
                            }

                            break;

                        case "3":
                            Console.WriteLine("O que deseja fazer?1-Atualizar estoque\n2-Listar o estoque\n3-Deletar produtos do estoque");
                            int op4 = int.Parse(Console.ReadLine());
                            if(op4 == 1)
                            {
                                e1.GetDadosEstoque();
                                e1.AtualizarEstoque(conexao);
                            }
                            if(op4 == 2)
                            {
                                e1.ListarEstoque(conexao);
                            }
                            if(op4 == 3)
                            {
                                e1.RemoverEstoque(conexao);
                            }
                            if(op4 == 4)
                            {
                                e1.AtualizarEstoque(conexao);
                            }

                            break;

                        case "4":
                            Console.WriteLine("O que deseja fazer?\n1-Adicionar Fornecedores\n2-Listar Fornecedores\n3-Remover Fornecedores\n4-Atualizar dados dos fornecedores");
                            int op5 = int.Parse(Console.ReadLine());
                            if(op5 == 1)
                            {
                                forn.GetDadosFornecedor();
                                forn.AdicionarFornecedor(conexao);
                            }
                            if( op5 == 2)
                            {
                                forn.ListarFornecedor(conexao);
                            }
                            if(op5 == 3)
                            {
                                forn.RemoverFornecedor(conexao);
                            }
                            if(op5 == 4)
                            {
                                forn.AtualizarFornecedor(conexao);
                            }
                            break;



                        case "Q":
                            Console.WriteLine("Saindo do Software em:");
                            for ( int n1 = 3; n1 >= 0; n1--)
                            {
                                Thread.Sleep(1200);
                                Console.WriteLine(n1);
                            }
                            Environment.Exit(0);
                            break;

                           
                        default: 
                            Console.WriteLine("Opção Invalida!! Insira outra opção");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                finally
                {
                 
                        conexao.Close();
                       
                    
                }
                int n;
                Console.WriteLine("Deseja Continuar?\nS/N");
                 string resposta = Console.ReadLine();
                if (resposta == "N")
                {
                    continuar = false;
                    Console.WriteLine("Saindo do Sistema!!");
                    for (n = 3; n >= 0; n--)
                    {
                        Thread.Sleep(700);
                        Console.WriteLine(n);
                    }
                    Environment.Exit(0);
                }
                Console.WriteLine("/-----------------------------/");
                Console.WriteLine("Voltando ao Sistema!!\n\nAguarde um Momento");
                for (n = 3; n >= 0; n--)
                {
                    Thread.Sleep(650);
                    Console.WriteLine(n);
                }
                Console.WriteLine("*------------------------------*");

                Console.ReadKey();
            }
            
        }
    }
    
        }
    

