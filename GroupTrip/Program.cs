/*
* Name: Chase McBee
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

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

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
