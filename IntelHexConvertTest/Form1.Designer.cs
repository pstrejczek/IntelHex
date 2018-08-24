namespace IntelHexConvertTest
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eSource = new System.Windows.Forms.TextBox();
            this.eDestination = new System.Windows.Forms.TextBox();
            this.bSourceMore = new System.Windows.Forms.Button();
            this.bDestinationMore = new System.Windows.Forms.Button();
            this.bConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source bitmap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination (txt):";
            // 
            // eSource
            // 
            this.eSource.Location = new System.Drawing.Point(101, 18);
            this.eSource.Name = "eSource";
            this.eSource.Size = new System.Drawing.Size(263, 20);
            this.eSource.TabIndex = 2;
            // 
            // eDestination
            // 
            this.eDestination.Location = new System.Drawing.Point(101, 49);
            this.eDestination.Name = "eDestination";
            this.eDestination.Size = new System.Drawing.Size(263, 20);
            this.eDestination.TabIndex = 3;
            // 
            // bSourceMore
            // 
            this.bSourceMore.Location = new System.Drawing.Point(370, 16);
            this.bSourceMore.Name = "bSourceMore";
            this.bSourceMore.Size = new System.Drawing.Size(75, 23);
            this.bSourceMore.TabIndex = 4;
            this.bSourceMore.Text = "More...";
            this.bSourceMore.UseVisualStyleBackColor = true;
            this.bSourceMore.Click += new System.EventHandler(this.bSourceMore_Click);
            // 
            // bDestinationMore
            // 
            this.bDestinationMore.Location = new System.Drawing.Point(370, 47);
            this.bDestinationMore.Name = "bDestinationMore";
            this.bDestinationMore.Size = new System.Drawing.Size(75, 23);
            this.bDestinationMore.TabIndex = 5;
            this.bDestinationMore.Text = "More...";
            this.bDestinationMore.UseVisualStyleBackColor = true;
            this.bDestinationMore.Click += new System.EventHandler(this.bDestinationMore_Click);
            // 
            // bConvert
            // 
            this.bConvert.Location = new System.Drawing.Point(101, 84);
            this.bConvert.Name = "bConvert";
            this.bConvert.Size = new System.Drawing.Size(263, 23);
            this.bConvert.TabIndex = 6;
            this.bConvert.Text = "CONVERT";
            this.bConvert.UseVisualStyleBackColor = true;
            this.bConvert.Click += new System.EventHandler(this.bConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 115);
            this.Controls.Add(this.bConvert);
            this.Controls.Add(this.bDestinationMore);
            this.Controls.Add(this.bSourceMore);
            this.Controls.Add(this.eDestination);
            this.Controls.Add(this.eSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eSource;
        private System.Windows.Forms.TextBox eDestination;
        private System.Windows.Forms.Button bSourceMore;
        private System.Windows.Forms.Button bDestinationMore;
        private System.Windows.Forms.Button bConvert;
    }
}

