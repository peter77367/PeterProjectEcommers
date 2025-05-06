namespace Presentation
{
    partial class LogIn
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtusername = new TextBox();
            txtuserpassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(298, 271);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(193, 52);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "LogIn";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // txtusername
            // 
            txtusername.Location = new Point(289, 110);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(299, 23);
            txtusername.TabIndex = 1;
            // 
            // txtuserpassword
            // 
            txtuserpassword.Location = new Point(289, 167);
            txtuserpassword.Name = "txtuserpassword";
            txtuserpassword.Size = new Size(299, 23);
            txtuserpassword.TabIndex = 2;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtuserpassword);
            Controls.Add(txtusername);
            Controls.Add(btnLogin);
            Name = "LogIn";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtusername;
        private TextBox txtuserpassword;
    }
}
