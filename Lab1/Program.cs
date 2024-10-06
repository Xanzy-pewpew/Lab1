Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Välkommen till denna program som kallas för"
    + "\n-*-*- Hitta tal i sträng med tecken -*-*-");
string userInput = Console.ReadLine();                         //Användarens input
string notChar = "";                                           //Använder 3st. string för att skilja åt olika steg i koden. icke, före och efter Char
string beforeChar = "";
string afterChar = "";
long total = 0;                                                //Använder long för att kunna hantera flera siffror, används till summering senare

for (int i = 0; i < userInput.Length; i++)
{
    int temp = 0;                                              //Gör en temporär int i första for-loopet
    bool ifNumber = int.TryParse(userInput[i] + "", out temp); //Här hade jag problem, fick inte ut alla mina siffror när jag skrev min notChar-string, ändrade sedan till ""
    if (!ifNumber)                                             //Bool för att kunna forsätta loopet samt kollar användarens input. Lägger in en falsk bool i if-satsen
    {
        continue;
    }
    for (int j = i + 1; j < userInput.Length; j++)             //Gör en ny for-loop för att använda mig av int temp
    {
        if (!char.IsDigit(userInput[j]))                       //Googlade lite om Isdigit och den se över om det kommer siffror elle ej, hoppar över genom break om icke siffror
        {
            break;
        }
        if (userInput[i] == userInput[j])                      //if-satsen som kollar genom användarens input är lika med temp
        {
            notChar = userInput.Substring(i, j - i + 1);       //Substring för att se början av inputs tecken position tills slutet
            long result;                                       //Använder mig av long result för att sedan summera med total
            long.TryParse(notChar, out result);
            total += result;                                  
            beforeChar = userInput.Substring(0, userInput.IndexOf(notChar));
                                                               //Googlade lite om IndexOf där den kollar indexet av inmatningen från användare
            afterChar = userInput.Substring(notChar.Length + beforeChar.Length, (userInput.Length) - (notChar.Length + beforeChar.Length));
                                                               //Här kollar det om första siffran är samma som slutet genom att använda + och -
            Console.Write(beforeChar);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(notChar);
            Console.ResetColor();                              //Hade problem med denna tills jag insåg att man måste stoppa färgläggningen i koden, använder ResetColor
            Console.WriteLine(afterChar);                      //WriteLine för att kunna radda upp siffror i sin rätta plats.
            break;
        }
    }
}
Console.WriteLine();
Console.Write("Summan av koden är: ");                         //Här skrivs det ut summan av koden med röd färg
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(total);
Console.ResetColor();