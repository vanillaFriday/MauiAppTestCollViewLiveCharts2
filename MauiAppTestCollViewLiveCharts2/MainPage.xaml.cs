namespace MauiAppTestCollViewLiveCharts2
{
    public partial class MainPage : ContentPage
    {

        public MainPage(ChartViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}