using prjToDoList;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> categories = LoadFileCategories();
        List<Person> people = LoadFilePeople();
        List<Todo> toDoList = LoadFileToDo(people);

        
        string path = @"C:\\Users\\" + Environment.UserName;        
       

        do
        {
            switch (Menu())
            {
                default:
                    Console.WriteLine("opção inválida!");
                    break;

                case 1:
                    toDoList.Add(CreateToDo(categories, people));
                    GenerateFile("tarefas.csv", toDoList);
                    break;

                case 2:
                    PrintTasks(toDoList);
                    break;

                case 3:
                    break;

                case 4:
                    categories.Add(CreateCategory());
                    GenerateFile("categorias.csv", categories);
                    break;

                case 5:
                    ListCategories(categories);
                    break;

                case 6:
                    people.Add(CreateNewPerson());
                    GenerateFile("pessoas.csv", people);
                    break;

                case 7:
                    PrintPerson(people);
                    break;

                case 8:
                    GenerateFile(path + @"\\categorias.csv", categories);
                    GenerateFile(path + @"\\pessoas.csv", people);
                    GenerateFile(path + @"\\tarefas.csv", toDoList);
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

    private static void GenerateFile(string path, List<string> categories)
    {
        if (categories.Count == 0)
        {
            return;
        }

        StreamWriter sw = new StreamWriter(path);
        foreach (string category in categories)
        {
            sw.WriteLine(category);
        }
        sw.Close();
    }
    private static void GenerateFile(string path, List<Person> people)
    {
        if (people.Count == 0)
        {
            return;
        }
        StreamWriter sw = new StreamWriter(path);
        foreach (Person person in people)
        {
            sw.WriteLine(person.ToString());
        }
        sw.Close();
    }
    private static void GenerateFile(string path, List<Todo> toDoList)
    {
        if (toDoList.Count == 0)
        {
            return;
        }

        StreamWriter sw = new StreamWriter(path);
        foreach (Todo toDo in toDoList)
        {
            sw.WriteLine(toDo.ToFile());
        }
        sw.Close();
    }

    private static List<string> LoadFileCategories()
    {
        List<string> categories = new List<string>();
        
        if (!File.Exists("categorias.csv"))
            return categories;

        StreamReader sr = new StreamReader("categorias.csv");
        while (!sr.EndOfStream)
        {
            categories.Add(sr.ReadLine());
        }
        sr.Close();

        return categories;
    }

    private static List<Person> LoadFilePeople()
    {
        List<Person> people = new List<Person>();

        if (!File.Exists("pessoas.csv"))
            return people;

        StreamReader sr = new StreamReader("pessoas.csv");
        while (!sr.EndOfStream)
        {
            string[] prop = sr.ReadLine().Split('|');
            
            //Guid id = Guid.Parse(prop[0]);
            string name = prop[0];
            
            people.Add(new(name));
        }
        sr.Close();

        return people;
    }

    private static List<Todo> LoadFileToDo(List<Person> people)
    {
        List<Todo> toDo = new List<Todo>();

        if (!File.Exists("tarefas.csv"))
            return toDo;

        StreamReader sr = new StreamReader("tarefas.csv");
        while (!sr.EndOfStream)
        {
            string[] prop = sr.ReadLine().Split('|');

            Guid id = Guid.Parse(prop[0]);
            string description = prop[1];
            string category = prop[2];
            Person owner = FindPerson(prop[3], people);
            DateTime created = DateTime.Parse(prop[4]);
            DateTime dueDate = DateTime.Parse(prop[5]);
            bool status = bool.Parse(prop[6]);

            toDo.Add(new(id, description, category, owner, created, dueDate, status));
        }
        sr.Close();

        return toDo;
    }
}