/*
* Name: Chase McBee
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

//Part 1: Finds fuel cost, pizza cost, and trip total.
const int slices = 8;

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

Console.Write("What are the round trip miles? ");
double roundTripMiles = Convert.ToDouble(Console.ReadLine());

Console.Write("What is the miles per gallon? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("What is the price per gallon? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("How many pizzas? ");
int pizza = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the price per pizza? ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

double fuelCost = FuelCost(roundTripMiles, milesPerGallon, pricePerGallon);
double pizzaCost = pizza * pricePerPizza;
double tripTotal = fuelCost + pizzaCost;

Console.WriteLine("\n===== Part 1: The Trip =====");
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));

//Part 2: Finds the people going, the amount of slices per person, and the cost per person.

int totalSlices = pizza * slices;
double slicesPerPerson = totalSlices / (double)names.Length;
double costPerPerson = tripTotal / names.Length;

Console.WriteLine("\n===== Part 2: The Group =====");
Console.WriteLine("People going: " + names.Length.ToString());
Console.WriteLine("Slices each: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));

/* Method 1: Finds the fuel cost using 3 values given in Part 1:
 * miles, milesPerGallon, and PricePerGallon,
 * then returns the FuelCost after calculating the gallons
 * by dividing the miles by milesPerGallon, 
 * then multiplying the gallons by the pricePerGallon
*/

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
