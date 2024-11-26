using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsApp2selector;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        FillComboBox();
    }

    private void FillComboBox()
    {
        SqlConnection con =
        new SqlConnection("Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "select * from employee";

        command.Connection = con;

        try
        {
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            DataTable dt=new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "fname";
            comboBox1.ValueMember = "ssn";
            // dataGridView1.DataSource = dt;
        }
        catch (Exception)
        {
            Console.WriteLine("wow");
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    // event handler
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con =
            new SqlConnection("Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.Text;
        var id = comboBox1.SelectedValue.ToString();
        command.CommandText = $"select * from employee where ssn = {id}";
        
        command.Connection = con;

        try
        {
            con.Open();
            SqlDataReader dr = command.ExecuteReader();

            DataTable dt=new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            // comboBox1.DataSource = dt;
            // comboBox1.DisplayMember = "fname";
            // comboBox1.ValueMember = "ssn";
            // dataGridView1.DataSource = dt;
        }
        catch (Exception)
        {
            Console.WriteLine("wow");
            throw;
        }
        finally
        {
            con.Close();
        }
    }
}