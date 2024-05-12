using System;
using System.Collections.ObjectModel;
using xx.Services;
using xx.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace xx.ViewModels
{
	public partial class HomeViewModel : ObservableObject
	{
		private readonly DrinkService _drinkService;
		public HomeViewModel(DrinkService drinkService)
		{
			_drinkService = drinkService;
			Drinks = new(_drinkService.GetPopularDrinks());	
		}
		public ObservableCollection<Drinks> Drinks { get; set; }

		[RelayCommand]
		private async Task GoToAllDrinksPage(bool fromSearch = false)
		{
			var parameters = new Dictionary<string, object>
			{
				[nameof(AllDrinkViewModel.FromSearch)] = fromSearch
			};
			await Shell.Current.GoToAsync(nameof(AllDrinkPage),animate:true, parameters);
		}

		[RelayCommand]
		private async Task GoToDetailsPage(Drinks drinks)
		{
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Drinks)] = drinks
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }


    }

}

