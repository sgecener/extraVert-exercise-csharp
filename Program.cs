List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 1,
        AskingPrice = 1.00M,
        City = "Nashville",
        ZipCode = 37216,
        Sold = false,
        ExpirationDate = new DateTime(2024, 5, 30)

    },
    new Plant()
    {
        Species = "Oak tree",
        LightNeeds = 2,
        AskingPrice = 6.00M,
        City = "Nashville",
        ZipCode = 37217,
        Sold = false,
        ExpirationDate = new DateTime(2024, 5, 30)

    },
    new Plant()
    {
        Species = "Lavender",
        LightNeeds = 3,
        AskingPrice = 5.00M,
        City = "Nashville",
        ZipCode = 37211,
        Sold = true,
        ExpirationDate = new DateTime(2024, 5, 13)

    },
    new Plant()
    {
        Species = "Succulent",
        LightNeeds = 4,
        AskingPrice = 10.00M,
        City = "Nashville",
        ZipCode = 37214,
        Sold = false,
        ExpirationDate = new DateTime(2024, 5, 13)

    },
    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 5,
        AskingPrice = 7.00M,
        City = "Nashville",
        ZipCode = 37217,
        Sold = true,
        ExpirationDate = new DateTime(2024, 5, 30)

    }
};

Random random = new Random();
int randomInteger = random.Next(1, plants.Count + 1);

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

    int lightNeeds;
    while (true)
    {
        Console.WriteLine("Enter the plant's light needs (1 for low light, 5 for heavy light):\n");
        if (int.TryParse(Console.ReadLine(), out lightNeeds) && lightNeeds >= 1 && lightNeeds <= 5)
        {
            newPlant.LightNeeds = lightNeeds;
            break; // Exit the loop if input is valid
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        }
    }

    Console.WriteLine("Enter an asking price:\n");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter a city:\n");
    newPlant.City = Console.ReadLine();

    Console.WriteLine("Enter a ZIP:\n");
    newPlant.ZipCode = int.Parse(Console.ReadLine());

     DateTime expirationDate;
    while (true)
    {
        Console.WriteLine("Enter the expiration date (MM/dd/yyyy):\n");
        string dateInput = Console.ReadLine();

        if (DateTime.TryParseExact(dateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out expirationDate))
        {
            if (expirationDate.Date >= DateTime.Today)
            {
                break; // Exit the loop if date is valid and not before today
            }
            else
            {
                Console.WriteLine("The expiration date cannot be before the current date. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }

    newPlant.ExpirationDate = expirationDate;

    newPlant.Sold = false;

    plants.Add(newPlant);

    Console.WriteLine("Plant added successfully!");
}

void AdoptPlant() {

    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold && plants[i].ExpirationDate >= DateTime.Now)
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

void RandomPlant() {

    Plant randomPlant = plants[randomInteger];

    Console.WriteLine($"\n{randomPlant.Species} is located in {randomPlant.City}.\nLight Need: {randomPlant.LightNeeds}\nPrice: {randomPlant.AskingPrice}");

}

void SearchByLight() {

    Console.WriteLine("Search By Light Need:");

    int response = int.Parse(Console.ReadLine().Trim());

    List<Plant> lightNeed = new List<Plant>();

    foreach (Plant plant in plants) {
        if (response < 1 || response > 5)
        {
            Console.WriteLine("Option isn't valid...");
        }

        if (response >= plant.LightNeeds) {
            lightNeed.Add(plant);
        }
    }
    for (int i = 0; i < lightNeed.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {lightNeed[i].Species}");
    }

}


void Exit() {
    Console.WriteLine("Goodbye!");
}

void InvalidOption() {
    Console.WriteLine("That doesn't exist.. try again!");
}

void PlantStatistics() {
    if (plants.Count == 0) {
        Console.WriteLine("No plants available to display statistics.");
        return;
    }

    // Lowest price plant name
    Plant cheapestPlant = plants.OrderBy(p => p.AskingPrice).First();
    Console.WriteLine($"Cheapest plant: {cheapestPlant.Species} (${cheapestPlant.AskingPrice})");

    // Number of plants available (not sold, and still available)
    int availablePlantsCount = plants.Count(p => !p.Sold && p.ExpirationDate >= DateTime.Today);
    Console.WriteLine($"Number of plants available: {availablePlantsCount}");

    // Name of plant with highest light needs
    Plant highestLightNeedsPlant = plants.OrderByDescending(p => p.LightNeeds).First();
    Console.WriteLine($"Plant with highest light needs: {highestLightNeedsPlant.Species} (Light Needs: {highestLightNeedsPlant.LightNeeds})");

    // Average light needs
    double averageLightNeeds = plants.Average(p => p.LightNeeds);
    Console.WriteLine($"Average light needs: {averageLightNeeds:F2}");

    // Percentage of plants adopted
    double percentageAdopted = (double)plants.Count(p => p.Sold) / plants.Count * 100;
    Console.WriteLine($"Percentage of plants adopted: {percentageAdopted:F2}%");

    Console.WriteLine("\n0. Main Menu");
    if (Console.ReadLine() == "0")
    {
        MainMenu();
    }
}


void MainMenu() {
    
    
    Console.WriteLine(@"Choose an option:
                        1. Display Plants
                        2. Post your plant!
                        3. Adopt a Plant!
                        4. Delist plant
                        5. Randomize a Plant
                        6. Search Plant by Light Need
                        7. Plant Statistics
                        0. Exit
                        ");
                        
    

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
        case "5":
            Console.Clear();
            RandomPlant();
            MainMenu();
            break;
        case "6":
            Console.Clear();
            SearchByLight();
            MainMenu();
            break;
        case "7":
            Console.Clear();
            PlantStatistics();
            break;
        default:
            Console.Clear();
            InvalidOption();
            MainMenu();
            break;
    }
}




