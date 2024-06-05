using controleContas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Models
{
    public class ContaCaixinha : Conta
    {
        public ContaCaixinha(Cliente cliente) : base(cliente)
        {
        }
        public ContaCaixinha(double saldo, Cliente cliente) : base(saldo, cliente)
        {
        }

        public override void Depositar(double valor)
        {
            if (valor <= 1)
            {
                throw new OperacaoInvalidaException("Depósito deve ser maior que 1.00");
            }
            Saldo += valor + 1;
        }

        public override bool Sacar(double valor)
        {
            if (Saldo - (valor + 5) >= 0)
            {
                Saldo -= valor + 5;
                return true;
            }
            else
            {
                throw new OperacaoInvalidaException("Valor do saque ultrapassa o saldo");
            }
        }

    }
}
