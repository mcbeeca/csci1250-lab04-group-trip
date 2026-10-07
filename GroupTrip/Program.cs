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
const double taxRate = 0.18;

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

/* Part 3: Finds the take home pay, take home pay per hour, 
*  and the longest amount of hours a person on the array works.
*/
double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

Console.WriteLine("\n===== Part 3: Who Works for How Long =====");
for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHomePay / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePerHour);

    Console.WriteLine(
    names[i]
    + ": Take-home pay: " + takeHomePay.ToString("C")
    + " for " + hoursWorked[i] + " hours; "
    + takeHomePerHour.ToString("C") + " per hour; must work "
    + hoursNeeded.ToString("F2") + " hours to cover their share.");

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;
    longest = Math.Max(longest, hoursNeeded);
}

Console.WriteLine("\nTotal hours worked: " + totalHours.ToString("F2"));
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));

/* Method 1: Finds the fuel cost using 3 values given in Part 1:
 * miles, milesPerGallon, and PricePerGallon,
 * then returns the FuelCost after calculating the gallons
 * by dividing the miles by milesPerGallon, 
 * then multiplying the gallons by the pricePerGallon.
*/

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

/* Method 2: Finds the take home pay by using the 2 arrays
 * hoursWorked, hourlyRates, and the taxRate constant,
 * calculates grossPay by multiplying hoursWorked and hourlyRates,
 * calculates taxWithheld by multiplying the grossPay by the taxRate constant
 * then returning the TakeHomePay by subtracting the grossPay by the taxWithheld.
*/

static double TakeHomePay(double hoursWorked, double hourlyRates, double taxRate)
{
    double grossPay = hoursWorked * hourlyRates;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}

/* Method 3: Finds the amount of hours a person has to work to cover the trip by
 * using the costPerPerson value calculated in Part 2,
 * then returns the amount of hours to cover the trip
 * by dividing the costPerPerson (which is called amountOwed here)
 * by the takeHomePerHour
*/

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}
