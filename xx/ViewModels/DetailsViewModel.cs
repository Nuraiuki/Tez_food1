using System;

namespace xx.ViewModels
{
	[QueryProperty(nameof(Drinks),nameof(Drinks))]
	public partial class DetailsViewModel: ObservableObject
	{
		private readonly CartViewModel _cartViewModel;

        public DetailsViewModel(CartViewModel cartViewModel)
		{
			_cartViewModel = cartViewModel;

        }
		[ObservableProperty]
		private Drinks _drinks;
        [RelayCommand]

        private void AddToCart()
		{
			Drinks.CartQuantity++;
			_cartViewModel.UpdateCartItemCommand.Execute(Drinks);

		}
        [RelayCommand]
        private void RemoveFromCart()
        {
			if (Drinks.CartQuantity>0)
				Drinks.CartQuantity--;

        }
		[RelayCommand]
		private async Task ViewCart()
		{
			if(Drinks.CartQuantity>0)
			{
				await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
			}
			else
			{
				await Toast.Make("Пожалуйста выберите количество используя плюс (+) кнопку", ToastDuration.Short)
					.Show();
			}
		}

    }
}

