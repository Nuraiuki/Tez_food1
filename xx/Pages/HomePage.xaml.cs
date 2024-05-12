namespace xx.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;

	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		_homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
	}

	async void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(AllDrinkPage)}");
	}


}


