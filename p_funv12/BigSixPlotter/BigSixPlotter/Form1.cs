using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot;
using ScottPlot.WinForms;



namespace BigSixPlotter
{
    public partial class Form1 : Form
    {
        string[] teams = { "arsenal", "chelsea", "liverpool", "mancity", "manu", "tottenham" };
        string dataPath = Path.Combine(Application.StartupPath, "data");

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var plt = formsPlot1.Plot;

            foreach (var team in teams)
            {
                string filePath = Path.Combine(dataPath, $"{team}.csv");
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Missing file: {filePath}");
                    continue;
                }

                // Read and parse the file
                var lines = File.ReadAllLines(filePath);
                var points = lines.Select(line => int.TryParse(line.Trim(), out int val) ? val : 0).ToArray();

                // Compute cumulative points
                double[] cumulative = new double[points.Length];
                cumulative[0] = points[0];
                for (int i = 1; i < points.Length; i++)
                    cumulative[i] = cumulative[i - 1] + points[i];

                // Plot
                double[] x = Enumerable.Range(1, cumulative.Length).Select(i => (double)i).ToArray();
                var scatter = plt.Add.Scatter(x, cumulative);
                scatter.Label = team.ToUpper();
                ScottPlot.Color color;
                switch (team)
                {
                    case "chelsea": color = ScottPlot.Color.FromHex("#00008B"); break;         // Dark Blue
                    case "arsenal": color = ScottPlot.Color.FromHex("#FF0000"); break;         // True Red
                    case "liverpool": color = ScottPlot.Color.FromHex("#006400"); break;       // Dark Green
                    case "manu": color = ScottPlot.Color.FromHex("#800000"); break;            // Maroon / Bordeaux
                    case "tottenham": color = ScottPlot.Color.FromHex("#000000"); break;       // Black
                    case "mancity": color = ScottPlot.Color.FromHex("#87CEEB"); break;         // Sky Blue
                    default: color = ScottPlot.Color.FromHex("#808080"); break;                // Gray fallback
                }
                scatter.Color = color;


            }

            plt.Title("Big Six Point Evolution (Last 5 Seasons)");
            plt.XLabel("Matchday");
            plt.YLabel("Cumulative Points");
            plt.Legend.IsVisible = true;

            formsPlot1.Refresh();
        }
    }
}
