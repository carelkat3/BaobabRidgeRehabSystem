using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BaobabRidgeRehabSystem
{
    // Feature 5 - Generate a summary report.
    // The summary controls are created in code instead of in Form1.Designer.cs. Every other feature
    // edits the designer file, so keeping this feature out of it avoids merge conflicts on GitHub.
    public partial class Form1
    {
        private GroupBox grpSummary;
        private TableLayoutPanel tblSummary;
        private Button btnGenerateSummary;
        private Button btnOpenSummaryFile;
        private Label lblSummaryGenerated;
        private Label lblSummaryTotal;
        private Label lblSummaryAverageAge;
        private Label lblSummaryAverageScore;

        // One value label per status, so the five counts can be filled in with a loop.
        private readonly Dictionary<string, Label> summaryStatusLabels = new Dictionary<string, Label>();

        // summary.txt is created in the same folder as the running .exe (Section 5.2).
        private static readonly string SummaryFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "summary.txt");

        // Builds the "Summary Report" group box to the right of the grid. It is positioned from the
        // grid's real size (not fixed pixels) because Windows may scale the designer controls for
        // the screen's font size and DPI before this runs.
        private void BuildSummaryPanel()
        {
            SuspendLayout();

            btnGenerateSummary = new Button
            {
                Name = "btnGenerateSummary",
                Text = "Generate Summary",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                UseVisualStyleBackColor = true
            };
            btnGenerateSummary.Click += btnGenerateSummary_Click;

            btnOpenSummaryFile = new Button
            {
                Name = "btnOpenSummaryFile",
                Text = "Open summary.txt",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                UseVisualStyleBackColor = true
            };
            btnOpenSummaryFile.Click += btnOpenSummaryFile_Click;

            lblSummaryGenerated = new Label
            {
                Name = "lblSummaryGenerated",
                Text = "Not generated yet.",
                AutoSize = true,
                Margin = new Padding(3, 6, 3, 6)
            };

            tblSummary = new TableLayoutPanel
            {
                Name = "tblSummary",
                ColumnCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tblSummary.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            // The buttons and the timestamp span both columns.
            AddFullWidthRow(btnGenerateSummary);
            AddFullWidthRow(lblSummaryGenerated);

            lblSummaryTotal = AddSummaryRow("Total animals:", "lblSummaryTotal");
            lblSummaryAverageAge = AddSummaryRow("Average age (years):", "lblSummaryAverageAge");
            lblSummaryAverageScore = AddSummaryRow("Average recovery score:", "lblSummaryAverageScore");

            AddFullWidthRow(new Label { Text = "Animals per status:", AutoSize = true, Margin = new Padding(3, 12, 3, 3) });
            foreach (string status in AnimalClassifier.AllStatuses)
            {
                // "Release-Ready" becomes lblSummaryReleaseReady (a hyphen is not allowed in a name).
                summaryStatusLabels[status] = AddSummaryRow("    " + status + ":", "lblSummary" + status.Replace("-", ""));
            }

            AddFullWidthRow(btnOpenSummaryFile);

            grpSummary = new GroupBox
            {
                Name = "grpSummary",
                Text = "Summary Report",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = new Point(dgvAnimalRecords.Right + 12, dgvAnimalRecords.Top - 6),
                // Make the box at least as tall as the grid plus the Animal Details box beside it.
                MinimumSize = new Size(0, grpAnimalDetails.Bottom - dgvAnimalRecords.Top + 6)
            };
            tblSummary.Location = grpSummary.DisplayRectangle.Location;
            grpSummary.Controls.Add(tblSummary);
            Controls.Add(grpSummary);

            ResumeLayout(true);

            // Grow the window (never shrink it) so the new panel fits beside the grid.
            ClientSize = new Size(
                Math.Max(ClientSize.Width, grpSummary.Right + dgvAnimalRecords.Left),
                Math.Max(ClientSize.Height, grpSummary.Bottom + 12));
        }

        // Adds a row with a caption on the left and an empty value label on the right,
        // and returns the value label so it can be filled in later.
        private Label AddSummaryRow(string caption, string valueLabelName)
        {
            Label valueLabel = new Label
            {
                Name = valueLabelName,
                Text = "-",
                AutoSize = true,
                Font = new Font(Font, FontStyle.Bold),
                Margin = new Padding(12, 3, 3, 3)
            };

            int row = tblSummary.RowCount;
            tblSummary.RowCount = row + 1;
            tblSummary.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblSummary.Controls.Add(new Label { Text = caption, AutoSize = true }, 0, row);
            tblSummary.Controls.Add(valueLabel, 1, row);
            return valueLabel;
        }

        // Adds a control that stretches across both columns of the summary table.
        private void AddFullWidthRow(Control control)
        {
            int row = tblSummary.RowCount;
            tblSummary.RowCount = row + 1;
            tblSummary.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblSummary.Controls.Add(control, 0, row);
            tblSummary.SetColumnSpan(control, 2);
        }

        // Runs when the user clicks Generate Summary: reads animals.txt, shows the figures on the
        // form and overwrites summary.txt. File problems show a friendly message, never a crash.
        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            List<Animal> animals;

            try
            {
                // Read the file again (not the grid) so the report matches what is in animals.txt now.
                animals = DataHandler.GetAnimals();
            }
            catch (UnauthorizedAccessException)
            {
                ShowFileError("The program does not have permission to read animals.txt. The summary was not generated.");
                return;
            }
            catch (IOException)
            {
                ShowFileError("animals.txt could not be read. It may be open in another program. " +
                              "Close it and try again. The summary was not generated.");
                return;
            }
            catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
            {
                // Thrown if a line in animals.txt is not in the ID|Name|Species|Age|Score|Status|Housing format.
                ShowFileError("animals.txt contains a line that is not in the expected format, so the summary could not be calculated.");
                return;
            }

            SummaryReport report = SummaryReport.Calculate(animals, DateTime.Now);

            // Show the figures first, so the user still sees them even if saving the file fails.
            ShowSummaryOnForm(report);

            try
            {
                report.SaveToFile(SummaryFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                ShowFileError("The summary is shown on the form, but summary.txt could not be saved because " +
                              "the program does not have permission. Check that summary.txt is not read-only.");
                return;
            }
            catch (IOException)
            {
                ShowFileError("The summary is shown on the form, but summary.txt could not be saved. " +
                              "It may be open in another program. Close it and try again.");
                return;
            }

            MessageBox.Show("The summary was saved to:" + Environment.NewLine + SummaryFilePath,
                "Summary Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Copies the calculated figures into the labels on the form.
        private void ShowSummaryOnForm(SummaryReport report)
        {
            lblSummaryGenerated.Text = "Generated: " + report.FormatGeneratedAt();
            lblSummaryTotal.Text = report.TotalAnimals.ToString();
            lblSummaryAverageAge.Text = SummaryReport.FormatAverage(report.AverageAge);
            lblSummaryAverageScore.Text = SummaryReport.FormatAverage(report.AverageRecoveryScore);

            foreach (string status in AnimalClassifier.AllStatuses)
            {
                summaryStatusLabels[status].Text = report.StatusCounts[status].ToString();
            }
        }

        // Opens summary.txt in the default text editor (useful for checking the saved report).
        private void btnOpenSummaryFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SummaryFilePath))
            {
                MessageBox.Show("summary.txt has not been created yet. Click Generate Summary first.",
                    "No Summary Yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // UseShellExecute opens the file with whichever program Windows uses for .txt files.
                Process.Start(new ProcessStartInfo(SummaryFilePath) { UseShellExecute = true });
            }
            catch (Exception)
            {
                ShowFileError("summary.txt could not be opened. You can find it at:" + Environment.NewLine + SummaryFilePath);
            }
        }
    }
}
