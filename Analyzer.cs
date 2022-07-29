using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace REInvestment
{
    public class Analyzer
    {
        // This serializes a text file where the investors are stored and retrieved
        string path = @".\InvestorFile.txt";

        // Fields
        public string? investor { get; set; }
        public bool mainMenuLoop = true;
        public bool subMenuLoop = true;
        public string? choice;
        public string? choice2;

        // Constructor


        // Methods

        private string? MainMenu()
        {
            if (investor != null)
            {
                Console.WriteLine("Hello " + investor);
            }
            Console.Clear();
    
            // This is the Main Menu
            Console.WriteLine("Welcome to Real Estate Investing - Deal Analyzer");
            Console.WriteLine("(To BUY or NOT to BUY)\n");
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("[1] New User - Create an Account");
            Console.WriteLine("[2] Returning User - Enter investor name");
            Console.WriteLine("[3] Exit\n");
            Console.Write("Your selection: ");

            return Console.ReadLine();
        }

        public void StartNewDealAnalysis( string userSelection = "")
        {
            choice = userSelection;
            while (mainMenuLoop)
            {
                choice = MainMenu();
                switch (choice)
                {
                    case "1":
                        // Serializes XML Record
                        Investor oI = new Investor("John", "Address1 Houston TX 77095");
                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, oI.SerializeXml());
                        }
                        else
                        {
                            File.AppendAllText(path, oI.SerializeXml());    
                        }
                        // Deserialize XML record
                        Investor U = DeserializeXML();
                        //Console.WriteLine(Q.name);
                        Console.WriteLine("A new account has been created for you, " + U.name +".");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        // Calls submenu
                        ProjectCost o1ProjectCost = new ProjectCost();
                        o1ProjectCost.ProjectCostPercentage();

                        break;

                    case "2":  
                        // Get user input then compare it with existing record
                        Console.Write("Please Enter Your Name: ");
                        string? userName = Console.ReadLine(); 
                        Console.Write("Is this correct? [y/n] : ");
                        string? yn = Console.ReadLine();
                        investor = (yn.ToLower() == ("y") ? userName : null);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        
                        // Deserialize XML record
                        Investor Q = DeserializeXML();
                        Console.WriteLine(Q.name); 

                        if (userName == Q.name)
                        {
                            ProjectCost o2ProjectCost = new ProjectCost();
                            o2ProjectCost.ProjectCostPercentage();
                        }
                        else
                        {
                        Console.Write("Record not found. Do you want to create a new account? ");
                        string? yn2 = Console.ReadLine();
                        investor = (yn2.ToLower() == ("y") ? userName : null);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();                            
                        }
                        // Calls submenu
                        
                        //oAnalyzer.ExitStrategy();
                        break;

                    case "3":
                        mainMenuLoop = false;
                        Console.WriteLine("Thank you for using this application.");
                        break;
                    
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void ExitStrategy( string userSelection2 = "")
        {
            choice2 = userSelection2;
            while (subMenuLoop)
            {
                choice2 = ExitStrategyMenu();
                switch (choice2)
                {
                    case "1":
                        Console.WriteLine("You chose to SELL the property as an Exit Strategy.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        // Calls submenu

                        break;
                    case "2":
                        Console.WriteLine("You chose to REHAB then SELL the property as an Exit Strategy.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        // Calls submenu

                        break;

                    case "3":
                        Console.WriteLine("You chose to RENT the property as an Exit Strategy.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        // Calls submenu

                        break;
                    case "4":
                        Console.WriteLine("You chose to REHAB then RENT the property as an Exit Strategy.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        // Calls submenu

                        break; 
                    case "5":
                        subMenuLoop = false;
                        Console.WriteLine("Thank you for using this application.");
                        break;
                    
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        private string? ExitStrategyMenu()
        {
            if (investor != null)
            {
                Console.WriteLine("Hello " + investor);
            }
            Console.Clear();
    
            // This is the Exit Strategy Menu
            Console.WriteLine("EXIT STRATEGY");

            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("[1] Sell the property");
            Console.WriteLine("[2] Rehab then sell");
            Console.WriteLine("[3] Rent the property");
            Console.WriteLine("[4] Rehab then rent");
            Console.WriteLine("[5] Exit\n");
            Console.Write("Your selection: ");

            return Console.ReadLine();
        }

        private static Investor DeserializeXML()
        {
            XmlSerializer oSerializer = new XmlSerializer(typeof(Investor));
            string path = @".\InvestorFile.txt";
            Investor oI = new Investor();       // creates an instance of Investor class
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exists.");
                return null;
            }
            else
            {
                using StreamReader oReader = new StreamReader(path);
                var record = (Investor)oSerializer.Deserialize(oReader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    oI = record;    
                }
            }
            return oI;
        }        
    }
}
