using System.ComponentModel;
using static System.Console;

namespace SapiensBank;

public class Tela
{
    private readonly Banco _banco = new Banco();
    public Tela(Banco banco)
    { 
        _banco = banco;
    }
    public void Executar()
    {
        var opcao = "";
        do { 
            opcao = CriarMenu();
            switch (opcao)
            {
                case "1": ContaMenu(); break;
                case "2": ListarContasMenu(); break;
            }
        } while (opcao != "0");
    }
    public string CriarMenu()
    {
        Clear();
        CriarTitulo("    Bem-vindo ao Sapiens Bank!  ");
        WriteLine(" 1 - Criar Conta");
        WriteLine(" 2 - Listar Contas");
        WriteLine(" 3 - Efetuar Saque");
        WriteLine(" 4 - Efetuar Depósito");

        ForegroundColor = System.ConsoleColor.Red;
        WriteLine("\n 0 - Sair");
        ResetColor();

        CriarLinha();

        ForegroundColor = System.ConsoleColor.Yellow;
        Write(" Selecione uma opção: ");
        var opcao = ReadLine() ?? "";
        ResetColor();
        return opcao;
    }
    public void ContaMenu()
    {
        Clear(); 
        CriarTitulo("    Criar Conta");
        Write(" Numero: ");
        var numero = Convert.ToInt32(ReadLine());
        Write(" Cliente: ");
        var cliente = ReadLine() ?? "";
        Write(" CPF: ");
        var cpf = ReadLine() ?? "";
        Write(" Senha: ");
        var senha = ReadLine() ?? "";
        Write(" Limite: ");
        var limite = Convert.ToDecimal(ReadLine());

        var conta = new Conta(numero, cliente, cpf, senha, limite);
        _banco.Contas.Add(conta);

        CriarLinha();

        ForegroundColor = System.ConsoleColor.Green;
        Write(" Conta criada com sucesso!");
        ResetColor();
        ReadLine();
        _banco.SaveContas();
    }
    public void ListarContasMenu()
    {
        Clear();
        CriarTitulo("    Listar Contas");
        foreach (var conta in _banco.Contas)
        {
            WriteLine($" Conta {conta.Numero} | {conta.Cliente}");
            WriteLine($" Limite: {conta.Limite:C} | Saldo: {conta.Saldo:C} | Saldo Disponível: {conta.SaldoDisponivel:C}\n");
        }

        CriarLinha();

        ForegroundColor = System.ConsoleColor.Green;
        Write(" Pressione Enter para continuar...");
        ResetColor();
        ReadLine();
    }
    public void CriarTitulo(string titulo)
    {
        WriteLine("===================================");
        ForegroundColor = System.ConsoleColor.Yellow;
        WriteLine(titulo);
        ResetColor();
        WriteLine("===================================");
    }
    public void CriarLinha()
    {
        WriteLine("-----------------------------------");
    }
}