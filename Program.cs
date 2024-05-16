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
 // Console.WriteLine("\nYou chose option 2\n");
    Console.WriteLine("Please enter a species:\n");

    Plant newPlant = new Plant();

    Console.WriteLine("Enter a plant species:\n");
    newPlant.Species = Console.ReadLine();

    Console.WriteLine("Enter the plant's light needs (1 for low light, 5 for heavy light)\n");
    newPlant.LightNeeds = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter an asking price:\n");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter a city:\n");
    newPlant.City = Console.ReadLine();

    Console.WriteLine("Enter a ZIP:\n");
    newPlant.ZipCode = int.Parse(Console.ReadLine());

    newPlant.Sold = false;

    plants.Add(newPlant);


}

void AdoptPlant() {

    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
        }
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        Console.WriteLine($"Please enter the plant number you wish to adopt:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];

            chosenPlant.Sold = true;
            
        }
        catch (FormatException)
        {
        Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
        Console.WriteLine("Please choose an existing item only!");
        }
}
}

void DelistPlant() {
    

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    
        Console.WriteLine("Choose a plant to delist:");
        try {
            int response = int.Parse(Console.ReadLine().Trim());
            

            plants.RemoveAt(response - 1);
        }
        catch (FormatException)
        {
        Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
        Console.WriteLine("Please choose an existing item only!");
        }

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

