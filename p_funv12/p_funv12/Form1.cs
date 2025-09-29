using ScottPlot;
using ScottPlot.WinForms;
using System.IO;
using System.Linq;

namespace Big6Points
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PlotBig6();
        }

        private void PlotBig6()
        {
            // Effacer l’ancien contenu
            formsPlot1.Plot.Clear();

            // Les équipes du Big 6
            string[] teams = { "arsenal", "tottenham", "liverpool", "manu", "mancity", "chelsea" };

            foreach (string team in teams)
            {
                string filePath = Path.Combine("data", team + ".csv");
                if (!File.Exists(filePath))
                    continue;

                // Lire toutes les lignes → une valeur par ligne
                double[] points = File.ReadAllLines(filePath)
                                      .Where(line => !string.IsNullOrWhiteSpace(line))
                                      .Select(line => double.Parse(line.Trim()))
                                      .ToArray();

                if (points.Length == 0)
                    continue;

                // Axe X = numéros de matches (1, 2, 3, …)
                double[] x = Enumerable.Range(1, points.Length).Select(i => (double)i).ToArray();

                // Axe Y = cumul des points
                double total = 0;
                double[] y = points.Select(p => total += p).ToArray();

                // Ajouter une courbe
                var scatter = formsPlot1.Plot.Add.Scatter(x, y);
                scatter.LegendText = team; // texte affiché dans la légende
            }

            // Titres
            formsPlot1.Plot.Title("Évolution des points du Big 6");
            formsPlot1.Plot.XLabel("Journée");
            formsPlot1.Plot.YLabel("Points cumulés");

            // Légende
            formsPlot1.Plot.Legend.IsVisible = true;
            formsPlot1.Plot.Legend.Alignment = Alignment.UpperLeft;

            // Tracer
            formsPlot1.RefreshData();
        }
    }
}
