using System.Data;
using System.Data.SQLite;

namespace SQLiteDemo03
{
    public partial class fStudent : Form
    {
        public fStudent()
        {
           InitializeComponent();
        }

        private void sqliteDBConnect()
        {
            string connectionString = "Data Source=F:\\NAV\\com\\vidaibao\\learning\\csharp\\sqlitedemo\\Student.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                Console.WriteLine(connectionString);
                connection.Open();
                // use the connection
                try
                {
                    var command = new SQLiteCommand("SELECT * FROM Students02", connection);
                    command.ExecuteNonQuery();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // read the data from the current row
                        var id = reader.GetString(0);
                        var name = reader.GetString(1);
                        var yob = reader.GetInt32(2);
                        var gpa = reader.GetFloat(3);

                        // do something with the data
                        Console.WriteLine("ID: {0}, Name: {1}, Age: {2}, Gpa: {3}", id, name, yob, gpa);

                    }

                    // load data into DataGridView
                    command = new SQLiteCommand("SELECT * FROM Students02", connection);
                    var adapter = new SQLiteDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);

                    dataGridView1.DataSource = dataset.Tables[0];

                    connection.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Starting sqliteDBConnect...");
            sqliteDBConnect();
            Console.WriteLine("Done.");
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentId_Enter(object sender, EventArgs e)
        {
            if (txtStudentId.Text == "1")
            {
                txtStudentId.Text = "";
                txtStudentId.ForeColor = Color.Black;
            }
        }

        private void txtStudentId_Leave(object sender, EventArgs e)
        {
            if (txtStudentId.Text == "")
            {
                txtStudentId.Text = "1";
                txtStudentId.ForeColor = Color.Gray;
            }
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}