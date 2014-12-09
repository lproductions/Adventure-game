﻿using System;
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
        area[] land;
        System.Timers.Timer aTimer;

        public Form1() {
            Random r1 = new Random(DateTime.Now.Millisecond * DateTime.Now.Minute + DateTime.Now.Month + DateTime.Now.Hour * DateTime.Now.Second);
            land = new area[256];
            for (int i = 0; i < 256;i++ ) {
                land[i] = new area(r1);
            }
            InitializeComponent();
            textBox2.KeyDown += new KeyEventHandler(textBox2_KeyPress);
            richTextBox1.Text = "What is thou Adventures Name";



        }

        public void command(string text123) {
            if (namepicked == true) {
                if (ready) {
                    if (text123.ToLower().Equals("map")) {
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
                story = "Now " + name + " I am the voice you will hear in your head every now and then" + Environment.NewLine +
                        "You have been Cast under a Wizards spell so you cannot leave this area" + Environment.NewLine +
                        "To Get Back to your home you must defeat this evil Wizard " + Environment.NewLine +
                        "Unfortunatly you are under the control of the nearest person i could find so Are You Ready?";
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
                    land[xcoordinate + (ycoordinate * 16)].description);
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
                        land[xcoordinate + (ycoordinate * 16)].description);
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
