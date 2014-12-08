using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1 {
    class area {
        public byte animal;
        public short biome;
        public byte environment1;
        public byte environment2;
        public byte weather;
        public bool explored = false;
        public string description = "";
        static int test = 0;
        string environmentdescription = "";
        public area(Random r) {


            biome = (short)r.Next(0, 11);
           
            weather = (byte)r.Next(0, 3);

            // description

            if (biome == 0) {
                environment1 = (byte)r.Next(0,3);
                environment2 = (byte)r.Next(0, 3);
                description = "a barren wasteland";
                animal = 0;
                if (environment1 == 0  | environment1 == 1  | environment1 == 2 ) {
                    environmentdescription = "." + Environment.NewLine + "There are some ruins here";
                }

                if (environment2 == 1) {
                    environmentdescription += " along with some broken carts.";
                }

            }



            else if (biome == 1) {
                description = "a luxurious greenland";

                animal = (byte)r.Next(1, 31);
                if (animal == 7 | animal == 19 | animal == 20 | animal == 21 | animal == 22 | animal == 23 | animal == 24
                    | animal == 25 | animal == 26 | animal == 27 | animal == 28 | animal == 29 | animal == 30) {

                    animal = 6;

                }


            }


            else if (biome == 2 | biome == 3) {
                description = "a mountainous region";
                animal = (byte)r.Next(0, 19);
            }


            else if (biome == 4 | biome == 5) {
                description = "a Desert";
                animal = 0;

                if (environment1 == 0) {
                    environmentdescription = "." + Environment.NewLine + "With some Cacti";
                }
                if (environment2 == 1) {
                    environmentdescription += " with a small oasis.";
                }
            }


            else if (biome == 6 | biome == 7 | biome == 8) {
                description = "a Forest ";

                environment1 = (byte)r.Next(0, 3);
                environment2 = (byte)r.Next(0, 3);
                animal = (byte)r.Next(1, 19);

                while (animal == 7) {
                    animal = (byte)r.Next(1, 19);
                }

                if (environment1 == 0) {
                    environmentdescription = "." + Environment.NewLine + "There is a little amount of trees here";
                }
                else if (environment1 == 1) {
                    environmentdescription = "." + Environment.NewLine + "There are some Birch trees here";
                }
                else if (environment1 == 2) {
                    environmentdescription = "." + Environment.NewLine + "There are alot of trees here";
                }

                if (environment2 == 1) {
                    environmentdescription += " along with a little lake in the middle.";

                }else if (environment2 == 1) {
                    environmentdescription += " along with a majestic tree.";

                }
            }



            if (animal == 0 | animal == 7) {


            }
            else if (animal == 1 | animal == 8 | animal == 9 | animal == 18) {
                description += "  with some wooly sheep";

            }
            else if (animal == 2 | animal == 10 | animal == 11 | animal == 17) {
                description += " with some scary Bears";

            }
            else if (animal == 3 | animal == 12 | animal == 13) {
                description += "  with some Horses";

            }
            else if (animal == 4 | animal == 14 | animal == 15) {
                description += "  with some Pigs";

            }
            else if (animal == 5 | animal == 16) {

                description += "  with some Cows";
            }
            else if (animal == 6) {

                description += " with some Pigs, Cows And Sheep lucky you....i'll go away in jealousy now";
            }



            description += environmentdescription;
            Console.Out.WriteLine(description);
        }
    }
}
