namespace AutoKiller_Script
{
    partial class Shell
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TargetUINS_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ICQPassword_textBox = new System.Windows.Forms.TextBox();
            this.ICQUIN_textBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BuffConsecrate_button = new System.Windows.Forms.Button();
            this.BuffCancelAllbutton = new System.Windows.Forms.Button();
            this.BuffDivineFury_button = new System.Windows.Forms.Button();
            this.BuffEnemyOfOne_button = new System.Windows.Forms.Button();
            this.Buffs_comboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LootDataString_textBox = new System.Windows.Forms.TextBox();
            this.UseBandages_checkBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start the script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(285, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 85);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop the script";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TargetUINS_textBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ICQPassword_textBox);
            this.panel1.Controls.Add(this.ICQUIN_textBox);
            this.panel1.Location = new System.Drawing.Point(4, 246);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 184);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Leave empty to disable icq connect";
            // 
            // TargetUINS_textBox
            // 
            this.TargetUINS_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetUINS_textBox.Location = new System.Drawing.Point(4, 150);
            this.TargetUINS_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetUINS_textBox.Name = "TargetUINS_textBox";
            this.TargetUINS_textBox.Size = new System.Drawing.Size(538, 26);
            this.TargetUINS_textBox.TabIndex = 3;
            this.TargetUINS_textBox.Text = "2222222222,333333333333";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ICQ login data";
            // 
            // ICQPassword_textBox
            // 
            this.ICQPassword_textBox.Location = new System.Drawing.Point(4, 114);
            this.ICQPassword_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ICQPassword_textBox.Name = "ICQPassword_textBox";
            this.ICQPassword_textBox.PasswordChar = '*';
            this.ICQPassword_textBox.Size = new System.Drawing.Size(235, 26);
            this.ICQPassword_textBox.TabIndex = 1;
            this.ICQPassword_textBox.Text = "0000000";
            // 
            // ICQUIN_textBox
            // 
            this.ICQUIN_textBox.Location = new System.Drawing.Point(4, 74);
            this.ICQUIN_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ICQUIN_textBox.Name = "ICQUIN_textBox";
            this.ICQUIN_textBox.Size = new System.Drawing.Size(235, 26);
            this.ICQUIN_textBox.TabIndex = 0;
            this.ICQUIN_textBox.Text = "UIN";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BuffConsecrate_button);
            this.panel2.Controls.Add(this.BuffCancelAllbutton);
            this.panel2.Controls.Add(this.BuffDivineFury_button);
            this.panel2.Controls.Add(this.BuffEnemyOfOne_button);
            this.panel2.Controls.Add(this.Buffs_comboBox);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(4, 181);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 55);
            this.panel2.TabIndex = 3;
            // 
            // BuffConsecrate_button
            // 
            this.BuffConsecrate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuffConsecrate_button.Location = new System.Drawing.Point(156, 5);
            this.BuffConsecrate_button.Name = "BuffConsecrate_button";
            this.BuffConsecrate_button.Size = new System.Drawing.Size(70, 40);
            this.BuffConsecrate_button.TabIndex = 4;
            this.BuffConsecrate_button.Text = "Consecrate Weapon";
            this.BuffConsecrate_button.UseVisualStyleBackColor = true;
            this.BuffConsecrate_button.Click += new System.EventHandler(this.BuffDivineFury_button_Click);
            // 
            // BuffCancelAllbutton
            // 
            this.BuffCancelAllbutton.Location = new System.Drawing.Point(466, 5);
            this.BuffCancelAllbutton.Name = "BuffCancelAllbutton";
            this.BuffCancelAllbutton.Size = new System.Drawing.Size(70, 40);
            this.BuffCancelAllbutton.TabIndex = 3;
            this.BuffCancelAllbutton.Text = "Cancell All";
            this.BuffCancelAllbutton.UseVisualStyleBackColor = true;
            this.BuffCancelAllbutton.Click += new System.EventHandler(this.BuffCancelAllbutton_Click);
            // 
            // BuffDivineFury_button
            // 
            this.BuffDivineFury_button.Location = new System.Drawing.Point(80, 5);
            this.BuffDivineFury_button.Name = "BuffDivineFury_button";
            this.BuffDivineFury_button.Size = new System.Drawing.Size(70, 40);
            this.BuffDivineFury_button.TabIndex = 2;
            this.BuffDivineFury_button.Text = "Divine Fury";
            this.BuffDivineFury_button.UseVisualStyleBackColor = true;
            this.BuffDivineFury_button.Click += new System.EventHandler(this.BuffDivineFury_button_Click);
            // 
            // BuffEnemyOfOne_button
            // 
            this.BuffEnemyOfOne_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuffEnemyOfOne_button.Location = new System.Drawing.Point(4, 5);
            this.BuffEnemyOfOne_button.Name = "BuffEnemyOfOne_button";
            this.BuffEnemyOfOne_button.Size = new System.Drawing.Size(70, 40);
            this.BuffEnemyOfOne_button.TabIndex = 1;
            this.BuffEnemyOfOne_button.Text = "Enemy of One";
            this.BuffEnemyOfOne_button.UseVisualStyleBackColor = true;
            this.BuffEnemyOfOne_button.Click += new System.EventHandler(this.BuffDivineFury_button_Click);
            // 
            // Buffs_comboBox
            // 
            this.Buffs_comboBox.FormattingEnabled = true;
            this.Buffs_comboBox.Location = new System.Drawing.Point(174, 33);
            this.Buffs_comboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Buffs_comboBox.Name = "Buffs_comboBox";
            this.Buffs_comboBox.Size = new System.Drawing.Size(229, 21);
            this.Buffs_comboBox.TabIndex = 0;
            this.Buffs_comboBox.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.LootDataString_textBox);
            this.panel3.Location = new System.Drawing.Point(4, 440);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 97);
            this.panel3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Looting. Use \';\' as delimiter";
            // 
            // LootDataString_textBox
            // 
            this.LootDataString_textBox.Location = new System.Drawing.Point(4, 50);
            this.LootDataString_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LootDataString_textBox.Name = "LootDataString_textBox";
            this.LootDataString_textBox.Size = new System.Drawing.Size(538, 26);
            this.LootDataString_textBox.TabIndex = 1;
            this.LootDataString_textBox.Text = "0x108A;   0xEED; greater magic item; ring; slayer";
            // 
            // UseBandages_checkBox
            // 
            this.UseBandages_checkBox.AutoSize = true;
            this.UseBandages_checkBox.Location = new System.Drawing.Point(40, 121);
            this.UseBandages_checkBox.Name = "UseBandages_checkBox";
            this.UseBandages_checkBox.Size = new System.Drawing.Size(134, 24);
            this.UseBandages_checkBox.TabIndex = 5;
            this.UseBandages_checkBox.Text = "Use Bandages";
            this.UseBandages_checkBox.UseVisualStyleBackColor = true;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UseBandages_checkBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Shell";
            this.Size = new System.Drawing.Size(558, 542);
            this.Load += new System.EventHandler(this.Shell_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ICQPassword_textBox;
        private System.Windows.Forms.TextBox ICQUIN_textBox;
        private System.Windows.Forms.TextBox TargetUINS_textBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox Buffs_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LootDataString_textBox;
        private System.Windows.Forms.Button BuffCancelAllbutton;
        private System.Windows.Forms.Button BuffDivineFury_button;
        private System.Windows.Forms.Button BuffEnemyOfOne_button;
        private System.Windows.Forms.Button BuffConsecrate_button;
        private System.Windows.Forms.CheckBox UseBandages_checkBox;
    }
}
