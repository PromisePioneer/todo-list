
List<string> toDoList = new List<string>();


do
{
    Console.WriteLine("What do you want to do ?");
    Console.WriteLine("[S]ee all TODOS");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "s":
        case "S":
            Console.WriteLine("See All TODOS");
            SeeToDoList(toDoList);
            break;
        case "a":
        case "A":
            Console.WriteLine("Add a Todo");
            AddTodo(toDoList);
            break;
        case "r":
        case "R":
            RemoveToDo(toDoList);
            break;
        case "e":
        case "E":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("please Provide a correct option");
            break;
    }
} while (true);


List<string> SeeToDoList(List<string> list)
{
    int number = 0;
    foreach (var todo in list)
    {
        number++;
        Console.WriteLine($"{number}. {todo}");
    }

    return list;
}


List<string> AddTodo(List<string> list)
{
    do
    {
        Console.WriteLine("Enter the TODO description");
        string description = Console.ReadLine();
        bool isUnique = true; // Assume description is unique for each iteration

        if (description.Length == 0)
        {
            Console.WriteLine("Description cannot be empty");
        }

        foreach (var todo in list)
        {
            if (todo == description)
            {
                Console.WriteLine("Description must be unique");
                isUnique = false;
                break;
            }
        }

        if (isUnique)
        {
            list.Add(description);
            Console.WriteLine($"TODO successfully added: {description}");
            break; 
        }
    } while (true);

    return list;
}

List<string> RemoveToDo(List<string> list)
{
    while (true)
    {
        Console.WriteLine("Select index of the TODO you want to remove");

        int index = 1;
        foreach (var todo in list)
        {
            Console.WriteLine($"{index++}. {todo}" );
        }
        
        string userInput = Console.ReadLine(); 
        bool isParsingSuccessful = int.TryParse(userInput, out int number);
        
        if (isParsingSuccessful)
        {
            if (number < 1 || number > list.Count)
            {
                Console.WriteLine("Please Provide a Correct Number ");
            }
            else
            {
                list.RemoveAt(number - 1);
                Console.WriteLine($"list has been removed");
                break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        
    };

    return list;
}
