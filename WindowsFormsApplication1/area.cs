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
        public area(Random r) {
             
            animal = (byte)r.Next(0, 7);
            biome = (short)r.Next(0, 11);
            environment1 = (byte)r.Next(0, 11);
            environment2 = (byte)r.Next(0, 11);
            weather = (byte)r.Next(0, 3);
            
            // description

            if(biome ==0){
                description = "a barren wasteland ";
                animal = 0;
                
            }
            else if(biome==1){
                description = "a luxurious greenland";
                if(animal == 0){
                animal =(byte) r.Next(1,9);
                if (animal == 7 | animal == 8) {
                    Console.Out.WriteLine(animal);
                    animal = 6;
                }
                }


            }
            else if (biome == 2) {
                description = "a mountainous region";
            }
            else if (biome == 3) {
                description = "a barren wasteland ";
            }
            if(animal == 0){


            }
            else if (animal == 1) {
                description += "  with some wooly sheep";

            }
            else if (animal == 2) {
                description += " with some scary Bears";

            }
            else if (animal == 3) {
                description += "  with some Horses";

            }
            else if (animal == 4) {
                description += "  with some Pigs";

            }
            else if (animal == 5) {

                description += "  with some Cows";
            }
            else if (animal == 6) {

                description += "with some Pigs, Cows And Sheep lucky you....i'll go away in jealousy now";
            }
            Console.Out.WriteLine(description);
        }
    }
}
