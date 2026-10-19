namespace BaobabRidgeRehabSystem
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
            this.dgvAnimalRecords = new System.Windows.Forms.DataGridView();
            this.grpAnimalDetails = new System.Windows.Forms.GroupBox();
            this.lblAnimalId = new System.Windows.Forms.Label();
            this.txtAnimalId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblRecoveryScore = new System.Windows.Forms.Label();
            this.txtRecoveryScore = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalRecords)).BeginInit();
            this.grpAnimalDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAnimalRecords
            // 
            this.dgvAnimalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimalRecords.Location = new System.Drawing.Point(43, 12);
            this.dgvAnimalRecords.Name = "dgvAnimalRecords";
            this.dgvAnimalRecords.Size = new System.Drawing.Size(713, 292);
            this.dgvAnimalRecords.TabIndex = 0;
            // 
            // grpAnimalDetails
            // 
            this.grpAnimalDetails.Controls.Add(this.lblAnimalId);
            this.grpAnimalDetails.Controls.Add(this.txtAnimalId);
            this.grpAnimalDetails.Controls.Add(this.lblName);
            this.grpAnimalDetails.Controls.Add(this.txtName);
            this.grpAnimalDetails.Controls.Add(this.lblSpecies);
            this.grpAnimalDetails.Controls.Add(this.txtSpecies);
            this.grpAnimalDetails.Controls.Add(this.lblAge);
            this.grpAnimalDetails.Controls.Add(this.txtAge);
            this.grpAnimalDetails.Controls.Add(this.lblRecoveryScore);
            this.grpAnimalDetails.Controls.Add(this.txtRecoveryScore);
            this.grpAnimalDetails.Controls.Add(this.btnAdd);
            this.grpAnimalDetails.Location = new System.Drawing.Point(43, 315);
            this.grpAnimalDetails.Name = "grpAnimalDetails";
            this.grpAnimalDetails.Size = new System.Drawing.Size(713, 115);
            this.grpAnimalDetails.TabIndex = 1;
            this.grpAnimalDetails.TabStop = false;
            this.grpAnimalDetails.Text = "Animal Details";
            // 
            // lblAnimalId
            // 
            this.lblAnimalId.AutoSize = true;
            this.lblAnimalId.Location = new System.Drawing.Point(15, 22);
            this.lblAnimalId.Name = "lblAnimalId";
            this.lblAnimalId.TabIndex = 0;
            this.lblAnimalId.Text = "Animal ID (e.g. WR-0007):";
            // 
            // txtAnimalId
            // 
            this.txtAnimalId.Location = new System.Drawing.Point(15, 38);
            this.txtAnimalId.Name = "txtAnimalId";
            this.txtAnimalId.Size = new System.Drawing.Size(210, 20);
            this.txtAnimalId.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(250, 22);
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(250, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblSpecies
            // 
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Location = new System.Drawing.Point(485, 22);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.TabIndex = 4;
            this.lblSpecies.Text = "Species:";
            // 
            // txtSpecies
            // 
            this.txtSpecies.Location = new System.Drawing.Point(485, 38);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(210, 20);
            this.txtSpecies.TabIndex = 5;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(15, 66);
            this.lblAge.Name = "lblAge";
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Age (years, 0-100):";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(15, 82);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(210, 20);
            this.txtAge.TabIndex = 7;
            // 
            // lblRecoveryScore
            // 
            this.lblRecoveryScore.AutoSize = true;
            this.lblRecoveryScore.Location = new System.Drawing.Point(250, 66);
            this.lblRecoveryScore.Name = "lblRecoveryScore";
            this.lblRecoveryScore.TabIndex = 8;
            this.lblRecoveryScore.Text = "Recovery Score (0-100):";
            // 
            // txtRecoveryScore
            // 
            this.txtRecoveryScore.Location = new System.Drawing.Point(250, 82);
            this.txtRecoveryScore.Name = "txtRecoveryScore";
            this.txtRecoveryScore.Size = new System.Drawing.Size(210, 20);
            this.txtRecoveryScore.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(485, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 24);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Animal";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpAnimalDetails);
            this.Controls.Add(this.dgvAnimalRecords);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalRecords)).EndInit();
            this.grpAnimalDetails.ResumeLayout(false);
            this.grpAnimalDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnimalRecords;
        private System.Windows.Forms.GroupBox grpAnimalDetails;
        private System.Windows.Forms.Label lblAnimalId;
        private System.Windows.Forms.TextBox txtAnimalId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblRecoveryScore;
        private System.Windows.Forms.TextBox txtRecoveryScore;
        private System.Windows.Forms.Button btnAdd;
    }
}

