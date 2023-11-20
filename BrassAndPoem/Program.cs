

using System.ComponentModel;

List<Product> products = new List<Product>()
{
    new Product
    {
        Name = "Trumpet",
        Price = 799.99M,
        ProductTypeId = 1
    },
    new Product
    {
        Name = "Trombone",
        Price = 899.99M,
        ProductTypeId = 1
    },
    new Product
    {
        Name = "Sonnet Collection",
        Price = 15.99M,
        ProductTypeId = 2
    },
    new Product
    {
        Name = "Epic Poem Anthology",
        Price = 25.99M,
        ProductTypeId = 2
    },
    new Product
    {
        Name = "French Horn",
        Price = 999.99M,
        ProductTypeId = 1
    }
};


List<ProductType> productTypes = new List<ProductType>()
{

 new ProductType()
    {
        Title = "Brass Instruments",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poems",
        Id = 2
    },
};

string greeting = "Welcome to Brass and Poem!\n" +
                  "We are your one stop shop for french horns and Robert Frost.";

Console.WriteLine(greeting);

string choice = null;

while (choice != "5")
{
    DisplayMenu();

    choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;

        case "2":
            DeleteProduct(products, productTypes);
            break;

        case "3":
            AddProduct(products, productTypes);
            break;

        case "4":
            UpdateProduct(products, productTypes);
            break;

        case "5":
            Console.WriteLine("Goodbye, friend.");
            break;

        default:
            Console.WriteLine("Invalid Option");
            break;
    }
}




void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId);

        Console.WriteLine($"{i + 1}. {products[i].Name}\nYour Cost: ${products[i].Price}\n{(productType != null ? $"Category: {productType.Title}" : "Product type not found")}");
        Console.WriteLine();
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{


    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1} {products[i].Name}");
    }

    int response;
    while (true)
    {
        Console.WriteLine("Enter the number of the product you want to delete:");

        if (!int.TryParse(Console.ReadLine().Trim(), out response) || response <= 0 || response > products.Count)
        {
            Console.WriteLine("Choose a valid option");
        }
        else
        {
            break;
        }
    }

    Product chosenProduct = products[response - 1];

    Console.WriteLine($"You've chosen {chosenProduct.Name} to delete");

    try
    {
        products.RemoveAt(response - 1);

        Console.WriteLine($"{chosenProduct.Name} deleted");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);

        Console.WriteLine("Something went wrong!");
    }
}



void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string name = null;
    decimal price = 0;

    try
    {
        Console.WriteLine("What's the name of the new product");

        name = Console.ReadLine().Trim();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please enter a valid product name");

            name = Console.ReadLine().Trim();
        }

        Console.WriteLine("What's the price of the new product");

        while (!decimal.TryParse(Console.ReadLine().Trim(), out price))
        {
            Console.WriteLine("Please enter a valid price");
        }

        string choice = null;
        int chosenProductType = 0;


        while (chosenProductType < 1 || chosenProductType > 2)
        {
            Console.WriteLine(@"Please choose a product type
                              1. Brass Instruments
                              2. Poems");

            choice = Console.ReadLine().Trim();

            if (!int.TryParse(choice, out chosenProductType) || chosenProductType < 1 || chosenProductType > 2)
            {
                Console.WriteLine("Invalid choice. Please enter a valid category number (1-2).");
                chosenProductType = 0;
            }
        }

        Product newProduct = new Product()
        {
            Name = name,
            Price = price,
            ProductTypeId = chosenProductType
        };

        products.Add(newProduct);

        Console.WriteLine($"{name} was added successfully");
    }
    catch (Exception e)
    {
        Console.WriteLine("An unexpected error occurred: " + e.Message);
    }
}



void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    try
    {
        Console.WriteLine("Which product would you like to make changes to?");
        DisplayAllProducts(products, productTypes);
        Console.WriteLine("Enter the number of the product you want to edit:");

        int productIndex;

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out productIndex) || productIndex < 1 || productIndex > products.Count)
            {
                Console.WriteLine("Please make a valid choice");
            }
            else
            {
                break;
            }
        }

        Product chosenProduct = products[productIndex - 1];

        Console.WriteLine($"You've chosen {chosenProduct.Name}");

        Console.WriteLine("Enter the updated name (press Enter to keep the current name):");

        string newName = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(newName))
        {
            chosenProduct.Name = newName;
        }

        Console.WriteLine("Enter the updated price (press Enter to keep the current price):");

        string newPriceInput = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(newPriceInput))
        {
            if (decimal.TryParse(newPriceInput, out decimal newPrice))
            {
                chosenProduct.Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid price format. The price was not updated.");
            }
        }

        Console.WriteLine("Enter the updated Product Type ID (1 for Brass Instruments, 2 for Poems, press Enter to keep the current product type):");

        string newIdInput = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(newIdInput))
        {
            if (int.TryParse(newIdInput, out int newId) && (newId == 1 || newId == 2))
            {
                chosenProduct.ProductTypeId = newId;
                string updatedCategory = newId == 1 ? "Brass Instruments" : "Poems";
                Console.WriteLine($"Category updated to: {updatedCategory}");
            }
            else
            {
                Console.WriteLine("Invalid input or product type. The product type was not updated.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An unexpected error occurred: " + ex.Message);
    }
}

















void DisplayMenu()
{
    Console.WriteLine(
      @"Please choose an option
        
        1. Display all products
        2. Delete a product
        3. Add a new product
        4. Update product properties
        5. Exit");
}

// don't move or change this!
public partial class Program { }
