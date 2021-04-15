using System;
using System.Collections;

namespace Bank.Models{
    public class Conta{
        private TipoConta TipoConta{get;set;}
        private double Saldo{get;set;}
        private double Credito{get;set;}
        private string Nome{get;set;}

        /// <summary>
        /// Metodo construtor da classe Conta
        /// </summary>
        /// <param name="tipo">1 - Pessoa Física, 2 - Pessoa Juridica</param>
        /// <param name="saldo">Saldo inicial da conta</param>
        /// <param name="credito">Crédito limite inicial da conta</param>
        /// <param name="nome">Nome do dono da conta</param>
        public Conta(TipoConta tipo, double saldo,double credito,string nome){
            this.TipoConta=tipo;
            this.Saldo=saldo;
            this.Credito=credito;
            this.Nome=nome;
        }

        /// <summary>
        /// Metodo de saque
        /// </summary>
        /// <param name="valorSaque">Valor a ser sacado da conta</param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo para depósito na conta
        /// </summary>
        /// <param name="valorDeposito">Valor a ser depositado</param>
        public void Depositar(double valorDeposito){
            this.Saldo+=valorDeposito;

            Console.WriteLine($"Saldo da conta de {this.Nome} após o deposito é de {this.Saldo}");
        }

        /// <summary>
        /// Metodo de transferencia de uma conta para outra
        /// </summary>
        /// <param name="valorTransferencia">Valor a ser transferido</param>
        /// <param name="contaDestino">Objeto da conta que recebera a transferencia</param>
        public void Transferir(double valorTransferencia,Conta contaDestino){
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }else{
                Console.WriteLine("Sua conta não contem o valor necessário para prosseguir com esta transferencia");
            }
        }

        /// <summary>
        /// Metodo utlizado para log da conta
        /// </summary>
        /// <returns>Retorna uma cadeia de caracteres que descrevem a conta</returns>
        public override string ToString(){
            return $"Conta: \n Nome:{this.Nome} \n Saldo:{this.Saldo} \n Credito:{this.Credito}";
        }
    }

}