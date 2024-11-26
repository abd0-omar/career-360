using Microsoft.Data.SqlClient;

namespace FormInsert;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /*
     *         SqlConnection con =
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
     */
    // private void label1_Click(object sender, EventArgs e)
    // {
    //     throw new System.NotImplementedException();
    // }

    // private void projname_Click(object sender, EventArgs e)
    // {
    //     throw new System.NotImplementedException();
    // }

    private void insert_Click(object sender, EventArgs e)
    {
        SqlConnection con =
            new SqlConnection(
                "Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        command.CommandType = System.Data.CommandType.Text;
        // var id = comboBox1.SelectedValue.ToString();
        command.CommandText =
            "INSERT INTO project (projid, projname, plocation, deptid) VALUES (@projid, @projname, @plocation, @deptid)";

        command.Parameters.AddWithValue("@projid", projidtextBox1.Text); 
        command.Parameters.AddWithValue("@projname", projnametextBox.Text);
        command.Parameters.AddWithValue("@plocation", projlocationtextBox2.Text);
        command.Parameters.AddWithValue("@deptid", deptidtextBox3.Text);
        command.Connection = con;
        try
        {
            con.Open();
            insert.Text = $"{command.ExecuteNonQuery().ToString()} rows affected";
            SqlDataReader dr = command.ExecuteReader();
            //
            // DataTable dt=new DataTable();
            // dt.Load(dr);
            // dataGridView1.DataSource = dt;
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