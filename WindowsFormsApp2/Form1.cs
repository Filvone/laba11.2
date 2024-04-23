using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string[] surname = {"Петров", "Иванов", "Сидоров", "Филонов", "Филатов", "Базовед", "Васильев", "Вагнер", "Матвеев", "Кузнецов", "Херринготонов" };
        public string[] name = { "И", "Ф", "А", "Н", "Д", "Х", "Э"};

        public Form1()
        {
            InitializeComponent();
        }

      
        struct Stud
        {
            public string name;
            public int group;
            public double[] grades;
            public double sred;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("ы.txt");
            Random rnd = new Random();

            Stud[] studarr = new Stud[10];

            for (int i = 0; i < 10; i++)
            {
                Stud stud = new Stud();
                stud.grades = new double[5];
                
                stud.name = surname[rnd.Next(surname.Length)] + " " + name[rnd.Next(name.Length)] + "." + name[rnd.Next(name.Length)] + ".";
                stud.group = rnd.Next(100, 150);
                
                for (int j = 0; j < 5; j++)
                {
                    stud.grades[j] = rnd.Next(3, 6);
                }
                stud.sred = stud.grades.Sum() / 5;
                studarr[i] = stud;
                
            }
            Array.Sort(studarr,( x,y)=>x.sred.CompareTo(y.sred));
           for (int i = 9; i >=0; i--)
            {
                sw.WriteLine(studarr[i].name + " " + studarr[i].group + " " + "средний балл: "+ studarr[i].sred+" grades: " + studarr[i].grades[0] + " " + studarr[i].grades[1] + " " + studarr[i].grades[2] + " " + studarr[i].grades[3] + " " + studarr[i].grades[4]);
            }


            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Студентовые.Items.Clear();
            StreamReader sr = new StreamReader("ы.txt");
            for (int i = 0;i<10 ; i++) 
            {
                Студентовые.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            int count = 0;
            StreamReader sr = new StreamReader("ы.txt");
            
            for (int i = 0; i < 10; i++)
            {
                int k = 0;
                string stud = sr.ReadLine();
                string[] sd = stud.Split(' ');
                for (int j = 0; j < 5; j++)
                {
                    if (sd[sd.Length-1-j]=="4" || sd[sd.Length - 1 - j] == "5")
                    {
                        k++;
                    }
                }
                if (k == 5)
                {
                    
                    count++;
                    listBox1.Items.Add(stud);  
                    
                }
            }
            
            if (count == 0)
            {
                listBox1.Items.Add("Нет хорошистов/отличников");
            }
            sr.Close();
        }
    }
}