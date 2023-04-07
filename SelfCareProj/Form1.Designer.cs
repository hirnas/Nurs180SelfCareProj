namespace SelfCareProj
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameOutputScreen = new System.Windows.Forms.TextBox();
            this.UserInputBox = new System.Windows.Forms.TextBox();
            this.StressBar = new System.Windows.Forms.ProgressBar();
            this.StressBarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameOutputScreen
            // 
            this.GameOutputScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameOutputScreen.BackColor = System.Drawing.SystemColors.InfoText;
            this.GameOutputScreen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GameOutputScreen.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GameOutputScreen.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameOutputScreen.ForeColor = System.Drawing.SystemColors.Control;
            this.GameOutputScreen.Location = new System.Drawing.Point(150, 180);
            this.GameOutputScreen.Multiline = true;
            this.GameOutputScreen.Name = "GameOutputScreen";
            this.GameOutputScreen.ReadOnly = true;
            this.GameOutputScreen.Size = new System.Drawing.Size(850, 400);
            this.GameOutputScreen.TabIndex = 0;
            this.GameOutputScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GameOutputScreen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UserInputBox
            // 
            this.UserInputBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.UserInputBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.UserInputBox.ForeColor = System.Drawing.SystemColors.Control;
            this.UserInputBox.Location = new System.Drawing.Point(150, 580);
            this.UserInputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserInputBox.Name = "UserInputBox";
            this.UserInputBox.Size = new System.Drawing.Size(855, 31);
            this.UserInputBox.TabIndex = 1;
            // 
            // StressBar
            // 
            this.StressBar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StressBar.Location = new System.Drawing.Point(211, 57);
            this.StressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StressBar.MarqueeAnimationSpeed = 0;
            this.StressBar.Name = "StressBar";
            this.StressBar.Size = new System.Drawing.Size(146, 18);
            this.StressBar.Step = 5;
            this.StressBar.TabIndex = 3;
            this.StressBar.Value = 30;
            this.StressBar.Click += new System.EventHandler(this.StressBar_Click);
            // 
            // StressBarLabel
            // 
            this.StressBarLabel.AutoSize = true;
            this.StressBarLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StressBarLabel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StressBarLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.StressBarLabel.Location = new System.Drawing.Point(143, 50);
            this.StressBarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StressBarLabel.Name = "StressBarLabel";
            this.StressBarLabel.Size = new System.Drawing.Size(60, 23);
            this.StressBarLabel.TabIndex = 4;
            this.StressBarLabel.Text = "Stress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1120, 768);
            this.Controls.Add(this.StressBarLabel);
            this.Controls.Add(this.StressBar);
            this.Controls.Add(this.UserInputBox);
            this.Controls.Add(this.GameOutputScreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox GameOutputScreen;
        private TextBox UserInputBox;
        private ProgressBar StressBar;
        private Label StressBarLabel;
    }
}