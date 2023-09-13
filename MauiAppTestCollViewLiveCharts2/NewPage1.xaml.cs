namespace MauiAppTestCollViewLiveCharts2;

public partial class NewPage1 : ContentPage
{
	public NewPage1(ChartViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent(); 
    }
}