using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warriors_fight
{
    class Warrior
    {
        //dhlwnoumw metavlites pou tha xreiastoume gia to paixnidi kai tis arxikopoioumai kiolas
        public string Name ;
        public double Health;
        public double AttkMax;
        public double BlockMax;

        //xreiazomaste na paragoume tyxaious arithmous
        Random rnd = new Random();

        //ftiaxnoume ton constructora tou warrior
        public Warrior(string name,double health,double attkMax,double blockMax)
        {
            Name = name;
            Health = health;
            AttkMax = attkMax;
            BlockMax = blockMax;
        }

        //ftiaxnoume mia methodo opou mesw enos tyxaiou arithmou apo to 1 mexri to megisto attack tou warrior
        //mas dinei th epithesh tou paikth 
        public double Attack()
        {
            return rnd.Next(1, (int)AttkMax);
        }

        //antistoixa ftiaxnoume mia methodo  gia to block tou kathe warrior
        public double Block()
        {
            return rnd.Next(1, (int)BlockMax);
        }

    }

    class Battle
    {

        //tha xrhsimopoihsw static 
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            //tha exw enan atermono brogxo opou tha spasei mono an kapoios warrior kerdisei kai tha typwthei to game over
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
        }

        public static string GetAttackResult(Warrior warriorA, Warrior warriorB)
        {
            //pagwnei gia ena deyterolepto wste mhn bgoyn ta apotelesmata kateyteian sthn othonh
            System.Threading.Thread.Sleep(1000);
            //ypologizie thn epithesh tou enos kai to block tou allou
            double warAAttkAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();

            //ypologizoume thn zhmia
            double dmg2WarB = warAAttkAmt - warBBlkAmt;

            if (dmg2WarB > 0)
            {
                //an exoume thetikh timh gia thn zhmia tote ua afairesoume to poso ayto apo to health tou warrior
                warriorB.Health = warriorB.Health - dmg2WarB;
            }
            else
            {
                //se periptesh omws pou to block einai megalytero tou attack tote den ua yparxei zhmia
                dmg2WarB = 0;
            }

            //ektypwnei poios epitithetai se poion kai ti zhmia prokalese
            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",warriorA.Name,warriorB.Name,dmg2WarB);

            //mas typwnei thn ygeia tou paikth
            Console.WriteLine("{0} Has {1} Health\n",warriorB.Name,warriorB.Health);

            //elegxei an exei pethanei
            if (warriorB.Health <= 0)
            {
                //typwnei to katallhlo mynhma kai epistrefei game over
                Console.WriteLine("{0} has Died and {1} is Victorious\n", warriorB.Name, warriorA.Name);
                return "Game Over";
            }
            else
            {
                return "Fight Again";
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string warA, warB;

            //zhtame ta onomata twn maxhtwn
            Console.WriteLine("Please give the name of the first warrior:");
            warA = Console.ReadLine();

            Console.WriteLine("Please give the name of the second warrior:");
            warB = Console.ReadLine();

            Warrior warriorA = new Warrior(warA, 500, 120, 40);
            Warrior warriorB = new Warrior(warB, 500, 120, 40);

            Console.WriteLine("Let's start the battle");
            Console.WriteLine("--------------------------------------------");

            //pagwnei to programmagia 2 deyterolepta
            System.Threading.Thread.Sleep(2000);
            //ksekinaei h maxh
            Battle.StartFight(warriorA, warriorB);

            Console.ReadLine();
        }
    }
}
