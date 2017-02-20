using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Caticketpv

//Pasi Viinanen 20.2.2017
//    5. Toteuta Maatalousnäyttelyn lipunhinnan muodostuminen C# -ohjelmointikielellä.
//Perustiedot
//Kysytään asiakkaan tiedot
//Lasketaan alennus
//Ilmoitetaan lipun hinta
//Ehdot: Vain yksi alennus myönnetään. Paitsi, jos on opiskelija sekä Mtk:n jäsen, hän saa molemmat alennukset.
//Normaalihinta 16 e
//Alle 7 v. ilmaiseksi
//65 v. ja yli: 50 % alennus
//7-15 v. 50% alennus
//Mtk jäsen: 15 % alennus
//Varusmies: 50 % alennus
//Opiskelija: 45 % alennus
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start

            Console.WriteLine("Tervetuloa Farmari maatalousnäyttelyyn" + " " + DateTime.Now);

            // all parameters 
            float normalprice = 16; //eur
            float yourprice = 0;// eur

            int ika = 15; // person age


            // program main 

            Console.WriteLine(" Anna nimesi ");

            string strName = Console.ReadLine();

            Console.WriteLine(" Sinun nimesi on " + " " + strName);


            Console.WriteLine(" Anna ikäsi jotta voimme laskea lipun hinnan ja oletko oikeutettu alennukseen ");

            // Read age
            
            ika = int.Parse(Console.ReadLine());


            // Term operator //Ehdot 
            // Member

            Console.WriteLine("Oletko oikeutettu johonkin erityisalennukseen");
            Console.WriteLine("0 = ei jäsen");
            Console.WriteLine("1 = opiskelija");
            Console.WriteLine("2 = MTK-jasen");
            Console.WriteLine("3 = Elakelainen");
            Console.WriteLine("4 = Varusmies");
            Console.WriteLine("5 = Opiskelelija ja MTK-jasen");

            int member = int.Parse(Console.ReadLine());

            float discount = CalculateDiscount(ika, member);

            // finaly result
 
            //discount = normalprice * discount / 100;
            yourprice = normalprice - (normalprice * discount / 100);
            Console.WriteLine("Alennus prosentti lipussasi" +" "+ discount);
            Console.WriteLine(" Maksat lipusta" + yourprice + " Euroa ");

            Console.ReadLine();
        }

        // Calculate discount

        static float CalculateDiscount(int age, int member) {

            float discount = 0;

            if (age < 7)
            {
                Console.WriteLine("Alle 7 vuotiaat  ovat oikeutettu ilmaiseen sisaan paasyyn");

                discount = 100; //discount 100%
            }
            if (age > 65)
            {
                Console.WriteLine("Yli 65 vuotta /elakelainen alennus 50%");

                discount = 50;
  

            }

            if ((age < 16) && (age >= 7))
            {
                Console.WriteLine("Nuorisolippu alennus 50%");
              

            }
            if (member==2)
            {
                Console.WriteLine("MTK-jasenten alennus 15%");
                discount = 15; //discount % 
            }

            if (member==4)
            {
                Console.WriteLine("Varusmies alennus 50%");
                discount = 50; //discount % 
            }

            if (member==1 )
            {
                Console.WriteLine("Opiskelija alennus 45%");
                discount = 45; //discount % 
            }

            if (member == 0)
            {
                Console.WriteLine("Ei muita alennuksia");
                discount = 0; //discount % 
            }

            if (member == 3)
            {
                Console.WriteLine("Eläkeläinen");
                discount = 50; //discount % 
            }
            if (member == 5)
            {
                Console.WriteLine("Olet MTK-jasen ja opiskelija");
                discount = 45+15; //discount % 
            }

            // Only one discount /ticket .If you are student and MTK-member with same time you get bouth


            if ((member==5))
            {
                Console.WriteLine("Opiskelija ja MTK-jasenten alennus molemmista ");
                discount = 45 + 15; //discount % 
            }

            return discount;
        }



    }
}
