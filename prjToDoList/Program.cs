internal class Program
{
    private static void Main(string[] args)
    {
        do
        {
            switch (Menu())
            {
                default:
                    Console.WriteLine("opção inválida!");
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    Console.WriteLine("Obrigado por utilizar os nossos serviços!");
                    Environment.Exit(0);
                    break;
            }
        }
        while (true);

    }
    static int Menu()
    {
        Console.Clear();
        Console.WriteLine(" _________________________________________");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|        Selecione a opção desejada       |");
        Console.WriteLine("|_________________________________________|");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     1 - Para cadastrar nova tarefa      |");
        Console.WriteLine("|     2 - Listar tarefas cadastradas      |");
        Console.WriteLine("|     3 - Alterar tarefa cadastrada       |");
        Console.WriteLine("|     4 - Cadastrar uma nova pessoa       |");
        Console.WriteLine("|     5 - Listar pessoas cadastradas      |");
        Console.WriteLine("|     6 - sair                            |");
        Console.WriteLine("|_________________________________________|");

        if (!int.TryParse(Console.ReadLine(), out var option))
        {
            Console.WriteLine("Tente novamente!");
            return -1;
        }
        else
        {
            return option;
        }
    }
}