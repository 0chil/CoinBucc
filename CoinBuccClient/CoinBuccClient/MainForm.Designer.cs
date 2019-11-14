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
            this.flatClose1 = new FlatUI.FlatClose();
            this.btnLogin = new FlatUI.FlatButton();
            this.txtPW = new FlatUI.FlatTextBox();
            this.txtId = new FlatUI.FlatTextBox();
            this.alertBox = new FlatUI.FlatAlertBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
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
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(285, 194);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "CoinBuccClient";
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(255, 13);
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
            this.btnLogin.Location = new System.Drawing.Point(187, 66);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Rounded = false;
            this.btnLogin.Size = new System.Drawing.Size(84, 64);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtPW
            // 
            this.txtPW.BackColor = System.Drawing.Color.Transparent;
            this.txtPW.FocusOnHover = true;
            this.txtPW.Location = new System.Drawing.Point(12, 101);
            this.txtPW.MaxLength = 32767;
            this.txtPW.Multiline = false;
            this.txtPW.Name = "txtPW";
            this.txtPW.ReadOnly = false;
            this.txtPW.Size = new System.Drawing.Size(168, 29);
            this.txtPW.TabIndex = 1;
            this.txtPW.Tag = "";
            this.txtPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPW.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.FocusOnHover = true;
            this.txtId.Location = new System.Drawing.Point(12, 66);
            this.txtId.MaxLength = 32767;
            this.txtId.Multiline = false;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = false;
            this.txtId.Size = new System.Drawing.Size(168, 29);
            this.txtId.TabIndex = 0;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtId.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtId.UseSystemPasswordChar = false;
            // 
            // alertBox
            // 
            this.alertBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.alertBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alertBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.alertBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.alertBox.Location = new System.Drawing.Point(12, 136);
            this.alertBox.Name = "alertBox";
            this.alertBox.Size = new System.Drawing.Size(259, 42);
            this.alertBox.TabIndex = 4;
            this.alertBox.Text = "flatAlertBox1";
            this.alertBox.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 194);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}

