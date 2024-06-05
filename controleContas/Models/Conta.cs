using controleContas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Models
{
    public class Conta
    {
        private long _numero;
        protected double _saldo;
        private Cliente _cliente;

        public Conta(double saldo, Cliente cliente)
        {
            _saldo = saldo;
            _cliente = cliente;

            if (saldo > 10)
            {
                _saldo = saldo;
            }
            else
            {
                throw new OperacaoInvalidaException("Saldo deve ser maior que 10. Programa irá se encerrar");
            }


            if (cliente != null)
            {
                _cliente = cliente;
            }
            else
            {
                throw new OperacaoInvalidaException("Cliente não pode ser nulo. Programa irá se encerrar");

            }
        }

        public Conta(Cliente cliente)
        {
            
            _cliente = cliente;            

            if (cliente != null)
            {
                _cliente = cliente;
            }
            else
            {
                throw new OperacaoInvalidaException("Cliente não pode ser nulo. Programa irá se encerrar");

            }

            _saldo = 10;
        }     

        public long Numero
        {
            get => _numero;
            private set
            {
                _numero = value;
            }

        }
        public double Saldo
        {
            get => _saldo;
            protected set
            {
                _saldo = value;
            }
        }
        public Cliente Cliente
        {
            get => _cliente;
        }



        public virtual void Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor do depósito deve ser positivo.");
            }
            if (valor > 0)
            {
                _saldo += valor;
                Console.WriteLine($"Deposito realizado com sucesso. Saldo atual {_saldo}");
            }

        }

        public virtual bool Sacar(double valor)
        {
            if (_saldo - (valor + 0.10) >= 0)
            {
                _saldo -= valor + 0.10;
                return true;
            }
            else
            {
                throw new OperacaoInvalidaException("Valor do saque ultrapassa o saldo");
            }

        }

        public void Transferir(Conta conta, double valor)
        {
            if (_saldo - valor >= 0)
            {
                _saldo -= valor;
                conta.Depositar(valor);

                Console.WriteLine($"Transferência realizada com sucesso.");
                Console.WriteLine($"Saldo da conta destino: {conta.Saldo:C}");
                Console.WriteLine($"Saldo da conta atual: {_saldo:C}");
            }
            else
            {
                throw new OperacaoInvalidaException("Saldo insuficiente para transferência");
            }
        }

    }
}
