using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//ena programma sto opoio einai se mia trapeza kai yparxoyn dyo trapezikoi logariasmoi
//ena gia ton enhlika kai ena gia ena paidi,opou katathetoume lefta kai mporoume na shkvsoume lefta

namespace interfacenew
{
    //interface
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
        
    }
    //klash toy gia na ftiaxnei objects toy enhlika
    public class CustomerAccount:IAccount
    {
        protected decimal balance = 0;

        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }
        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
    //klash h opoia mporoume na ftiaksoume objects gia to logariamsou anhlikou
    //exei epriorismo opou den mporie na kanei analhpsei panw apo 10 eyrw
    public class BabyAccount :CustomerAccount, IAccount
    {


        public override bool WithdrawFunds(decimal amount)
        {
            if (amount >10)
            {
                return false;
            }
            if (balance < amount )
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string stringamount,number, stringbabyamount;
            decimal amount,withdraw,babyamount, babywithdraw;

            IAccount jim = new CustomerAccount();

            Console.WriteLine("give the amount:");
            stringamount = Console.ReadLine();

            amount = decimal.Parse(stringamount);

            jim.PayInFunds(amount);

            Console.WriteLine("now your balance is : "+jim.GetBalance());


            Console.WriteLine("give me the amount for the withdraw : ");
            withdraw = decimal.Parse(Console.ReadLine());

            if (jim.WithdrawFunds(withdraw))
            {
                Console.WriteLine("now your balance is : " + jim.GetBalance());
            }
            else
            {
                Console.WriteLine("withdraw denied");

    
            }

            Console.WriteLine("would you like to continue with a baby account?");
            Console.WriteLine("please pres 1 to continue or 2 to abort:");

            number = Console.ReadLine();

            if (number == "1")
            {
                BabyAccount b = new BabyAccount();

                Console.WriteLine("give the amount for baby");

                stringbabyamount =Console.ReadLine();
                babyamount = decimal.Parse(stringbabyamount);

                b.PayInFunds(babyamount);

                Console.WriteLine("now your balance is : " + b.GetBalance());
                Console.WriteLine("give me the amount for the withdraw");

                babywithdraw = decimal.Parse(Console.ReadLine());

                if (b.WithdrawFunds(babywithdraw))
                {
                    Console.WriteLine("now your balance is : " + b.GetBalance());
                }
                else
                {
                    Console.WriteLine("withdraw denied");
                    //perimenei 3 deyterolepta
                    System.Threading.Thread.Sleep(3000);
                    //klinei h efarmogh
                    System.Environment.Exit(1);

                }
            }
            else
                System.Environment.Exit(1);

            Console.ReadLine();
        }
    }
}
