using EF_CRUD.Context;
using EF_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CRUD;

public partial class Form1 : Form
{
    MyDbContext db;
    public Form1()
    {
        db = new MyDbContext();
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        db.Projects.Load(); 
        db.Departments.Load();
        
        var projectsList = db.Projects.Include(d => d.Dept).Select(p => new {p.ProjId, p.ProjName, p.Plocation, department_name = p.Dept.DeptName}).ToList();
        dataGridView1.DataSource = projectsList;
        
        var departmentsList = db.Departments.ToList();
        cb_department.DataSource = departmentsList;
        // combo box has value and display
        // display is the text the user see
        // value used by me 
        cb_department.DisplayMember = "DeptName";
        cb_department.ValueMember = "DeptId";
        
        btn_delete.Visible = false;
        btn_update.Visible = false;
    }

    private void btn_add_Click(object sender, EventArgs e)
    {
        var project = new Project()
        {
            ProjName = txt_project_name.Text,
            Plocation = txt_project_locaiton.Text,
            DeptId = int.Parse(cb_department.SelectedValue.ToString()),
        };

        db.Projects.Add(project);
        db.SaveChanges();

        var projectsList = db.Projects.Local.Select(p => new
        {
            p.ProjId,
            p.ProjName,
            p.Plocation,
            department_name = p.Dept.DeptName
        }).ToList();
        dataGridView1.DataSource =  projectsList;

        txt_project_name.Text = txt_project_locaiton.Text = string.Empty;
        MessageBox.Show($"Added project {project.ProjName} successfully");
    }

    // update
    private int id;
    private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        
        var project = db.Projects.SingleOrDefault(p => p.ProjId == id);
        txt_project_name.Text = project.ProjName;
        txt_project_locaiton.Text = project.Plocation;
        cb_department.SelectedValue = project.DeptId;
        
        btn_add.Visible = false;
        btn_delete.Visible = true;
        btn_update.Visible = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // find the project with id of the textbox
        var project = db.Projects.SingleOrDefault(p => p.ProjId == id);
        project.ProjName = txt_project_name.Text;
        project.Plocation = txt_project_locaiton.Text;
        project.DeptId = int.Parse(cb_department.SelectedValue.ToString());
        
        db.SaveChanges();
        
        var projectsList = db.Projects.Include(d => d.Dept).Select(p => new {p.ProjId, p.ProjName, p.Plocation, department_name = p.Dept.DeptName}).ToList();
        dataGridView1.DataSource = projectsList;
        txt_project_name.Text = txt_project_locaiton.Text = string.Empty;
        
        btn_add.Visible = true;
        btn_delete.Visible = false;
        btn_update.Visible = false;
        MessageBox.Show($"updated project {project.ProjName} successfully");
    }

    private void btn_delete_Click(object sender, EventArgs e)
    {
        var project = db.Projects.SingleOrDefault(p => p.ProjId == id);
        db.Remove(project);

        db.SaveChanges();
        var projectsList = db.Projects.Include(d => d.Dept).Select(p => new {p.ProjId, p.ProjName, p.Plocation, department_name = p.Dept.DeptName}).ToList();
        dataGridView1.DataSource = projectsList;
        txt_project_name.Text = txt_project_locaiton.Text = string.Empty;
        
        btn_add.Visible = false;
        btn_delete.Visible = true;
        btn_update.Visible = true;
        MessageBox.Show($"deleted project {project.ProjName} successfully");
    }
}