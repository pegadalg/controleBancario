/*
 * Classe Conta com -numero privadodo tipo long, #saldo protected do tipo double. Metodos contrutor Conta passando saldo como parametro e metodo construtor Conta com cliente como parametro. Metodos Depositar do tipo void passando um valor double como parametro, Sacar do tipo bool passando um valor double como parametro e Transferir do tipo void passando um valor double e uma conta como parametro.
 * Classe Cliente com -nome privado do tipo string, -cpf privado do tipo string,  -email privado do tipo string, -anoNascimento privado do tipo int. Metodos construtor Cliente passando nome, cpf como parametro.
 * Classe ContaEspecial com -limite privado do tipo double. 
 * */

using controleContas.Exceptions;
using controleContas.Models;


try
{
    Cliente cliente1 = new Cliente("João", "12345678901", 2000);
    Cliente cliente2 = new Cliente("Maria", "09876543210", 1990);

    var conta1 = new Conta(123, 100, cliente1);
    var conta2 = new Conta(654321, 2341.42m, cliente2);

    var agencia1 = new Agencia(1237, conta1);
    var agencia2 = new Agencia(1237, conta2);

    var banco1 = new Banco("Banco do Brasil", "001", agencia1);
    var banco2 = new Banco("Banco Itaú", "341", agencia2);

    var SaldoInicialConta1 = conta1.Saldo;
    var SaldoInicialConta2 = conta2.Saldo;

    var SaldoInicialTotalGeral = SaldoInicialConta1 + SaldoInicialConta2;

    Console.WriteLine("-----------\nCliente 1\n-----------\n");

    Console.WriteLine($"Nome: {cliente1.Nome}");
    Console.WriteLine($"CPF: {cliente1.Cpf}");
    Console.WriteLine($"Idade: {cliente1.Idade}");
    Console.WriteLine($"Idade em Romano: {cliente1.MostrarIdadeEmRomano()}");

    Console.WriteLine($"Conta: {conta1.Numero}");
    Console.WriteLine($"Saldo: {conta1.Saldo:C}");
    Console.WriteLine($"Agencia: {agencia1.Numero}");
    Console.WriteLine($"Banco: {banco1.Nome}\n");

    Console.WriteLine("-----------\nCliente 2\n-----------\n");

    Console.WriteLine($"Nome: {cliente2.Nome}");
    Console.WriteLine($"CPF: {cliente2.Cpf}");
    Console.WriteLine($"Idade: {cliente2.Idade}");
    Console.WriteLine($"Idade em Romano: {cliente2.MostrarIdadeEmRomano()}");

    Console.WriteLine($"Conta: {conta2.Numero}");
    Console.WriteLine($"Saldo: {conta2.Saldo:C}");
    Console.WriteLine($"Agencia: {agencia2.Numero}");
    Console.WriteLine($"Banco: {banco2.Nome}\n");
    Console.WriteLine("---------------------------------\n");
    //
    var valorDeposito = 5000;
    Console.WriteLine($"Conta {conta1.Numero} - Cliente: {cliente1.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta1.Depositar(valorDeposito);
    Console.WriteLine($"Saldo do cliente {cliente1.Nome} após deposito: {conta1.Saldo:C}\n");

    var valorSaque = 1900;
    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta1.Sacar(valorSaque);
    Console.WriteLine($"Saldo do cliente {cliente1.Nome} após saque é: {conta1.Saldo:C} \n");
    /////////////////////////////////
    Console.WriteLine($"Conta {conta2.Numero} - Cliente: {cliente2.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta2.Depositar(valorDeposito);
    Console.WriteLine($"Saldo do cliente {cliente2.Nome} após deposito: {conta2.Saldo:C}\n");

    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta2.Sacar(valorSaque);
    Console.WriteLine($"Saldo do cliente {cliente2.Nome} após saque é: {conta2.Saldo:C} \n");

    var saldoTotal = conta1.Saldo + conta2.Saldo;
    Console.WriteLine($"Saldo total das duas contas: {saldoTotal:C}");

    if (conta1.Saldo > conta2.Saldo)
    {
        Console.WriteLine($"Conta com maior saldo: {conta1.Numero} - Saldo: {conta1.Saldo}");
    }
    else
    {
        Console.WriteLine($"Conta com maior saldo: {conta2.Numero} - Saldo: {conta2.Saldo}");
    }

    Console.WriteLine($"Saldo inicial total conta 1: {SaldoInicialConta1:C}");
    Console.WriteLine($"Saldo inicial total conta 2: {SaldoInicialConta2:C}");
    Console.WriteLine($"Saldo inicial Total Geral: {SaldoInicialTotalGeral:C}");
    Console.WriteLine("\n");

    conta1.Transferir(100, conta2);
}
catch (OperacaoInvalidaException ex)
{

    Console.WriteLine(ex.Message);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}