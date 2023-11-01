using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppTestCollViewLiveCharts2
{
    public class ChartViewModel
    {
        private ISeries[] _series;
        private RectangularSection[] _sections;
        private Axis[] _axis;

        public ISeries[] Series
        {
            set => SetProperty<ISeries[]>(ref _series, value);
            get => _series;
        }
        public RectangularSection[] Sections
        {
            set => SetProperty<RectangularSection[]>(ref _sections, value);
            get => _sections;
        }
        public Axis[] YAxes
        {
            set => SetProperty<Axis[]>(ref _axis, value);
            get => _axis;
        }

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
        => new Command<string>((url) => 
            {
                Shell.Current.GoToAsync(url);
                RaiseDiagrams();
            });

        private void Init()
        {
            LiveCharts2Diagram toAdd = new();
            toAdd.AddSeries(new double[] { 1, 3, 7, 5, 2, 8, 7 });
            toAdd.AddSection(0.0, 1.0, SKColors.Red, 50);
            toAdd.AddSection(8.0, 10.0, SKColors.Yellow, 100);
            toAdd.AddAxis("y", 0.0, 10.0);

            Diagrams.Add(toAdd);
            Diagrams.Add(toAdd);
            Diagrams.Add(toAdd);
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
