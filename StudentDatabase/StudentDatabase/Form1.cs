using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace StudentDatabase
{
    public partial class Form1 : Form
    {
        private SQLiteConnection sqlconn;
        private SQLiteCommand sqlCmd;
        private DataTable sqlDT = new DataTable();
        private DataSet DS = new DataSet();
        private SQLiteDataAdapter DB;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SetConnection()
        {
            sqlconn = new SQLiteConnection("Data Source = C:\\Users\\warid\\source\\repos\\StudentDatabase\\StudentDatabase\\bin\\Debug\\Student.db");
        }

        private void ExecuteQuery(string StudentIDq)
        {
            try
            {
                SetConnection();
                sqlconn.Open();
                sqlCmd = sqlconn.CreateCommand();
                sqlCmd.CommandText = StudentIDq;
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check DB connection or Query in code.", "Database ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            SetConnection();
            sqlconn.Open();

            sqlCmd = sqlconn.CreateCommand();
            string CommandText = "select * from Student";
            DB = new SQLiteDataAdapter(CommandText, sqlconn);
            DS.Reset();
            DB.Fill(DS);
            sqlDT = DS.Tables[0];
            dataGridView1.DataSource = sqlDT;
            sqlconn.Close();

        } 



        private void Exit_Button(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm, If you want to Exit !", "Student Database", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        void ClearAllText(Control con)
        {
            foreach(Control c in con.Controls)
            {
                if(c is TextBox){
                    ((TextBox)c).Clear();
                }
                else
                {
                    ClearAllText(c);
                }
            }
        }


        private void Reset_Button(object sender, EventArgs e)
        {
            ClearAllText(this);

            CourseCodeComboBox.Text = "";
            GenderComboBox.Text = "";
            Transcript_Rich_TB.Text = "";
        }

        private void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            int asciiCode = Convert.ToInt32(e.KeyChar);
            if(asciiCode != 8)
            {
                if(asciiCode >= 48 && asciiCode <= 57)
                {
                    e.Handled = false;
                }
                else
                {
                    MessageBox.Show("Numbers Only", "Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentIDTextBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            CourseCodeComboBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            FirstNameTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SurNmaeTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            GenderComboBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            AgeTextBox.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            AddreeTextBox.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            PostCodeTextBox.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            MobileTextBox.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            AddMathTextBox.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            MathTextBox.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            BusinessTextBox.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            StudentIDTextBox.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            BiologyTextBox.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();

            ChemistrytextBox.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
            ComputingTextBox.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            EnglishTextBox.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            PhysicsTextBox.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();

            TotalScoreTextBox.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
            AverageTextBox.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
            RankingTextBox.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
        }

        private void Student_Result_Click(object sender, EventArgs e)
        {
            Transcript_Rich_TB.AppendText("Student_ID : \t\t\t\t" + StudentIDTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Name : \t\t\t\t" + FirstNameTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Course Code : \t\t\t\t" + CourseCodeComboBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Add Math : \t\t\t\t" + MathTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Math : \t\t\t\t" + MathTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Business : \t\t\t\t" + BusinessTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Biology : \t\t\t\t" + BiologyTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Chemistry : \t\t\t\t" + ChemistrytextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Computing : \t\t\t\t" + ComputingTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("English : \t\t\t\t" + EnglishTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Physics : \t\t\t\t" + PhysicsTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Total Score : \t\t\t\t" + TotalScoreTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Average Score : \t\t\t\t" + AverageTextBox.Text + "\n");
            Transcript_Rich_TB.AppendText("Ranking : \t\t\t\t" + RankingTextBox.Text + "\n");

        }

        private void Update_Click(object sender, EventArgs e)
        {
            string StudentIDq = "insert into Student (StudentID, CourseCode, FirstName, SurName, Gender, Age, Address, PostCode, Mobile, AddMath, Math, Business, Biology, Chemistry, Computing, English, Physics, Total, Average, Ranking) value ('"+StudentIDTextBox.Text+"', '"+CourseCodeComboBox.Text+ "','"+FirstNameTextBox.Text+"', '"+SurNmaeTextBox.Text+"', '"+GenderComboBox.Text+"', '"+AgeTextBox.Text+"', '"+AddreeTextBox.Text+"', '"+PostCodeTextBox.Text+"', '"+MobileTextBox.Text+"', '"+AddMathTextBox.Text+"', '"+MathTextBox.Text+"', '"+BusinessTextBox.Text+"', '"+BiologyTextBox.Text+"', '"+ChemistrytextBox.Text+"', '"+ComputingTextBox.Text+"', '"+EnglishTextBox.Text+"', '"+PhysicsTextBox.Text+"', '"+TotalScoreTextBox.Text+"', '"+AverageTextBox.Text+"', '"+RankingTextBox.Text+"')";

            ExecuteQuery(StudentIDq);
            LoadData();
        }
    }
}
