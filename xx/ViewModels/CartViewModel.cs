using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace xx.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {

        public ObservableCollection<Drinks> Items { get; set; } = new();
        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Drinks drinks)
        {
            var item = Items.FirstOrDefault(i => i.Name == drinks.Name);
            if (item is not null)
            {
                item.CartQuantity = drinks.CartQuantity;

            }
            else
            {
                Items.Add(drinks.Clone());
            }
            RecalculateTotalAmount();

        }
        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();
                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.CadetBlue
                };
                var snackbar = Snackbar.Make($"'{item.Name}' удален с корзины",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();


                    }, "Отменить", TimeSpan.FromSeconds(5), snackbarOptions);
                await snackbar.Show();
            }
        }


        [RelayCommand]

        private async Task PlaceOrder()
        {
            Items.Clear();
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }

    }
}
