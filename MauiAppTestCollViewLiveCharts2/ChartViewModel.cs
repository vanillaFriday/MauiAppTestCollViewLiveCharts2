using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VauI.Model;

namespace MauiAppTestCollViewLiveCharts2
{
    public class ChartViewModel
    {
        public ISeries[] Series { get; set; }
        public RectangularSection[] Sections { get; set; }
        public Axis[] YAxes { get; set; }

        private ObservableCollection<LiveCharts2Diagram> _diagrams = new();
        public ObservableCollection<LiveCharts2Diagram> Diagrams
        {
            get => _diagrams;
            set => SetProperty<ObservableCollection<LiveCharts2Diagram>>(ref _diagrams, value);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ChartViewModel()
        {
            Init();
        }

        public Command ToCollViewCommand
        => new Command<string>((url) => Shell.Current.GoToAsync(url));

        private void Init()
        {
            LiveCharts2Diagram toAdd = new()
            {
                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = new double[] {1,3,7,5,2,8,7},
                        Fill = null
                    }
                },
                Sections = new RectangularSection[]
                {
                    new RectangularSection
                    {
                        Yi=0.0,
                        Yj=1.0,
                        Fill = new SolidColorPaint(SKColors.Red.WithAlpha(50))
                    },
                    new RectangularSection
                    {
                        Yi=8.0,
                        Yj=10.0,
                        Fill = new SolidColorPaint(SKColors.Red.WithAlpha(50))
                    }
                },
                YAxes = new Axis[]
                  {
                        new Axis
                        {
                            MinLimit = 0.0,
                            MaxLimit = 10.0
                        }
                  }
            };
            Diagrams.Add(toAdd);
            Series = toAdd.Series;
            YAxes = toAdd.YAxes;
            Sections = toAdd.Sections;
        }

        public void RaiseDiagrams()
        {
            RaisePropertyChanged(nameof(Diagrams));
        }

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string property = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(property);
            return true;
        }
        public virtual void RaisePropertyChanged([CallerMemberName] string property = null)
                   => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
