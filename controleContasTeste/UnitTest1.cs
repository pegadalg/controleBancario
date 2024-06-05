using static System.Net.Mime.MediaTypeNames;
using controleContas.Models;
using controleContas.Exceptions;

namespace controleContasTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ContaTeste
        {
            [TestMethod]
            public void DeveDepositar()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //A��o
                conta1.Depositar(1000);
                //verifica��o
                Assert.AreEqual(2000, conta1.Saldo);
            }

            [TestMethod]

            public void DeveSacar()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //A��o
                conta1.Sacar(500);
                //verifica��o
                Assert.AreEqual(499.90, conta1.Saldo);
            }

            [TestMethod]

            public void DeveFalharAoSacar()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Sacar(1500));
                //verifica��o
                Assert.AreEqual($"Valor de saque {1500:C} � maior que o saldo atual. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]
            public void DeveFalharAoFazerDeposito()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(-1));
                //verifica��o
                Assert.AreEqual($"O valor de dep�sito: {-1:C} � inv�lido. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveTransferir()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta(1000, cliente2);
                //A��o
                conta1.Transferir(conta2,100);
                //verifica��o
                Assert.AreEqual(900, conta1.Saldo);
                Assert.AreEqual(1100, conta2.Saldo);
            }

            [TestMethod]

            public void DeveFalharAoTransferir()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta( 1000, cliente2);
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(conta2,2000));
                //verifica��o
                Assert.AreEqual("Saldo insuficiente para transfer�ncia. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoTransferirValorInvalido()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta(1000, cliente2);
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(conta2 ,- 1, ));
                //verifica��o
                Assert.AreEqual("O valor de transfer�ncia � inv�lido. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveMostrarIdadeEmRomano()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
                //A��o
                cliente1.MostrarIdadeEmRomano();
                //verifica��o
                Assert.AreEqual("XXIV", cliente1.MostrarIdadeEmRomano());
            }

            [TestMethod]

            public void DeveFalharAoCriarClienteMenorDe18Anos()
            {

                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("Jo�o", "12345678901", 2024));
                //verifica��o
                Assert.AreEqual("O Cliente deve ser maior de idade. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoCriarClienteComCpfInvalido()
            {
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("Jo�o", "1234567890", 2000));
                //verifica��o
                Assert.AreEqual("O CPF deve conter 11 caracteres, sendo os 11 apenas n�meros. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveCriarCliente()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
                //verifica��o
                Assert.AreEqual("Jo�o", cliente1.Nome);
                Assert.AreEqual("12345678901", cliente1.Cpf);
                Assert.AreEqual(2000, cliente1.AnoNascimento);
            }

            [TestMethod]

            public void DeveCriarConta()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
                //A��o
                var conta1 = new Conta(1234, 1000, cliente1);
                //verifica��o
                Assert.AreEqual(1234, conta1.Numero);
                Assert.AreEqual(1000, conta1.Saldo);
                Assert.AreEqual(cliente1, conta1.Cliente);
            }

            [TestMethod]

            public void DeveFalharAoCriarContaComSaldoMenorQue10()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Conta(1234, 1, cliente1));
                //verifica��o
                Assert.AreEqual("O cliente Jo�o deve ter o saldo maior do que 10. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoCriarContaComClienteNulo()
            {
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Conta(1234, 1000, null));
                //verifica��o
                Assert.AreEqual("Cliente n�o pode ser nulo. Programa ir� se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveCriarAgencia()
            {
                //cen�rio
                var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
                var conta1 = new Conta(1234, 1000, cliente1);
                //A��o
                var agencia1 = new Agencia(1234, conta1);
                //verifica��o
                Assert.AreEqual(1234, agencia1.Numero);
                Assert.AreEqual(conta1, agencia1.Contas[0]);
            }

            [TestMethod]

            public void DeveFalharAoCriarAgenciaComContaNula()
            {
                //A��o
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Agencia(1234, null));
                //verifica��o
                Assert.AreEqual("Conta n�o pode ser nula. Programa ir� se encerrar", ex.Message);
            }
        }
    }
}