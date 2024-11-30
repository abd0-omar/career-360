namespace EF_CRUD;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dataGridView1 = new System.Windows.Forms.DataGridView();
        txt_project_name = new System.Windows.Forms.TextBox();
        txt_project_locaiton = new System.Windows.Forms.TextBox();
        cb_department = new System.Windows.Forms.ComboBox();
        project_name = new System.Windows.Forms.Label();
        project_locaiton = new System.Windows.Forms.Label();
        department = new System.Windows.Forms.Label();
        btn_add = new System.Windows.Forms.Button();
        btn_update = new System.Windows.Forms.Button();
        btn_delete = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeight = 34;
        dataGridView1.Location = new System.Drawing.Point(12, 249);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 62;
        dataGridView1.Size = new System.Drawing.Size(776, 189);
        dataGridView1.TabIndex = 0;
        dataGridView1.MouseDoubleClick += dataGridView1_MouseDoubleClick;
        // 
        // txt_project_name
        // 
        txt_project_name.Location = new System.Drawing.Point(576, 64);
        txt_project_name.Name = "txt_project_name";
        txt_project_name.Size = new System.Drawing.Size(140, 31);
        txt_project_name.TabIndex = 1;
        // 
        // txt_project_locaiton
        // 
        txt_project_locaiton.Location = new System.Drawing.Point(576, 101);
        txt_project_locaiton.Name = "txt_project_locaiton";
        txt_project_locaiton.Size = new System.Drawing.Size(140, 31);
        txt_project_locaiton.TabIndex = 3;
        // 
        // cb_department
        // 
        cb_department.FormattingEnabled = true;
        cb_department.Location = new System.Drawing.Point(576, 138);
        cb_department.Name = "cb_department";
        cb_department.Size = new System.Drawing.Size(184, 33);
        cb_department.TabIndex = 4;
        // 
        // project_name
        // 
        project_name.Location = new System.Drawing.Point(391, 67);
        project_name.Name = "project_name";
        project_name.Size = new System.Drawing.Size(159, 23);
        project_name.TabIndex = 5;
        project_name.Text = "project_name";
        // 
        // project_locaiton
        // 
        project_locaiton.Location = new System.Drawing.Point(391, 104);
        project_locaiton.Name = "project_locaiton";
        project_locaiton.Size = new System.Drawing.Size(159, 23);
        project_locaiton.TabIndex = 6;
        project_locaiton.Text = "project_location";
        // 
        // department
        // 
        department.Location = new System.Drawing.Point(391, 141);
        department.Name = "department";
        department.Size = new System.Drawing.Size(159, 23);
        department.TabIndex = 7;
        department.Text = "department";
        // 
        // btn_add
        // 
        btn_add.Location = new System.Drawing.Point(391, 188);
        btn_add.Name = "btn_add";
        btn_add.Size = new System.Drawing.Size(117, 42);
        btn_add.TabIndex = 8;
        btn_add.Text = "add";
        btn_add.UseVisualStyleBackColor = true;
        btn_add.Click += btn_add_Click;
        // 
        // btn_update
        // 
        btn_update.Location = new System.Drawing.Point(520, 188);
        btn_update.Name = "btn_update";
        btn_update.Size = new System.Drawing.Size(117, 42);
        btn_update.TabIndex = 9;
        btn_update.Text = "update";
        btn_update.UseVisualStyleBackColor = true;
        btn_update.Click += button1_Click;
        // 
        // btn_delete
        // 
        btn_delete.Location = new System.Drawing.Point(643, 188);
        btn_delete.Name = "btn_delete";
        btn_delete.Size = new System.Drawing.Size(117, 42);
        btn_delete.TabIndex = 10;
        btn_delete.Text = "delete";
        btn_delete.UseVisualStyleBackColor = true;
        btn_delete.Click += btn_delete_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btn_delete);
        Controls.Add(btn_update);
        Controls.Add(btn_add);
        Controls.Add(department);
        Controls.Add(project_locaiton);
        Controls.Add(project_name);
        Controls.Add(cb_department);
        Controls.Add(txt_project_locaiton);
        Controls.Add(txt_project_name);
        Controls.Add(dataGridView1);
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btn_delete;

    private System.Windows.Forms.Button btn_update;

    private System.Windows.Forms.Button btn_add;

    private System.Windows.Forms.Label project_name;
    private System.Windows.Forms.Label project_locaiton;
    private System.Windows.Forms.Label department;

    private System.Windows.Forms.ComboBox cb_department;

    private System.Windows.Forms.TextBox txt_project_name;
    private System.Windows.Forms.TextBox txt_project_locaiton;

    private System.Windows.Forms.DataGridView dataGridView1;

    #endregion
}