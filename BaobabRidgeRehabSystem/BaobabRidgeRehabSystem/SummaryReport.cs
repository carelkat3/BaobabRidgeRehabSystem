using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BaobabRidgeRehabSystem
{
    // Feature 5: works out the summary figures (Section 6, Feature 5) and builds the text of
    // summary.txt in the exact layout from Section 5.2. File exceptions are not caught here:
    // the form catches them and shows a friendly message.
    internal class SummaryReport
    {
        // Labels are padded to this width so every value starts in the same column.
        private const int ValueColumn = 26;
        private const string Divider = "----------------------------------------"; // 40 dashes
        private const string NotAvailable = "N/A";

        // UTF-8 without a byte-order mark, the same encoding used for animals.txt.
        private static readonly Encoding FileEncoding = new UTF8Encoding(false);

        public DateTime GeneratedAt { get; private set; }
        public int TotalAnimals { get; private set; }

        // Null when there are no animals, so the report shows N/A instead of dividing by zero.
        public decimal? AverageAge { get; private set; }
        public decimal? AverageRecoveryScore { get; private set; }

        // Number of animals per status, keyed by the status name.
        public Dictionary<string, int> StatusCounts { get; private set; }

        // Calculates totals, averages and per-status counts for the given animals.
        public static SummaryReport Calculate(List<Animal> animals, DateTime generatedAt)
        {
            SummaryReport report = new SummaryReport();
            report.GeneratedAt = generatedAt;
            report.TotalAnimals = animals.Count;
            report.StatusCounts = new Dictionary<string, int>();

            // Every status starts at 0 so all five are always listed (Section 5.2).
            foreach (string status in AnimalClassifier.AllStatuses)
            {
                report.StatusCounts[status] = 0;
            }

            int totalAge = 0;
            int totalScore = 0;

            foreach (Animal animal in animals)
            {
                totalAge += animal.Age;
                totalScore += animal.RecoveryScore;

                if (animal.Status != null && report.StatusCounts.ContainsKey(animal.Status))
                {
                    report.StatusCounts[animal.Status]++;
                }
            }

            if (animals.Count > 0)
            {
                // decimal (not double) gives exact results such as 7.75, so rounding is predictable.
                report.AverageAge = (decimal)totalAge / animals.Count;
                report.AverageRecoveryScore = (decimal)totalScore / animals.Count;
            }

            return report;
        }

        // Formats an average to two decimal places with a full stop, whatever the PC's regional
        // settings are (a South African PC would otherwise show a comma), or N/A if there is none.
        public static string FormatAverage(decimal? average)
        {
            if (!average.HasValue)
            {
                return NotAvailable;
            }
            return average.Value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        // Returns the timestamp in the required yyyy-MM-dd HH:mm format.
        public string FormatGeneratedAt()
        {
            return GeneratedAt.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }

        // Builds the full text of summary.txt in the layout required by Section 5.2.
        public string ToFileText()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine("BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
            text.AppendLine("ANIMAL SUMMARY REPORT");
            text.AppendLine("Generated: " + FormatGeneratedAt());
            text.AppendLine(Divider);
            text.AppendLine(FormatRow("Total animals:", TotalAnimals.ToString(CultureInfo.InvariantCulture)));
            text.AppendLine(FormatRow("Average age (years):", FormatAverage(AverageAge)));
            text.AppendLine(FormatRow("Average recovery score:", FormatAverage(AverageRecoveryScore)));
            text.AppendLine(Divider);
            text.AppendLine("Animals per status:");

            // Status rows are indented by two spaces but their numbers line up with the rows above.
            foreach (string status in AnimalClassifier.AllStatuses)
            {
                text.AppendLine(FormatRow("  " + status + ":", StatusCounts[status].ToString(CultureInfo.InvariantCulture)));
            }

            return text.ToString();
        }

        // Writes the report to summary.txt, replacing any previous report (never appending).
        public void SaveToFile(string filePath)
        {
            File.WriteAllText(filePath, ToFileText(), FileEncoding);
        }

        // Pads a label so its value starts at the shared value column.
        private static string FormatRow(string label, string value)
        {
            return label.PadRight(ValueColumn) + value;
        }
    }
}
