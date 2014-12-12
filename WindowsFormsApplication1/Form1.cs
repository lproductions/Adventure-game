using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        string Health = "Health : 10                    ";
        string Armour = "Armour : 10                    ";
        string Coordinates = "Location: 15,3                   ";
        int xcoordinate = 15;
        int ycoordinate = 3;
        bool namepicked = false;
        bool ready = false;
        string name;
        string namedisplay;
        string story;
        double temp= 35.0D;
        bool day = true;
        bool ismoved = false;
        bool isviewingmap = false;
        string temperture = "35.0C                    ";
       string maptext = "";
        bool deniednorth = false;
        bool deniedsouth = false;
        bool deniedwest = false;
        bool deniedeast = false;
        area[] land;
        System.Timers.Timer aTimer;
        Random r1;

        public Form1() {
            r1 = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute + DateTime.Now.Month + DateTime.Now.Hour * DateTime.Now.Second);
            land = new area[256];
            for (int i = 0; i < 256;i++ ) {
                land[i] = new area(r1);
            }
            InitializeComponent();
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, richTextBox1.Font.Size);
            textBox2.KeyDown += new KeyEventHandler(textBox2_KeyPress);
            richTextBox1.Text = "What is thou Adventures Name";
            pickreigningchamp();


        }
        public void pickreigningchamp()
        {
            int reignarea = r1.Next(0,255);
            while (reignarea == 78 | reignarea == 79 | reignarea == 80 | reignarea == 110 | reignarea == 111 | reignarea == 112 | reignarea == 142 | reignarea == 143 | reignarea == 144)
            {
                 reignarea = r1.Next(0, 255);
            }
            land[reignarea].biome = 50;
        }
        public void map()
        {
             maptext = null;
                        isviewingmap = true;
                        mainsetup();
                        richTextBox1.Text += Environment.NewLine + Environment.NewLine;
                        int h = 0;
                            for (int i = 0; i < 256; i++) {

                                h++;
                               
                                    if(!land[i].explored){
                                        Console.WriteLine(i);
                                    maptext += "[" + "U" +"]";
                                    }
                                    else {
                                        maptext += "[" + "E" + "]";
                                    }


                                    if (h == 32) {
                                        maptext += Environment.NewLine;
                                        h = 0;
                                    }
                            }
                        

                    
        }

        public void command(string text123) {
            if (namepicked == true) {
                if (ready) {
                    if (text123.ToLower().Equals("map")) {
                        map();
                        

                    }
                    else if (text123.ToLower().Equals("move up") | text123.ToLower().Equals("move north") | text123.ToLower().Equals("up")) {
                        if (ycoordinate != 0) {
                            ycoordinate--;
                            Coordinates ="Location: " + xcoordinate + "," +ycoordinate + "                   ";
                            ismoved = true;
                            callmainupdate();
                            deniednorth = false;
                            deniedeast = false;
                            deniedsouth = false;
                            deniedwest = false;
                            land[xcoordinate + (ycoordinate * 32)].explored = true;
                        }
                        else {
                            callmainupdate();
                            deniednorth = true;
                        }
                        isviewingmap = false;
                    }

                        //moving
                   
                    else if (text123.ToLower().Equals("move left") | text123.ToLower().Equals("move west") | text123.ToLower().Equals("left")) {
                        if (xcoordinate != 0) {
                            xcoordinate--;
                            Coordinates = "Location: " + xcoordinate + "," + ycoordinate + "                   ";
                            ismoved = true;
                            callmainupdate();
                            deniednorth = false;
                            deniedeast = false;
                            deniedsouth = false;
                            deniedwest = false;
                            land[xcoordinate + (ycoordinate * 32)].explored = true;
                        }
                        else {
                            callmainupdate();
                            deniedwest = true;
                        }
                        isviewingmap = false;
                    }
                    else if (text123.ToLower().Equals("move down") | text123.ToLower().Equals("move south") | text123.ToLower().Equals("down")) {
                        if (ycoordinate != 7) {
                            ycoordinate++;
                            Coordinates = "Location: " + xcoordinate + "," + ycoordinate + "                   ";
                            ismoved = true;
                            callmainupdate();
                            deniednorth = false;
                            deniedeast = false;
                            deniedsouth = false;
                            deniedwest = false;
                            land[xcoordinate + (ycoordinate * 32)].explored = true;
                        }
                        else {
                            callmainupdate();
                            deniedsouth = true;
                        }
                        isviewingmap = false;
                    }
                    else if (text123.ToLower().Equals("move right") | text123.ToLower().Equals("move east") | text123.ToLower().Equals("right")) {
                        if (xcoordinate != 31) {
                            xcoordinate++;
                            Coordinates = "Location: " + xcoordinate + "," + ycoordinate + "                   ";
                            ismoved = true;

                            deniednorth = false;
                            deniedeast = false;
                            deniedsouth = false;
                            deniedwest = false;
                            land[xcoordinate + (ycoordinate * 32)].explored = true;
                            callmainupdate();
                        }
                        else {
                            
                            deniedeast = true;
                            callmainupdate();
                        }
                        isviewingmap = false;
                    }


                }

            else {
                if (text123.ToLower().Equals("yes") | text123.ToLower().Equals("yea") | text123.ToLower().Equals("ok")) {
                richTextBox1.Text = "Lets Go";
                Task.Delay(2000).Wait();
                mainsetup();

                aTimer = new System.Timers.Timer(500);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += halfsecondupdate;
                aTimer.Enabled = true;
                ready = true;
            }

        }







            }
            else {
                name = text123;
                namedisplay = "Name: " + text123 + "                    ";
                story = "Now " + name + " I am the voice you will hear in your head every now and then." + Environment.NewLine +
                        "Every year a young boy or girl is picked to enter this arena," + Environment.NewLine +
                        "To get out you must beat the previous champion," + Environment.NewLine +
                        "but beware after 50 days the previous champion will come looking for you so you best be ready." + Environment.NewLine +
                        "Unfortunatly you are under control of a random spectator viewing you from his computer,"+ Environment.NewLine + 
                        "So Are You Ready?";
                richTextBox1.Text = story;



                story = null;
                land[111].explored = true;
                namepicked = true;




            }
            textBox2.Text = "";
        }
         
       
        void textBox2_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {

                command(textBox2.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;

            }



        }
        public void setTextBox(string value) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(setTextBox), new object[] { value });
                return;
            }
            richTextBox1.Text = value;
        }
        public void addTextBox(string value) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(setTextBox), new object[] { value });
                return;
            }
            richTextBox1.Text += value;
        }
        public void callmainupdate() {
            if (InvokeRequired) {
                this.Invoke(new Action(callmainupdate));
                return;
            }
            mainsetup();
        }



        void mainsetup() {

            if (!ismoved) {
                if (!isviewingmap) {
                setTextBox(namedisplay + Health + Armour + Coordinates + temperture+  
                    Environment.NewLine + Environment.NewLine + Environment.NewLine + "you spawn in " +
                    land[xcoordinate + (ycoordinate * 16)].description + ".");
                if (deniednorth) {
                    addTextBox(Environment.NewLine + "You cannot move further north");
                }
                if (deniedsouth) {
                    addTextBox(Environment.NewLine + "You cannot move further south");
                }
                if (deniedwest) {
                    addTextBox(Environment.NewLine + "You cannot move further west");
                }
                if (deniedeast) {
                    addTextBox(Environment.NewLine + "You cannot move further east");
                }
                }
                else {
                     setTextBox(namedisplay + Health + Armour + Coordinates + temperture+  
                    Environment.NewLine + Environment.NewLine + Environment.NewLine + maptext);
                }
            }
            if (ismoved) {
                if (!isviewingmap) {
                    setTextBox(namedisplay + Health + Armour + Coordinates + temperture +
                        Environment.NewLine + Environment.NewLine + Environment.NewLine + "you are in " +
                        land[xcoordinate + (ycoordinate * 16)].description + ".");
                    if (deniednorth) {
                        addTextBox(Environment.NewLine + "You cannot move further north");
                    }
                    if (deniedsouth) {
                        addTextBox(Environment.NewLine + "You cannot move further south");
                    }
                    if (deniedwest) {
                        addTextBox(Environment.NewLine + "You cannot move further west");
                    }
                    if (deniedeast) {
                        addTextBox(Environment.NewLine + "You cannot move further east");
                    }
                }
                else {
                    setTextBox(namedisplay + Health + Armour + Coordinates + temperture +
                        Environment.NewLine + Environment.NewLine + Environment.NewLine + maptext);
                }
            }

           
            //name
            richTextBox1.Select(0, name.Length - 1);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.DeselectAll();
           

            //health
            richTextBox1.Select(richTextBox1.Text.IndexOf(Health), Health.Length - 1);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.DeselectAll();
            richTextBox1.SelectionColor = Color.Empty;
            //armour


            richTextBox1.DeselectAll();
            richTextBox1.Select(richTextBox1.Text.IndexOf(Armour), richTextBox1.Text.IndexOf(Armour) - 1);
            richTextBox1.SelectionColor = Color.Blue;


            //location

            richTextBox1.DeselectAll();
            richTextBox1.Select(richTextBox1.Text.IndexOf(Coordinates), richTextBox1.Text.IndexOf(Coordinates) + Coordinates.Length - 1);
            richTextBox1.SelectionColor = Color.Black;

            //temp
            richTextBox1.DeselectAll();
            richTextBox1.Select(richTextBox1.Text.IndexOf((temperture)), richTextBox1.Text.IndexOf(temperture.ToString()) + temperture.Length - 1);
            if (temp > 34) {
                richTextBox1.SelectionColor = Color.Red;
            }
            
            if (temp < 34) {
                richTextBox1.SelectionColor = Color.Blue;
            }
            richTextBox1.DeselectAll();


           richTextBox1.Select(richTextBox1.Text.IndexOf(temperture) + (temperture.Length + 1), richTextBox1.Text.Length - 1);
            richTextBox1.SelectionColor = Color.Black;

          
            namepicked = true;
            
        }


        void halfsecondupdate(Object source, ElapsedEventArgs e) {
            if (day) {
                if (land[xcoordinate + (ycoordinate * 16)].weather == 0) {
                    temp += 0.01;
                }
                else if (land[xcoordinate + (ycoordinate * 16)].weather == 1) {
                    temp -= 0.005;
                }
                else if (land[xcoordinate + (ycoordinate * 16)].weather == 2) {
                    temp -= 0.02;
                }
            }
            else {

                if (land[xcoordinate + (ycoordinate * 16)].weather == 0) {
                    temp -= 0.005;
                }
                else if (land[xcoordinate + (ycoordinate * 16)].weather == 1) {
                    temp -= 0.025;
                }
                else if (land[xcoordinate + (ycoordinate * 16)].weather == 2) {
                    temp -= 0.10;
                }

            }

            temperture = (Math.Truncate((temp * 100))   / 100).ToString() + " C                    ";
                callmainupdate();
                
             
            
        }
    }
}
