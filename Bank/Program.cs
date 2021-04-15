using System;
using System.Collections.Generic;
using Bank.Models;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas=new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario=ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Escreva um dos caracteres validos acima!");
                        break;
                }
                opcaoUsuario=ObterOpcaoUsuario();
            }
            Console.WriteLine("Até mais!");
            Console.ReadKey();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem:");
            int indiceConta = int.Parse(Console.ReadLine())-1;

            Console.Write("Digite o numero da conta a receber a transferencia:");
            int contaDestino = int.Parse(Console.ReadLine())-1;

            Console.Write("Digite o valor a ser transferido: ");
            double valorDeposito=double.Parse(Console.ReadLine());

            listContas[indiceConta].Transferir(valorDeposito,listContas[contaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine())-1;

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito=double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine())-1;

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque=double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listando todas as contas:");

            if(listContas.Count==0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                Console.ReadKey();
                return;
            }

            int i=1;

            foreach(Conta conta in listContas)
            {
                Console.WriteLine($"Conta #{i}");
                Console.WriteLine(conta.ToString());

                Console.WriteLine();
                i++;
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nomeCliente=Console.ReadLine();

            Console.Write("Digite saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito=double.Parse(Console.ReadLine());

            Conta novaConta=new Conta((TipoConta)entradaTipoConta,entradaSaldo,entradaCredito,nomeCliente);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Olá!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
