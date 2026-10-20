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
            dgvAnimalRecords = new System.Windows.Forms.DataGridView();
            grpAnimalDetails = new System.Windows.Forms.GroupBox();
            lblAnimalId = new System.Windows.Forms.Label();
            txtAnimalId = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblSpecies = new System.Windows.Forms.Label();
            txtSpecies = new System.Windows.Forms.TextBox();
            lblAge = new System.Windows.Forms.Label();
            txtAge = new System.Windows.Forms.TextBox();
            lblRecoveryScore = new System.Windows.Forms.Label();
            txtRecoveryScore = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            txtSearchId = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            btnSaveChanges = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalRecords).BeginInit();
            grpAnimalDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAnimalRecords
            // 
            dgvAnimalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalRecords.Location = new System.Drawing.Point(50, 14);
            dgvAnimalRecords.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvAnimalRecords.Name = "dgvAnimalRecords";
            dgvAnimalRecords.Size = new System.Drawing.Size(832, 337);
            dgvAnimalRecords.TabIndex = 0;
            // 
            // grpAnimalDetails
            // 
            grpAnimalDetails.Controls.Add(lblAnimalId);
            grpAnimalDetails.Controls.Add(txtAnimalId);
            grpAnimalDetails.Controls.Add(lblName);
            grpAnimalDetails.Controls.Add(txtName);
            grpAnimalDetails.Controls.Add(lblSpecies);
            grpAnimalDetails.Controls.Add(txtSpecies);
            grpAnimalDetails.Controls.Add(lblAge);
            grpAnimalDetails.Controls.Add(txtAge);
            grpAnimalDetails.Controls.Add(lblRecoveryScore);
            grpAnimalDetails.Controls.Add(txtRecoveryScore);
            grpAnimalDetails.Controls.Add(btnAdd);
            grpAnimalDetails.Location = new System.Drawing.Point(50, 363);
            grpAnimalDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAnimalDetails.Name = "grpAnimalDetails";
            grpAnimalDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAnimalDetails.Size = new System.Drawing.Size(832, 133);
            grpAnimalDetails.TabIndex = 1;
            grpAnimalDetails.TabStop = false;
            grpAnimalDetails.Text = "Animal Details";
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new System.Drawing.Point(18, 25);
            lblAnimalId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new System.Drawing.Size(142, 15);
            lblAnimalId.TabIndex = 0;
            lblAnimalId.Text = "Animal ID (e.g. WR-0007):";
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new System.Drawing.Point(18, 44);
            txtAnimalId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.Size = new System.Drawing.Size(244, 23);
            txtAnimalId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(292, 25);
            lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(42, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(292, 44);
            txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(244, 23);
            txtName.TabIndex = 3;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(566, 25);
            lblSpecies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(49, 15);
            lblSpecies.TabIndex = 4;
            lblSpecies.Text = "Species:";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new System.Drawing.Point(566, 44);
            txtSpecies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new System.Drawing.Size(244, 23);
            txtSpecies.TabIndex = 5;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new System.Drawing.Point(18, 76);
            lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(104, 15);
            lblAge.TabIndex = 6;
            lblAge.Text = "Age (years, 0-100):";
            // 
            // txtAge
            // 
            txtAge.Location = new System.Drawing.Point(18, 95);
            txtAge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAge.Name = "txtAge";
            txtAge.Size = new System.Drawing.Size(244, 23);
            txtAge.TabIndex = 7;
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new System.Drawing.Point(292, 76);
            lblRecoveryScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new System.Drawing.Size(130, 15);
            lblRecoveryScore.TabIndex = 8;
            lblRecoveryScore.Text = "Recovery Score (0-100):";
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.Location = new System.Drawing.Point(292, 95);
            txtRecoveryScore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new System.Drawing.Size(244, 23);
            txtRecoveryScore.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(566, 92);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(245, 28);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new System.Drawing.Point(60, 554);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new System.Drawing.Size(96, 23);
            txtSearchId.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(186, 549);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(91, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new System.Drawing.Point(60, 593);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new System.Drawing.Size(91, 30);
            btnSaveChanges.TabIndex = 4;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(186, 593);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(91, 30);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(56, 516);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 6;
            label1.Text = "Search Animal ID:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(595, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 24);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Animal";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(942, 635);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchId);
            Controls.Add(grpAnimalDetails);
            Controls.Add(dgvAnimalRecords);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimalRecords).EndInit();
            grpAnimalDetails.ResumeLayout(false);
            grpAnimalDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
    }
}

