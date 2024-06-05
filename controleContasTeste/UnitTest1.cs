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
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //Ação
                conta1.Depositar(1000);
                //verificação
                Assert.AreEqual(2000, conta1.Saldo);
            }

            [TestMethod]

            public void DeveSacar()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //Ação
                conta1.Sacar(500);
                //verificação
                Assert.AreEqual(499.90, conta1.Saldo);
            }

            [TestMethod]

            public void DeveFalharAoSacar()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Sacar(1500));
                //verificação
                Assert.AreEqual($"Valor de saque {1500:C} é maior que o saldo atual. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]
            public void DeveFalharAoFazerDeposito()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(-1));
                //verificação
                Assert.AreEqual($"O valor de depósito: {-1:C} é inválido. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveTransferir()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta(1000, cliente2);
                //Ação
                conta1.Transferir(conta2,100);
                //verificação
                Assert.AreEqual(900, conta1.Saldo);
                Assert.AreEqual(1100, conta2.Saldo);
            }

            [TestMethod]

            public void DeveFalharAoTransferir()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta( 1000, cliente2);
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(conta2,2000));
                //verificação
                Assert.AreEqual("Saldo insuficiente para transferência. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoTransferirValorInvalido()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901");
                var conta1 = new Conta(1000, cliente1);
                var cliente2 = new Cliente("Maria", "12345678901");
                var conta2 = new Conta(1000, cliente2);
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(conta2 ,- 1, ));
                //verificação
                Assert.AreEqual("O valor de transferência é inválido. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveMostrarIdadeEmRomano()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901", 2000);
                //Ação
                cliente1.MostrarIdadeEmRomano();
                //verificação
                Assert.AreEqual("XXIV", cliente1.MostrarIdadeEmRomano());
            }

            [TestMethod]

            public void DeveFalharAoCriarClienteMenorDe18Anos()
            {

                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("João", "12345678901", 2024));
                //verificação
                Assert.AreEqual("O Cliente deve ser maior de idade. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoCriarClienteComCpfInvalido()
            {
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("João", "1234567890", 2000));
                //verificação
                Assert.AreEqual("O CPF deve conter 11 caracteres, sendo os 11 apenas números. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveCriarCliente()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901", 2000);
                //verificação
                Assert.AreEqual("João", cliente1.Nome);
                Assert.AreEqual("12345678901", cliente1.Cpf);
                Assert.AreEqual(2000, cliente1.AnoNascimento);
            }

            [TestMethod]

            public void DeveCriarConta()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901", 2000);
                //Ação
                var conta1 = new Conta(1234, 1000, cliente1);
                //verificação
                Assert.AreEqual(1234, conta1.Numero);
                Assert.AreEqual(1000, conta1.Saldo);
                Assert.AreEqual(cliente1, conta1.Cliente);
            }

            [TestMethod]

            public void DeveFalharAoCriarContaComSaldoMenorQue10()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901", 2000);
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Conta(1234, 1, cliente1));
                //verificação
                Assert.AreEqual("O cliente João deve ter o saldo maior do que 10. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveFalharAoCriarContaComClienteNulo()
            {
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Conta(1234, 1000, null));
                //verificação
                Assert.AreEqual("Cliente não pode ser nulo. Programa irá se encerrar", ex.Message);
            }

            [TestMethod]

            public void DeveCriarAgencia()
            {
                //cenário
                var cliente1 = new Cliente("João", "12345678901", 2000);
                var conta1 = new Conta(1234, 1000, cliente1);
                //Ação
                var agencia1 = new Agencia(1234, conta1);
                //verificação
                Assert.AreEqual(1234, agencia1.Numero);
                Assert.AreEqual(conta1, agencia1.Contas[0]);
            }

            [TestMethod]

            public void DeveFalharAoCriarAgenciaComContaNula()
            {
                //Ação
                var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Agencia(1234, null));
                //verificação
                Assert.AreEqual("Conta não pode ser nula. Programa irá se encerrar", ex.Message);
            }
        }
    }
}