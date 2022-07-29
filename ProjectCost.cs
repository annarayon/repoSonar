using System;

namespace REInvestment
{
    public class ProjectCost 
    {
        // fields
        public string? propertyAddress {get; set;}
        public float askingPrice {get; set;}
        public float repairEstimate {get; set;}
        public float afterRepairValue {get; set;}
        // constructor
        public ProjectCost()
        {
            this.propertyAddress = propertyAddress;
            this.askingPrice = askingPrice;
            this.repairEstimate = repairEstimate;
            this.afterRepairValue = afterRepairValue;
        }

        public void ProjectCostPercentage()
        {
            Console.WriteLine("START A NEW DEAL ANALYSIS\n");
 
            Console.Write("Enter Property Address:    ");
            string? propertyAddress = Console.ReadLine();    

            float inputAskingPrice;
            bool testAskingPrice;
            
            do 
            {   Console.Write("Enter Asking Sales Price: $");
                string? askingPrice = Console.ReadLine();    
                testAskingPrice = float.TryParse(askingPrice, out inputAskingPrice); 
            } while (!testAskingPrice); 
                      
            Console.WriteLine(" ");
            float inputRepairEstimate;
            bool testRepairEstimate;
            
            do 
            {   Console.Write("Enter Repair Estimate:    $");
                string? repairEstimate = Console.ReadLine();    
                testRepairEstimate = float.TryParse(repairEstimate, out inputRepairEstimate); 
            } while (!testRepairEstimate); 
  
            float inputArv;
            bool testArv;
            do 
            {
                Console.Write("Enter Comparable ARV:     $");
                string? afterRepairValue = Console.ReadLine();   
                testArv = float.TryParse(afterRepairValue, out inputArv);
            } while (!testArv); 

            Console.WriteLine(" ");

            float projectCostPercentage;
            projectCostPercentage = (inputAskingPrice + inputRepairEstimate) / inputArv;
            
            string strPCP = Convert.ToString(projectCostPercentage*100);

            if (projectCostPercentage <= .70)
            {
                Console.WriteLine("Your Project Cost Percentage is: " + strPCP + "%\n");
                Console.WriteLine("BUY!");

            }
            else if (projectCostPercentage > .70)
            {
                Console.WriteLine("Your Project Cost Percentage is: " + strPCP + "%\n");
                Console.WriteLine("NOT TO BUY!");
            } 
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
    }
}