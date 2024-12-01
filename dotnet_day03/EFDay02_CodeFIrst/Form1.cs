using EFDay02_CodeFIrst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDay02_CodeFIrst;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var db = new NewsContext();
        // lazy loaded
        dataGridView1.DataSource = db.News.ToList();
    }
}