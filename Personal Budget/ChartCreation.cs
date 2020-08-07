using LiveCharts;
using LiveCharts.Wpf;
using Personal_Budget.Models;
using System.Collections.Generic;
using System.Windows.Media;

namespace Personal_Budget
{
    class ChartCreation
    {
        public static void FillChart(PieChart chart, List<Category> categories)
        {
            chart.Series.Clear();

            SeriesCollection collection = new SeriesCollection();

            chart.InnerRadius = 200;
            chart.LegendLocation = LegendLocation.Right;
            chart.FontSize = 20;

            foreach (Category category in categories)
            {
                collection.Add(new PieSeries
                {
                    Title = category.Name,
                    Values = new ChartValues<double> {double.Parse(category.Cost)},
                    Foreground = Brushes.White
                });
            }

            chart.Series = collection;
            
        }

        public static void FillChart(PieChart chart, List<Recipient> categories)
        {
            chart.Series.Clear();

            SeriesCollection collection = new SeriesCollection();

            chart.InnerRadius = 200;
            chart.LegendLocation = LegendLocation.Right;
            chart.FontSize = 20;

            foreach (Recipient category in categories)
            {
                collection.Add(new PieSeries
                {
                    Title = category.Name,
                    Values = new ChartValues<double> { double.Parse(category.Cost) },
                    Foreground = Brushes.White
                });
            }

            chart.Series = collection;

        }

        public static void FillMonthChart(ChartValues<double> chart, List<Category> categories)
        {
            chart.Clear();

            foreach (Category category in categories)
            {
                chart.Add(double.Parse(category.Cost));
            }
        }

        public static void CustomizeMonthChart(CartesianChart chart, List<string> xAxis)
        {
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            chart.AxisX.Add(new Axis
            {
                Labels = xAxis,
                FontSize = 20
            });

            chart.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("C"),
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Step = 1000,
                    IsEnabled = false
                },
                FontSize = 20,
                Sections = new SectionsCollection
                {
                    new AxisSection
                    {
                        Value = 0,
                        SectionWidth = 15,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(254,132,132),
                            Opacity = 1
                        }
                    }
                }
            }) ;
            
        }
    }
}
