Console.WriteLine(Hello());
String[] students = Students();

foreach (var item in students)
{
    System.Console.WriteLine(item);
}

Console.WriteLine(Students());

static String Hello(){
    return "Hello, World";
}

static string[] Students(){
    return new string[]
    {
        "Ahmet",
        "Mehmet",
        "Muhammed",
        "Nisa",
        "Tuna",
        "Abdullah"
    };
}