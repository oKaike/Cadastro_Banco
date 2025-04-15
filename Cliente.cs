using System;

internal class Cliente
{
    public string nome;
    public string cpf;
    public int senha;
    public int idade;

    public virtual void CadastrarCliente()
    {
        Console.WriteLine("Digite seu nome:");
        nome = Console.ReadLine();

        Console.WriteLine("Digite seu CPF:");
        cpf = Console.ReadLine();

        Console.WriteLine("Digite sua senha (apenas números):");
        senha = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite sua idade:");
        idade = int.Parse(Console.ReadLine());
    }
    }