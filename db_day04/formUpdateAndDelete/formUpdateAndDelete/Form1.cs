using System.Data;
using Microsoft.Data.SqlClient;

namespace formUpdateAndDelete;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        FillProjectComboBox();
    }

    private void FillProjectComboBox()
    {
        SqlConnection con =
            new SqlConnection(
                "Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        // command.CommandType = System.Data.CommandType.Text;
        
        command.CommandText =
            "select projid, projname from project";

        command.Connection = con;
        try
        {
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            //
            DataTable dt=new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "projname";
            comboBox1.ValueMember = "projid";
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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con =
            new SqlConnection(
                "Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        
        command.CommandText =
            "select * from project where projid=@projid";

        command.Parameters.AddWithValue("@projid", comboBox1.SelectedValue.ToString());
        
        command.Connection = con;
        try
        {
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            //
            DataTable dt=new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "projname";
            comboBox1.ValueMember = "projid";
            textBox1.Text = dt.Rows[0]["projid"].ToString();
            textBox2.Text = dt.Rows[0]["projname"].ToString();
            textBox3.Text = dt.Rows[0]["plocation"].ToString();
            textBox4.Text = dt.Rows[0]["deptid"].ToString();
            textBox1.Enabled = false;
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

    private void button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection con =
            new SqlConnection(
                "Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();
        
        command.CommandText =
            "update project set projname=@projname, plocation=@plocation, deptid=@deptid where projid=@projid";
        command.Parameters.AddWithValue("@projid", textBox1.Text); 
        command.Parameters.AddWithValue("@projname", textBox2.Text); 
        command.Parameters.AddWithValue("@plocation", textBox3.Text); 
        command.Parameters.AddWithValue("@deptid", textBox4.Text); 
        

        command.Connection = con;
        
        try
        {
            con.Open();
            result.Text = $"{command.ExecuteNonQuery()} rows affected";
            FillProjectComboBox();
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

    private void delete_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(
                $"Are you sure you want to delete {textBox2.Text.ToString()} this project??!?!!?!!",
                "وجب التنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
        SqlConnection con =
            new SqlConnection(
                "Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

        SqlCommand command = new SqlCommand();

        command.CommandText =
            "delete from project where projid=@projid";
        command.Parameters.AddWithValue("@projid", textBox1.Text);

        command.Connection = con;

        try
        {
            con.Open();
            result.Text = $"{command.ExecuteNonQuery()} rows deleted";
            FillProjectComboBox();
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