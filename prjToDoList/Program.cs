using prjToDoList;
using System.Runtime.InteropServices;

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
                    toDoList.Add(CreateToDo(categories, people));
                    break;

                case 2:
                    PrintTasks(toDoList);
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
                    people.Add(CreateNewPerson());
                    break;

                case 7:
                    PrintPerson(people);
                    break;

                case 8:
                    Thread.Sleep(1000);
                    Console.WriteLine("Obrigado por utilizar os nossos serviços!");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("\nDigite uma tecla para continuar...");
            Console.ReadLine();
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

        int.TryParse(Console.ReadLine(), out var option); // Retorno padrão é zero! caso seja falso.
        return option;
    }
    private static Person FindPerson(string namePerson, List<Person> people)
    {
        if (people.Count == 0)
            return null;
        foreach (Person person in people)
        {
            if(namePerson == person.Name)
                return person;
        }
        return null;
    }
    private static Todo CreateToDo(List<string> categories, List<Person> people)
    {
        string description;
        string category;
        Person owner;
        DateTime dueDate;

        Console.WriteLine("Escreva a descrição da tarefa:");
        description = Console.ReadLine();

        ListCategories(categories);
        Console.WriteLine("Escolha uma categoria:");
        category = Console.ReadLine();

        PrintPerson(people);
        Console.WriteLine("Escolha um dono:");
        owner = FindPerson(Console.ReadLine(), people);

        Console.WriteLine("Escreva a possivel data de vencimento:");
        dueDate = DateTime.Now.AddDays(10);

        return new Todo(description, category, owner, dueDate);
    }

    private static void ListCategories(List<string> categories)
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada!");
            return;
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

    private static void PrintTasks(List<Todo> toDoList)
    {
        Console.WriteLine("Tarefas:");
        foreach (var item in toDoList)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void PrintPerson(List<Person> people)
    {
        foreach (var item in people)
        {
            Console.WriteLine("Pessoas cadastradas:");
            Console.WriteLine(item.ToString());
        }
    }

    private static Person CreateNewPerson()
    {
        Console.Write("Digite o nome da pessoa:");
        string name = Console.ReadLine();
        Person person = new(name);
        return person;
    }
}