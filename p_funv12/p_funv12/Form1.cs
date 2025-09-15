using ScottPlot;
using ScottPlot.WinForms;
using System.IO;
using System.Linq;

namespace p_funv12
{
    public partial class Form1 : Form
    {
        private Dictionary<string, IPlottable> teamPlots = new();

        public Form1()
        {
            InitializeComponent();
            LoadDataAndPlot();
        }

        private void LoadDataAndPlot()
        {
            formsPlot1.Plot.Clear();

            string[] teams = { "arsenal", "tottenham", "liverpool", "manu", "mancity", "chelsea" };

            foreach (string team in teams)
            {
                string filePath = Path.Combine("data", team + ".csv");
                if (!File.Exists(filePath)) continue;

                // Lire points comme double directement
                var points = File.ReadAllLines(filePath)
                                 .Select(line => double.Parse(line))
                                 .ToArray();

                // Axe X = match index
                double[] x = Enumerable.Range(1, points.Length).Select(i => (double)i).ToArray();

                // Axe Y = cumul des points
                double[] y = points.Select((p, i) => points.Take(i + 1).Sum()).ToArray();

                // Ajouter la courbe
                var scatter = formsPlot1.Plot.Add.Scatter(x, y);
                scatter.Label = team; // en v5: Label est une propriété
                teamPlots[team] = scatter;
            }

            // Titres
            formsPlot1.Plot.Title("Big 6 Points (2020–2025)");
            formsPlot1.Plot.XLabel("Gameweek");
            formsPlot1.Plot.YLabel("Points");

            // Activer la légende
            formsPlot1.Plot.Legend.IsVisible = true;
            formsPlot1.Plot.Legend.Location = Alignment.UpperLeft;

            formsPlot1.Refresh();
        }
    }
}
