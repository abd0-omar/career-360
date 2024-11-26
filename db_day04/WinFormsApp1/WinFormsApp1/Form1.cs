using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1;

public partial class Form1 : Form
{
            public Form1()
    {
        InitializeComponent();
        FillAuthorsToGridView();
    }

    private void FillAuthorsToGridView()
    {
        //1,2,3- ip , Auth,Database    Connection object [sqlConnection]
        SqlConnection con =
            // new SqlConnection("Server=bodbod\\SQLEXPRESS;Database=pubs;Trusted_connection=true;TrustServerCertificate=true");
        // new SqlConnection("Server=bodbod\\SQLEXPRESS;Database=myemployees;Trusted_connection=true;TrustServerCertificate=true");
        new SqlConnection("Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        // bodbod\SQLEXPRESS
        
        //new SqlConnection("Data Source=DESKTOP-MFABGAV;initial catalog=pubs;integrated security=true");

        //4- command
        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "select * from employee";

        //5- IMPORTANT DON'T FORGET
        ///Link Command to connection object before Opening Connection
        command.Connection = con;

        //6-open Connection
        try
        {
            con.Open();
            //7- container SqlDataReader
            SqlDataReader dr = command.ExecuteReader();

            //8- data binding
            DataTable dt=new DataTable();
            dt.Load(dr);
            ///unfortunately DataTable object has no GUI
            //so we use data grid view to display data from Data Table
            // gridAuthors.DataSource = dt;
            // dataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;
        }
        catch (Exception)
        {
            
            Console.WriteLine("wow");

            throw;
        }
        finally
        {
            //close connection
            con.Close();
        }

            
    }
}