using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class CarSearch : Form
    {
        public class Car
        {
            public string mark;
            public string model;
            public string type;
            public string color;
            public string sizeOfWheel;
            public string horsepower;
            public string year;
            public Car(string mark, string model, string type, string color, string sizeOfWheel, string horsepower, string year)
            {
                this.mark = mark;
                this.model = model;
                this.type = type;
                this.color = color;
                this.sizeOfWheel = sizeOfWheel;
                this.horsepower = horsepower;
                this.year = year;
            }
            public static List<Car> createCarsList(string path)
            {
                List<Car> CarList = new List<Car>();
                StreamReader readCarList = new StreamReader(@path);
                var listOfCars = readCarList;                
                string lc = listOfCars.ToString();
                string cars = CarList.ToString();
                string s = null;
                foreach (var i in lc)
                {
                    while ((s = listOfCars.ReadLine()) != null)
                    {
                        string[] CarsSplit = s.Split(' ');
                        Car newCar = new Car(CarsSplit[0], CarsSplit[1], CarsSplit[2], CarsSplit[3], CarsSplit[4], CarsSplit[5], CarsSplit[6]);
                        CarList.Add(newCar);
                    }                    
                }
                readCarList.Close();
                return CarList;                
            }                      
            public override string ToString()
            {
                string outString = null;
                outString = "Mark ::: " + mark + "\nModel ::: " + model + "\nType ::: " + type + "\nColor ::: " + color + "\nSizeOfWheel ::: " + sizeOfWheel + "\nHorsepower ::: " + horsepower + "\nYear ::: " + year + "\n--------------------------------------------------------------------------------------------------------------------------------\n";
                return outString;
            }        
        }      
        public CarSearch()
        {
            InitializeComponent();
        }         
        public string way = "Cars.txt";
        public string newCar;
        public string splNewCar;
        public string mark;
        public string model;
        public string type;
        public string color;
        public string sizeOfWheel;
        public string horsepower;
        public string year;        
        public string featcher;               
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            featcher = textBox1.Text.ToString();     
        }       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List<Car> Cars = Car.createCarsList(way);
            if (string.IsNullOrEmpty(featcher))
            {
                MessageBox.Show("You didn't write anything!");
                return;
            }          
            richTextBox1.Clear();
            foreach (Car i in Cars)
            {
                if (i.mark == featcher || i.model == featcher || i.type == featcher || i.color == featcher || i.sizeOfWheel == featcher || i.horsepower == featcher || i.year == featcher)
                {
                    richTextBox1.Text += i.ToString();
                }                
            }            
        }       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            mark = textBox2.Text.ToString();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            model = textBox3.Text.ToString();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            type = textBox4.Text.ToString();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            color = textBox5.Text.ToString();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            sizeOfWheel = textBox6.Text.ToString();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            horsepower = textBox7.Text.ToString();
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            year = textBox8.Text.ToString();
        } 
        private void pictureBox2_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(mark) && string.IsNullOrEmpty(model) && string.IsNullOrEmpty(type) && string.IsNullOrEmpty(color) && string.IsNullOrEmpty(sizeOfWheel) && string.IsNullOrEmpty(horsepower) && string.IsNullOrEmpty(year))
            {
                MessageBox.Show("You didn't write anything!");
                return;
            }
            if (string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(color) || string.IsNullOrEmpty(sizeOfWheel) || string.IsNullOrEmpty(horsepower) || string.IsNullOrEmpty(year))
            { 
                MessageBox.Show("Something you miss!!!");
            }
            else  using (StreamWriter addNewCar = File.AppendText(way))
                {
                    newCar = (mark + " " + model + " " + type + " " + color + " " + sizeOfWheel + " " + horsepower + " " + year);
                    splNewCar = newCar;
                    newCar.ToString().Split(' ');
                    addNewCar.WriteLine(newCar);
                    MessageBox.Show("Successfully saved!!!"); 
                }                      
        }                        
    } 
}
