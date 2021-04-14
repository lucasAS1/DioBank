using System;
using System.Collections;

namespace Bank.Models{
    public class Conta{
        private TipoConta TipoConta{get;set;}
        private double Saldo{get;set;}
        private double Credito{get;set;}
        private string Nome{get;set;}

        public Conta(TipoConta tipo, double saldo,double credito,string nome){
            this.TipoConta=tipo;
            this.Saldo=saldo;
            this.Credito=credito;
            this.Nome=nome;
        }

        public bool Sacar(double valorSaque){
            if(this.Saldo - valorSaque < (this.Credito*-1))
                {
                    Console.WriteLine("Saldo insuficiente para o saque escolhido");
                    return false;
                }
            else{ 
                this.Saldo-=valorSaque;

                Console.WriteLine($"Saldo da conta de {this.Nome} após o saque é de {this.Saldo}");
                return true;
                }
        }

        public void Depositar(double valorDeposito){
            this.Credito+=valorDeposito;

            Console.WriteLine($"Saldo da conta de {this.Nome} após o deposito é de {this.Saldo}");
        }

        public void Transferir(double valorTransferencia,Conta contaDestino){
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }else{
                Console.WriteLine("Sua conta não contem o valor necessário para prosseguir com esta transferencia");
            }
        }

        public override string ToString(){
            return $"Conta 01: \n Nome:{this.Nome} \n Saldo:{this.Saldo} \n Credito:{this.Credito}";
        }
    }

}