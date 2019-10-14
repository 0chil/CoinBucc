namespace CoinBuccClient
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.formSkin1 = new FlatUI.FormSkin();
            this.alertBox = new FlatUI.FlatAlertBox();
            this.flatClose1 = new FlatUI.FlatClose();
            this.btnLogin = new FlatUI.FlatButton();
            this.txtPW = new FlatUI.FlatTextBox();
            this.txtId = new FlatUI.FlatTextBox();
            this.flatButton1 = new FlatUI.FlatButton();
            this.flatButton2 = new FlatUI.FlatButton();
            this.flatTextBox1 = new FlatUI.FlatTextBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatTextBox1);
            this.formSkin1.Controls.Add(this.flatButton2);
            this.formSkin1.Controls.Add(this.flatButton1);
            this.formSkin1.Controls.Add(this.alertBox);
            this.formSkin1.Controls.Add(this.flatClose1);
            this.formSkin1.Controls.Add(this.btnLogin);
            this.formSkin1.Controls.Add(this.txtPW);
            this.formSkin1.Controls.Add(this.txtId);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(326, 466);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "CoinBuccClient";
            // 
            // alertBox
            // 
            this.alertBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.alertBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alertBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.alertBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.alertBox.Location = new System.Drawing.Point(14, 170);
            this.alertBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alertBox.Name = "alertBox";
            this.alertBox.Size = new System.Drawing.Size(296, 42);
            this.alertBox.TabIndex = 4;
            this.alertBox.Text = "flatAlertBox1";
            this.alertBox.Visible = false;
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(291, 16);
            this.flatClose1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flatClose1.Name = "flatClose1";
            this.flatClose1.Size = new System.Drawing.Size(18, 18);
            this.flatClose1.TabIndex = 3;
            this.flatClose1.Text = "flatClose1";
            this.flatClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogin.Location = new System.Drawing.Point(214, 82);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Rounded = false;
            this.btnLogin.Size = new System.Drawing.Size(96, 80);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtPW
            // 
            this.txtPW.BackColor = System.Drawing.Color.Transparent;
            this.txtPW.FocusOnHover = false;
            this.txtPW.Location = new System.Drawing.Point(14, 126);
            this.txtPW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPW.MaxLength = 32767;
            this.txtPW.Multiline = false;
            this.txtPW.Name = "txtPW";
            this.txtPW.ReadOnly = false;
            this.txtPW.Size = new System.Drawing.Size(192, 34);
            this.txtPW.TabIndex = 1;
            this.txtPW.Tag = "";
            this.txtPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPW.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.FocusOnHover = false;
            this.txtId.Location = new System.Drawing.Point(14, 82);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtId.MaxLength = 32767;
            this.txtId.Multiline = false;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = false;
            this.txtId.Size = new System.Drawing.Size(192, 34);
            this.txtId.TabIndex = 0;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtId.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtId.UseSystemPasswordChar = false;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton1.Location = new System.Drawing.Point(14, 220);
            this.flatButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(295, 80);
            this.flatButton1.TabIndex = 5;
            this.flatButton1.Text = "Heartbeat POST TEST";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Transparent;
            this.flatButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton2.Location = new System.Drawing.Point(15, 308);
            this.flatButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Rounded = false;
            this.flatButton2.Size = new System.Drawing.Size(295, 80);
            this.flatButton2.TabIndex = 6;
            this.flatButton2.Text = "Jobdone GET TEST";
            this.flatButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // flatTextBox1
            // 
            this.flatTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatTextBox1.FocusOnHover = false;
            this.flatTextBox1.Location = new System.Drawing.Point(15, 396);
            this.flatTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flatTextBox1.MaxLength = 32767;
            this.flatTextBox1.Multiline = false;
            this.flatTextBox1.Name = "flatTextBox1";
            this.flatTextBox1.ReadOnly = false;
            this.flatTextBox1.Size = new System.Drawing.Size(294, 34);
            this.flatTextBox1.TabIndex = 7;
            this.flatTextBox1.Text = "http://localhost";
            this.flatTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.flatTextBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flatTextBox1.UseSystemPasswordChar = false;
            this.flatTextBox1.TextChanged += new System.EventHandler(this.flatTextBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 466);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoinBuccClient";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FormSkin formSkin1;
        private FlatUI.FlatClose flatClose1;
        private FlatUI.FlatButton btnLogin;
        private FlatUI.FlatTextBox txtPW;
        private FlatUI.FlatTextBox txtId;
        private FlatUI.FlatAlertBox alertBox;
        private FlatUI.FlatButton flatButton1;
        private FlatUI.FlatButton flatButton2;
        private FlatUI.FlatTextBox flatTextBox1;
    }
}

