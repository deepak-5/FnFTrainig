using System;

namespace FNFIndiaInvestmentBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BankingSystem bankingSystem = new BankingSystem();

            
            bankingSystem.Start();
        }
    }

    class BankingSystem
    {
        
        private PinValidator pinValidator;
        private PinProcessor pinProcessor;

        
        public BankingSystem()
        {
            pinValidator = new PinValidator();
            pinProcessor = new PinProcessor();
        }

        
        public void Start()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("        WELCOME TO FNF INDIA INVESTMENT BANKING");
            Console.WriteLine();
            Console.WriteLine("            ENTER PIN TO CONTINUE THE OPERATION:");
            Console.WriteLine("***********************************************");

            try
            {
                string pinString = pinValidator.GetValidPin();

                int pin = int.Parse(pinString);

                bool isPinValid = pinProcessor.ProcessPin(pin);

                if (isPinValid)
                {
                    Console.WriteLine("Welcome!");
                }
                else
                {
                    throw new InvalidPinException(pin);
                }
            }
            catch (InvalidPinException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using FNF India Investment Banking.");
            }
        }
    }

    class PinValidator
    {
        
        public string GetValidPin()
        {
            Console.Write("Enter 4-digit PIN: ");
            string pinString = Console.ReadLine();

            if (pinString.Length != 4)
            {
                throw new Exception("PIN must be 4 digits");
            }

            return pinString;
        }
    }

    class PinProcessor
    {
        
        public bool ProcessPin(int pin)
        {
            int sum = 0;

            while (pin > 0)
            {
                sum += pin % 10;
                pin /= 10;
            }

            return sum % 2 == 0;
        }
    }

    class InvalidPinException : Exception
    {
        public int Pin { get; }

        public InvalidPinException(int pin)
        {
            Pin = pin;
        }

        public override string Message => $"Invalid PIN entered: {Pin}";
    }
}