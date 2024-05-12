namespace xx.Pages;

public partial class AllDrinkPage : ContentPage
{
	private readonly AllDrinkViewModel _allDrinkViewModel;

    public AllDrinkPage(AllDrinkViewModel allDrinkViewModel)
	{
        InitializeComponent();

        _allDrinkViewModel = allDrinkViewModel;
        BindingContext = _allDrinkViewModel;

    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allDrinkViewModel.SearchDrinksCommand.Execute(null);
        }
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}
