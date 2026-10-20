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
            btnDelete = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalRecords).BeginInit();
            grpAnimalDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAnimalRecords
            // 
            dgvAnimalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalRecords.Location = new System.Drawing.Point(57, 19);
            dgvAnimalRecords.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            dgvAnimalRecords.Name = "dgvAnimalRecords";
            dgvAnimalRecords.RowHeadersWidth = 51;
            dgvAnimalRecords.Size = new System.Drawing.Size(951, 449);
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
            grpAnimalDetails.Location = new System.Drawing.Point(57, 484);
            grpAnimalDetails.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            grpAnimalDetails.Name = "grpAnimalDetails";
            grpAnimalDetails.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            grpAnimalDetails.Size = new System.Drawing.Size(951, 177);
            grpAnimalDetails.TabIndex = 1;
            grpAnimalDetails.TabStop = false;
            grpAnimalDetails.Text = "Animal Details";
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new System.Drawing.Point(21, 33);
            lblAnimalId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new System.Drawing.Size(180, 20);
            lblAnimalId.TabIndex = 0;
            lblAnimalId.Text = "Animal ID (e.g. WR-0007):";
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new System.Drawing.Point(21, 59);
            txtAnimalId.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.Size = new System.Drawing.Size(278, 27);
            txtAnimalId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(334, 33);
            lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(52, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(334, 59);
            txtName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(278, 27);
            txtName.TabIndex = 3;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(647, 33);
            lblSpecies.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(62, 20);
            lblSpecies.TabIndex = 4;
            lblSpecies.Text = "Species:";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new System.Drawing.Point(647, 59);
            txtSpecies.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new System.Drawing.Size(278, 27);
            txtSpecies.TabIndex = 5;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new System.Drawing.Point(21, 101);
            lblAge.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(132, 20);
            lblAge.TabIndex = 6;
            lblAge.Text = "Age (years, 0-100):";
            // 
            // txtAge
            // 
            txtAge.Location = new System.Drawing.Point(21, 127);
            txtAge.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new System.Drawing.Size(278, 27);
            txtAge.TabIndex = 7;
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new System.Drawing.Point(334, 101);
            lblRecoveryScore.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new System.Drawing.Size(165, 20);
            lblRecoveryScore.TabIndex = 8;
            lblRecoveryScore.Text = "Recovery Score (0-100):";
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.Location = new System.Drawing.Point(334, 127);
            txtRecoveryScore.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new System.Drawing.Size(278, 27);
            txtRecoveryScore.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(647, 123);
            btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(280, 37);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new System.Drawing.Point(69, 739);
            txtSearchId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new System.Drawing.Size(109, 27);
            txtSearchId.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(213, 732);
            btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(104, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new System.Drawing.Point(69, 791);
            btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new System.Drawing.Size(104, 40);
            btnSaveChanges.TabIndex = 4;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(213, 791);
            btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(104, 40);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(64, 688);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 20);
            label1.TabIndex = 6;
            label1.Text = "Search Animal ID:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(357, 791);
            btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(126, 40);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete Animal";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(882, 791);
            btnExit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(126, 40);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1077, 847);
            Controls.Add(btnExit);
            Controls.Add(btnDelete);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchId);
            Controls.Add(grpAnimalDetails);
            Controls.Add(dgvAnimalRecords);
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
    }
}

