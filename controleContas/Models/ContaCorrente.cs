using controleContas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Models
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Cliente cliente) : base(cliente)
        {
        }
        public ContaCorrente(double saldo, Cliente cliente) : base(saldo, cliente)
        {
        }

        protected int numero;
        protected string titular;
        protected double saldo;
        protected string senha;

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

        public int Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new OperacaoInvalidaException("Depósito deve ser maior que 0.00");
            }
            Saldo += valor;
            return 1;
        }

        public void consultarSaldo()
        {
            Console.WriteLine($"Saldo atual: {Saldo:C}");
        }


    }
}
