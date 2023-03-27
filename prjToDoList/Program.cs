using Microsoft.VisualBasic;
using prjToDoList;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\\Users\\" + Environment.UserName;

        List<string> categories = LoadFileCategories(path + @"\\categorias.csv");
        List<Person> people = LoadFilePeople(path + @"\\pessoas.csv");
        List<Todo> toDoList = LoadFileToDo(path + @"\\tarefas.csv", people);

        if (people.Count == 0)
        {
            people.Add(CreateNewPerson());
        }
        if (categories.Count == 0)
        {
            categories.Add(CreateCategory());
        }

        do
        {
            switch (Menu())
            {
                default:
                    Console.WriteLine("opção inválida!");
                    break;

                case 1:
                    Console.Clear();
                    toDoList.Add(CreateToDo(categories, people));
                    GenerateFile(path + @"\\tarefas.csv", toDoList);
                    break;

                case 2:
                    Console.Clear();
                    PrintTasks(toDoList);
                    break;

                case 3:
                    Console.Clear();
                    EditTodo(toDoList);
                    break;

                case 4:
                    Console.Clear();
                    categories.Add(CreateCategory());
                    GenerateFile(path + @"\\categorias.csv", categories);
                    break;

                case 5:
                    Console.Clear();
                    ListCategories(categories);
                    break;

                case 6:
                    Console.Clear();
                    people.Add(CreateNewPerson());
                    GenerateFile(path + @"\\pessoas.csv", people);
                    break;

                case 7:
                    Console.Clear();
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
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     2 - Listar tarefas cadastradas      |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     3 - Alterar tarefa cadastrada       |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     4 - Cadastrar nova categoria        |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     5 - Listar Categorias               |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     6 - Cadastrar nova pessoa           |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|     7 - Listar pessoas cadastradas      |");
        Console.WriteLine("|                                         |");
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
            if (namePerson == person.Name)
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
        Console.WriteLine("Tarefas cadastradas:");
        foreach (var item in toDoList)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void PrintPerson(List<Person> people)
    {
        Console.WriteLine("Pessoas cadastradas:\n");
        foreach (var item in people)
            Console.WriteLine(item.ToString());
    }

    private static Person CreateNewPerson()
    {
        Console.Write("Digite o nome da pessoa: ");
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

    private static List<string> LoadFileCategories(string fullpath)
    {
        List<string> categories = new List<string>();

        if (!File.Exists(fullpath))
            return categories;

        StreamReader sr = new StreamReader(fullpath);
        while (!sr.EndOfStream)
        {
            categories.Add(sr.ReadLine());
        }
        sr.Close();

        return categories;
    }

    private static List<Person> LoadFilePeople(string fullpath)
    {
        List<Person> people = new List<Person>();

        if (!File.Exists(fullpath))
            return people;

        StreamReader sr = new StreamReader(fullpath);
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

    private static List<Todo> LoadFileToDo(string fullpath, List<Person> people)
    {
        List<Todo> toDo = new List<Todo>();

        if (!File.Exists(fullpath))
            return toDo;

        StreamReader sr = new StreamReader(fullpath);
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

    private static void EditTodo(List<Todo> todo)
    {

        PrintTasks(todo);
        Console.Write("Esolha a tarefa passando o ID: ");
        string id = Console.ReadLine();
        Console.Clear();

        Todo taskToEdit = FindToDo(todo, id);
        Console.WriteLine(taskToEdit.ToString());
        string reEdit = "";
        do
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|     Selecione a opção desejada:    |");
            Console.WriteLine("|____________________________________|");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|    1 - Mudar descrição             |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|    2 - Mudar categoria             |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|    3 - Mudar estado da tarefa.     |");
            Console.WriteLine("|____________________________________|");
            int option = int.Parse(Console.ReadLine());
            string description = "";
            string category = "";

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite uma nova descrição para a tarefa selecionada: ");
                    description = Console.ReadLine();
                    taskToEdit.Description = description;
                    Console.WriteLine("Descrição alterada com sucesso!");
                    Thread.Sleep(1600);
                    Console.Clear();
                    break;

                case 2:
                    Console.Write("Nova categoria para a tarefa selecionada: ");
                    category = Console.ReadLine();
                    taskToEdit.Category = category;
                    Console.WriteLine("Mudanca de categoria confirmada!");
                    Thread.Sleep(1600);
                    Console.Clear();
                    break;
                case 3:
                    taskToEdit.SetStatus();
                    Console.WriteLine("Estado alterado com sucesso!");
                    Thread.Sleep(1600);
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Opção não encontrada!");
                    break;
            }
            PrintTasks(todo);
            Console.WriteLine("\n\nDeseja realizar outra alteração nesta tarefa?\n" +
                "Digite (s) para editar ou qualquer outra tecla para continuar. ");
            reEdit = Console.ReadLine().ToLower();
        }
        while (reEdit == "s");

    }

    private static Todo FindToDo(List<Todo> todo, string id)
    {
        foreach (Todo item in todo)
        {
            if (Guid.Parse(id) == item.Id)
            {
                return item;
            }
        }
        return null;
    }
}