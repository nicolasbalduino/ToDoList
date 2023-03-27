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
                    categories.Add(CreateCategory());
                    break;

                case 5:
                    ListCategories(categories);
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

    private static void ListCategories(List<string> categories)
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada!");
        }

        Console.WriteLine("Categorias:");

        foreach (string category in categories)
            Console.WriteLine(category);
    }

    private static string CreateCategory()
    {
        Console.Write("Digite o nome da nova categoria: ");
        return Console.ReadLine();
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

        int.TryParse(Console.ReadLine(), out var option); // Retorno padrão é zero! caso seja falso.
        return option;
    }
}