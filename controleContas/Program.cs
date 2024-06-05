using controleContas.Exceptions;
using controleContas.Models;


try
{
    Cliente cliente1 = new Cliente("João", "12345678901");
    Cliente cliente2 = new Cliente("Maria", "09876543210");

    var conta1 = new Conta(100, cliente1);
    var conta2 = new Conta(cliente2);

    var SaldoInicialConta1 = conta1.Saldo;
    var SaldoInicialConta2 = conta2.Saldo;

    var SaldoInicialTotalGeral = SaldoInicialConta1 + SaldoInicialConta2;

    Console.WriteLine("-----------\nCliente 1\n-----------\n");

    Console.WriteLine($"Nome: {cliente1.Nome}");
    Console.WriteLine($"CPF: {cliente1.Cpf}");
    Console.WriteLine($"Saldo: {conta1.Saldo:C}");

    Console.WriteLine("-----------\nCliente 2\n-----------\n");

    Console.WriteLine($"Nome: {cliente2.Nome}");
    Console.WriteLine($"CPF: {cliente2.Cpf}");
    Console.WriteLine($"Saldo: {conta2.Saldo:C}");

    Console.WriteLine("---------------------------------\n");
    //
    var valorDeposito = 5000;
    Console.WriteLine($"Cliente: {cliente1.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta1.Depositar(valorDeposito);
    Console.WriteLine($"Saldo do cliente {cliente1.Nome} após deposito: {conta1.Saldo:C}\n");

    var valorSaque = 1900;
    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta1.Sacar(valorSaque);
    Console.WriteLine($"Saldo do cliente {cliente1.Nome} após saque é: {conta1.Saldo:C} \n");
    /////////////////////////////////
    Console.WriteLine($"Cliente: {cliente2.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta2.Depositar(valorDeposito);
    Console.WriteLine($"Saldo do cliente {cliente2.Nome} após deposito: {conta2.Saldo:C}\n");

    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta2.Sacar(valorSaque);
    Console.WriteLine($"Saldo do cliente {cliente2.Nome} após saque é: {conta2.Saldo:C} \n");

    var saldoTotal = conta1.Saldo + conta2.Saldo;
    Console.WriteLine($"Saldo total das duas contas: {saldoTotal:C}");


    Console.WriteLine($"Saldo inicial total conta 1: {SaldoInicialConta1:C}");
    Console.WriteLine($"Saldo inicial total conta 2: {SaldoInicialConta2:C}");
    Console.WriteLine($"Saldo inicial Total Geral: {SaldoInicialTotalGeral:C}");
    Console.WriteLine("\n");

    conta1.Transferir(conta2,100);
}
catch (OperacaoInvalidaException ex)
{

    Console.WriteLine(ex.Message);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}