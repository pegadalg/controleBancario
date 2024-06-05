using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas.Exceptions
{
    public class OperacaoInvalidaException : Exception
    {
        public OperacaoInvalidaException() : base("Operação inválida")
        {

        }

        public OperacaoInvalidaException(string message) : base(message)
        {

        }




    }
}
