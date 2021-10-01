using System;

namespace Banco
{
    public class Conta
    {

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) {
            if(this.Saldo - valorSaque < (this.Credito * -1)) {
                try {

                  Console.WriteLine("Erro. Saldo insuficiente");

                }catch (Exception error) {

                    Console.WriteLine($"Tipo de erro: {error}");

                }

                return false;
            }else {
                this.Saldo -= valorSaque;

                Console.WriteLine("O Saldo atual da conta de {0} é: {1}", this.Nome, this.Saldo);

                return true;
            }    
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito;

            Console.WriteLine("O Saldo atual da conta de {0} é: {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) {
            if(this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString() {
            string retornar = " ";
            retornar += "Tipo de conta " + this.TipoConta + "\n";
            retornar += "Nome: " + this.Nome + "\n";
            retornar += "Saldo: " + this.Saldo + "\n";
            retornar += "Crédito: " + this.Credito + "\n";

            Console.WriteLine("\n");
            Console.WriteLine("------------------------------------\n");
        
            return retornar;
        }
        
    }
}