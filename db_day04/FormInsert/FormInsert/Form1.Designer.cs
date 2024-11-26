namespace FormInsert;

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
        projname = new System.Windows.Forms.Label();
        projlocation = new System.Windows.Forms.Label();
        deptid = new System.Windows.Forms.Label();
        projnametextBox = new System.Windows.Forms.TextBox();
        projlocationtextBox2 = new System.Windows.Forms.TextBox();
        deptidtextBox3 = new System.Windows.Forms.TextBox();
        insert = new System.Windows.Forms.Button();
        projid = new System.Windows.Forms.Label();
        projidtextBox1 = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // projname
        // 
        projname.Location = new System.Drawing.Point(24, 42);
        projname.Name = "projname";
        projname.Size = new System.Drawing.Size(100, 23);
        projname.TabIndex = 0;
        projname.Text = "projname";
        // 
        // projlocation
        // 
        projlocation.Location = new System.Drawing.Point(24, 100);
        projlocation.Name = "projlocation";
        projlocation.Size = new System.Drawing.Size(100, 23);
        projlocation.TabIndex = 1;
        projlocation.Text = "projlocation";
        // 
        // deptid
        // 
        deptid.Location = new System.Drawing.Point(24, 155);
        deptid.Name = "deptid";
        deptid.Size = new System.Drawing.Size(100, 23);
        deptid.TabIndex = 2;
        deptid.Text = "deptid";
        // 
        // projnametextBox
        // 
        projnametextBox.Location = new System.Drawing.Point(215, 42);
        projnametextBox.Name = "projnametextBox";
        projnametextBox.Size = new System.Drawing.Size(260, 31);
        projnametextBox.TabIndex = 3;
        // 
        // projlocationtextBox2
        // 
        projlocationtextBox2.Location = new System.Drawing.Point(215, 100);
        projlocationtextBox2.Name = "projlocationtextBox2";
        projlocationtextBox2.Size = new System.Drawing.Size(260, 31);
        projlocationtextBox2.TabIndex = 4;
        // 
        // deptidtextBox3
        // 
        deptidtextBox3.Location = new System.Drawing.Point(215, 152);
        deptidtextBox3.Name = "deptidtextBox3";
        deptidtextBox3.Size = new System.Drawing.Size(260, 31);
        deptidtextBox3.TabIndex = 5;
        // 
        // insert
        // 
        insert.Location = new System.Drawing.Point(290, 233);
        insert.Name = "insert";
        insert.Size = new System.Drawing.Size(111, 49);
        insert.TabIndex = 6;
        insert.Text = "insert";
        insert.UseVisualStyleBackColor = true;
        insert.Click += insert_Click;
        // 
        // projid
        // 
        projid.Location = new System.Drawing.Point(24, 9);
        projid.Name = "projid";
        projid.Size = new System.Drawing.Size(100, 23);
        projid.TabIndex = 7;
        projid.Text = "projid";
        // 
        // projidtextBox1
        // 
        projidtextBox1.Location = new System.Drawing.Point(215, 1);
        projidtextBox1.Name = "projidtextBox1";
        projidtextBox1.Size = new System.Drawing.Size(260, 31);
        projidtextBox1.TabIndex = 8;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(projidtextBox1);
        Controls.Add(projid);
        Controls.Add(insert);
        Controls.Add(deptidtextBox3);
        Controls.Add(projlocationtextBox2);
        Controls.Add(projnametextBox);
        Controls.Add(deptid);
        Controls.Add(projlocation);
        Controls.Add(projname);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label projid;
    private System.Windows.Forms.TextBox projidtextBox1;

    private System.Windows.Forms.Button insert;

    private System.Windows.Forms.TextBox projnametextBox;
    private System.Windows.Forms.TextBox projlocationtextBox2;
    private System.Windows.Forms.TextBox deptidtextBox3;

    private System.Windows.Forms.Label projname;
    private System.Windows.Forms.Label projlocation;
    private System.Windows.Forms.Label deptid;

    #endregion
}