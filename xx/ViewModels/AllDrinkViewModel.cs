using System.Threading.Tasks;

namespace xx.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllDrinkViewModel : ObservableObject
    {
        private readonly DrinkService _drinkService;

        public AllDrinkViewModel(DrinkService drinkService)
        {
            _drinkService = drinkService;
            Drinks = new ObservableCollection<Drinks>(_drinkService.GetAllDrinks());
        }

        public ObservableCollection<Drinks> Drinks { get; set; }
        [ObservableProperty]
        private bool _fromSearch;
        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchDrinks(string searchTerm)
        {
            Drinks.Clear();
            Searching = true;
            await Task.Delay(1000); 

            var searchResults = _drinkService.SearchDrinks(searchTerm).ToList();
            foreach (var drink in searchResults)
            {
                Drinks.Add(drink);
            }
            Searching = false;
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
