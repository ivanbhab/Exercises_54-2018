using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercises_54_2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load_1(object sender, EventArgs e)
        {
            List<ExerciseResult> lista = new List<ExerciseResult>();
            using (SqlConnection konkcija = new SqlConnection())
            {
                konkcija.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FacultyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                konkcija.Open();
                string q = "select* from ExerciseResults";

                SqlCommand sqlCommand = new SqlCommand(q, konkcija);
                using (SqlDataReader citac = sqlCommand.ExecuteReader())
                {


                    while (citac.Read())
                    {
                        ExerciseResult exerciseResult = new ExerciseResult();
                        exerciseResult.Id = (int)citac.GetInt32(0);
                        exerciseResult.StudentName = citac.GetString(1);
                        exerciseResult.StudentIndex = citac.GetString(2);
                        exerciseResult.Point = (int)citac.GetInt32(3);
                        lista.Add(exerciseResult);
                    }


                }


            }
            listBox1.Items.Clear();
            foreach (ExerciseResult exerciseResult1 in lista)
            {
                listBox1.Items.Add(exerciseResult1.ToString());
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection konkcija = new SqlConnection())
            {
                konkcija.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FacultyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                konkcija.Open();

                string q = String.Format("INSERT into ExerciseResults values('{0}','{1}',{2},{3})",
                 Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);

                SqlCommand komanda = new SqlCommand(q, konkcija);
                komanda.ExecuteNonQuery();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
            {
                using (SqlConnection konkcija = new SqlConnection())
                {
                    konkcija.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FacultyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                    konkcija.Open();
                    string naredba = String.Format("UPDATE ExerciseResults set Id={0}, StudentName = '{1}', StudentIndex = '{2}', Point = '{3}'",
                 textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                    SqlCommand komanda = new SqlCommand(naredba, konkcija);
                    komanda.ExecuteNonQuery();


                }
            }
        }
    }
}
