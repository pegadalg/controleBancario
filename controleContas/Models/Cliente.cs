using controleContas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace controleContas.Models
{
    public class Cliente
    {
        private string nome;
        private string cpf;
        private int anoNascimento;
        private string email;


        public Cliente(string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
            
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set 
            {
                if (!Regex.IsMatch(cpf, @"^\d{11}$"))
                {
                    throw new OperacaoInvalidaException("O CPF deve conter 11 caracteres, sendo os 11 apenas números. Programa irá se encerrar");
                }
                cpf = value;
            }
        }
        public int AnoNascimento
        {
            get { return anoNascimento; }
            set 
            {
                if (anoNascimento > DateTime.Now.Year - 18)
                {
                    throw new OperacaoInvalidaException("O Cliente deve ser maior de idade. Programa irá se encerrar");
                }
                anoNascimento = value; 
            }
        }

        public int Idade
        {
            get { return DateTime.Now.Year - anoNascimento; }
        }
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}