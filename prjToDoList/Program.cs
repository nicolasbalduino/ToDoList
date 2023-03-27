using prjToDoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> categories = new List<string>();
        List<Person> people = new List<Person>();
        List<Todo> toDoList = new List<Todo>();

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
                    break;

                case 7:
                    break;

                case 8:
                    Thread.Sleep(1000);
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
        Console.WriteLine("|     1 - Cadastrar nova tarefa           |");
        Console.WriteLine("|     2 - Listar tarefas cadastradas      |");
        Console.WriteLine("|     3 - Alterar tarefa cadastrada       |");
        Console.WriteLine("|     4 - Cadastrar nova categoria        |");
        Console.WriteLine("|     5 - Listar Categorias               |");
        Console.WriteLine("|     6 - Cadastrar nova pessoa           |");
        Console.WriteLine("|     7 - Listar pessoas cadastradas      |");
        Console.WriteLine("|     8 - sair                            |");
        Console.WriteLine("|_________________________________________|");

        if (!int.TryParse(Console.ReadLine(), out var option))        
            return option;       
    }
}