using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace VauI.Model
{
    public class LiveCharts2Diagram
    {
        public ISeries[] Series { get; set; }
        public RectangularSection[] Sections { get; set; }
        public Axis[] YAxes { get; set; }

        public LiveCharts2Diagram()
        {

        }
    }
}
