using controleContas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Models
{
    public class ContaEspecial : ContaCorrente
    {
        private double _limite;
        public ContaEspecial(Cliente cliente) : base(cliente)
        {
        }
        public ContaEspecial(double saldo , Cliente cliente) : base(saldo,cliente)
        {
        }


        public double Limite
        {
            get { return _limite; }
            private set { _limite = value; }
        }


        public override bool Sacar(double valor)
        {
            if (Saldo - (valor + 0.10) >= 0)
            {
                Saldo -= valor + 0.10;
                return true;
            }
            else
            {
                throw new OperacaoInvalidaException("Valor do saque ultrapassa o saldo");
            }

        }

        public bool Transferir(Conta destino, double valor)
        {
            if (Saldo - valor >= 0)
            {
                Saldo -= valor;
                destino.Depositar(valor);

                Console.WriteLine($"Transferência realizada com sucesso.");
                Console.WriteLine($"Saldo da conta destino: {destino.Saldo:C}");
                Console.WriteLine($"Saldo da conta atual: {Saldo:C}");
                return true;
            }
            else
            {
                throw new OperacaoInvalidaException("Saldo insuficiente para transferência");
            }
        }
    }
}
