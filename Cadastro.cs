using System;

internal class Cadastro : Cliente
{
    public string opcao;
    public Cliente[] cadastro = new Cliente[4];

    public override void CadastrarCliente()
    {
        Console.WriteLine("Digite\n C: Para cadastrar um novo cliente\n F: Para checar sua posição na fila\n Q: Para fechar o programa\n A: Para atender um cliente");
        opcao = Console.ReadLine();

        while (opcao.ToUpper() == "C")
        {
            int i = 0;
            while (i < cadastro.Length && cadastro[i] != null)
                i++;

            if (i == cadastro.Length)
            {
                Console.WriteLine("Fila cheia. Não é possível cadastrar mais clientes.");
                break;
            }

            cadastro[i] = new Cliente();
            cadastro[i].CadastrarCliente();

            // Prioridade para idosos
            if (cadastro[i].idade >= 80 && i != 0)
            {
                Cliente temp = cadastro[0];
                cadastro[0] = cadastro[i];
                cadastro[i] = temp;
                Console.WriteLine("Você tem prioridade na fila! Sua nova posição é: 1." + cadastro[0].nome);
            }

            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Deseja cadastrar mais um cliente?\nC: continuar\nF: checar fila\nQ: sair\nA: atender cliente");
            opcao = Console.ReadLine();

            if (opcao.ToUpper() == "A") atenderCliente(opcao, cadastro);
            else if (opcao.ToUpper() == "F") listaClientes(opcao, cadastro);
        }
    }

    public virtual void listaClientes(string opcao, Cliente[] cadastro)
    {
        if (opcao.ToUpper() == "F")
        {
            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite sua senha:");
            int senha = int.Parse(Console.ReadLine());

            bool encontrado = false;

            for (int i = 0; i < cadastro.Length; i++)
            {
                if (cadastro[i] != null && cadastro[i].nome == nome && cadastro[i].senha == senha)
                {
                    Console.WriteLine("Seu nome está na fila.");
                    Console.WriteLine("Sua posição na fila é: " + (i + 1) + "." + cadastro[i].nome);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Cliente não encontrado.");
                Console.WriteLine("Por favor, cadastre-se.");
                CadastrarCliente();
            }

            Console.WriteLine("Deseja ver a fila avançada? [S/N]");
            string avancada = Console.ReadLine();

            if (avancada.ToUpper() == "S")
            {
                Console.WriteLine("Fila avançada:");
                for (int j = 0; j < cadastro.Length; j++)
                {
                    if (cadastro[j] != null)
                        Console.WriteLine((j + 1) + "." + cadastro[j].nome);
                }
            }
        }
    }

    public virtual void atenderCliente(string opcao, Cliente[] cadastro)
    {
        if (opcao.ToUpper() == "A")
        {
            if (cadastro[0] != null)
            {
                Console.WriteLine("Atendendo o cliente: " + cadastro[0].nome);
                for (int i = 0; i < cadastro.Length - 1; i++)
                {
                    cadastro[i] = cadastro[i + 1];
                }
                cadastro[cadastro.Length - 1] = null;

                Console.WriteLine("Cliente atendido. Fila atualizada.");
            }
            else
            {
                Console.WriteLine("Fila vazia.");
            }
        }
    }
}