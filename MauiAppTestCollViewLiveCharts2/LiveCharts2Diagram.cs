using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MauiAppTestCollViewLiveCharts2
{
    public class LiveCharts2Diagram
    {
        public ISeries[] Series { get; set; }
        public RectangularSection[] Sections { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }

        public LiveCharts2Diagram()
        {
            Series = Array.Empty<ISeries>();
            Sections = Array.Empty<RectangularSection>();
            XAxes = Array.Empty<Axis>();
            YAxes = Array.Empty<Axis>();
        }

        public void AddSeries(double[] data)
        {
            List<ISeries> series = new(Series.ToList());
            LineSeries<double> toAdd = new()
            {
                Values = data,
                Fill = null
            };
            series.Add(toAdd);
            Series = series.ToArray();
        }
        public void AddSection(double start, double end, SKColor color, byte alpha)
        {
            List<RectangularSection> sections = new(Sections.ToList());
            RectangularSection toAdd = new()
            {
                Yi = start,
                Yj = end,
                Fill = new SolidColorPaint(color.WithAlpha(alpha))
            };
            sections.Add(toAdd);
            Sections = sections.ToArray();
        }
        public void AddAxis(string xOrY, double start, double end)
        {
            List<Axis> axis = new();
            Axis toAdd = new()
            {
                MinLimit = start,
                MaxLimit = end
            };
            switch (xOrY)
            {
                case "x":
                    axis = new(XAxes.ToList())
                    {
                        toAdd
                    };
                    XAxes = axis.ToArray();
                    break;
                case "y":
                    axis = new(YAxes.ToList())
                    {
                        toAdd
                    };
                    YAxes = axis.ToArray();
                    break;
                default:
                    break;
            }
        }
    }
}
