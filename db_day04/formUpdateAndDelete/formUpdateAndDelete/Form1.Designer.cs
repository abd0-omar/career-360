namespace formUpdateAndDelete;

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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        comboBox1 = new System.Windows.Forms.ComboBox();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        textBox4 = new System.Windows.Forms.TextBox();
        result = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        delete = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(38, 53);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(31, 135);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 1;
        label2.Text = "label2";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(31, 197);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(100, 23);
        label3.TabIndex = 2;
        label3.Text = "label3";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(31, 252);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(100, 23);
        label4.TabIndex = 3;
        label4.Text = "label4";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(31, 303);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(100, 23);
        label5.TabIndex = 4;
        label5.Text = "label5";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(159, 50);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(208, 33);
        comboBox1.TabIndex = 5;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(223, 127);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(231, 31);
        textBox1.TabIndex = 6;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(223, 189);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(231, 31);
        textBox2.TabIndex = 7;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(223, 252);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(231, 31);
        textBox3.TabIndex = 8;
        // 
        // textBox4
        // 
        textBox4.Location = new System.Drawing.Point(223, 300);
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(231, 31);
        textBox4.TabIndex = 9;
        // 
        // result
        // 
        result.Location = new System.Drawing.Point(289, 369);
        result.Name = "result";
        result.Size = new System.Drawing.Size(100, 23);
        result.TabIndex = 10;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(494, 212);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(117, 49);
        button1.TabIndex = 11;
        button1.Text = "update";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // delete
        // 
        delete.BackColor = System.Drawing.Color.Crimson;
        delete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        delete.Location = new System.Drawing.Point(494, 300);
        delete.Name = "delete";
        delete.Size = new System.Drawing.Size(130, 60);
        delete.TabIndex = 12;
        delete.Text = "delete";
        delete.UseVisualStyleBackColor = false;
        delete.Click += delete_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(delete);
        Controls.Add(button1);
        Controls.Add(result);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(comboBox1);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button delete;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label result;

    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBox1;

    #endregion
}