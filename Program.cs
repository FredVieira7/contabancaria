using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X") {
                switch(opcaoUsuario) {
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
                        Console.WriteLine("Erro! Escolha uma opção válida.");
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços, volte sempre!");
            Console.ReadLine();
            
        }

        private static void InserirConta() {
            Console.WriteLine("Inserir nova conta. \n");
            Console.WriteLine("Digite 1 para conta Física ou 2 para Jurídica.");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do novo cliente: \n");
            string inserirNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: \n");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: \n");
            double creditoInicial = double.Parse(Console.ReadLine());


            Conta novaConta = new Conta(
            tipoConta: (TipoConta)entradaTipoConta,
            saldo: saldoInicial,
            credito: creditoInicial,
            nome: inserirNome
            
            );

            listContas.Add(novaConta);
        }

        private static void Sacar() {
            Console.WriteLine("Digite o número da conta.");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaqueConta = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaqueConta);
        }

        private static void Depositar() {
            Console.WriteLine("Digite o número da conta.");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDepositoConta = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDepositoConta);
        }

        private static void Transferir() {
            Console.WriteLine("Digite o número da conta de origem.");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino.");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferenciaConta = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferenciaConta, listContas[indiceContaDestino]);
        }

        private static void ListarContas() {
            Console.WriteLine("Listando as contas...");

            if(listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++) {
                Conta conta = listContas[i];
                Console.Write("#{0}", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine("\n\n");
            Console.WriteLine("Seja bem vindo(a)!!!");
            Console.WriteLine("Informe a opção desejada.");
            Console.WriteLine("\n");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("\n\n");

            string opcaoUsuario;
            opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("\n");

            return opcaoUsuario;
            
        }
    }
}
