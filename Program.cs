List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 1,
        AskingPrice = 1.00M,
        City = "Nashville",
        ZipCode = 37216,
        Sold = false
    },
    new Plant()
    {
        Species = "Oak tree",
        LightNeeds = 2,
        AskingPrice = 6.00M,
        City = "Nashville",
        ZipCode = 37217,
        Sold = false
    },
    new Plant()
    {
        Species = "Lavender",
        LightNeeds = 3,
        AskingPrice = 5.00M,
        City = "Nashville",
        ZipCode = 37211,
        Sold = false
    },
    new Plant()
    {
        Species = "Succulent",
        LightNeeds = 4,
        AskingPrice = 10.00M,
        City = "Nashville",
        ZipCode = 37214,
        Sold = false
    },
    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 5,
        AskingPrice = 7.00M,
        City = "Nashville",
        ZipCode = 37217,
        Sold = true
    }
};



string greeting = "ExtraVert! not introvert";
Console.WriteLine(greeting);
MainMenu();

void DisplayPlants() {
    Console.WriteLine("Display All Plants");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }
}

void PostPlant() {
  Console.WriteLine("Post plant");
}

void AdoptPlant() {
    Console.WriteLine("Adopt plant");
}

void DelistPlant() {
    Console.WriteLine("Delist plant");
}

void Exit() {
    Console.WriteLine("Goodbye!");
}

void InvalidOption() {
    Console.WriteLine("That doesn't exist.. try again!");
}


void MainMenu() {
    
    
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display Plants
                        2. Post your plant!
                        3. Adopt a Plant!
                        4. Delist plant");
    

    string choice = Console.ReadLine();

   switch (choice)
    {
        
        case "0":
            Console.Clear();
            Exit();
            break;
        case "1":
            Console.Clear();
            DisplayPlants();
            MainMenu();
            break;
        case "2":
            Console.Clear();
            PostPlant();
            MainMenu();
            break;
        case "3":
            Console.Clear();
            AdoptPlant();
            MainMenu();
            break;
        case "4":
            Console.Clear();
            DelistPlant();
            MainMenu();
            break;
        default:
            Console.Clear();
            InvalidOption();
            MainMenu();
            break;
    }
}

