using ksiazka_kucharska.Models;
using ksiazka_kucharska.Service;
using ksiazka_kucharska.Views;

namespace ksiazka_kucharska
{
    public partial class MainPage : ContentPage
    {
        private readonly RecipeService _recipeService;

        public MainPage(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
            RecipesCollection.ItemsSource = _recipeService.Recipes;
        }
        // Przejście do formularza dodania nowego przepisu
        private async void OnAddRecipeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddRecipePage));
        }
        // Usunięcie przez swipe i potwierdzenie usunięcia
        private async void OnSwipeDelete(object sender, EventArgs e)
        {
            var button = (SwipeItem)sender;
            if (button.CommandParameter is Recipe recipe)
            {
                bool answer = await DisplayAlertAsync(
                    "Usuń przepis",
                    $"Na pewno chcesz usunąć: {recipe.Title}",
                    "Tak",
                    "Nie"
                );

                if (answer)
                {
                    _recipeService.RemoveRecipe(recipe);
                }
            }
        }
        // Przejście do szczegółów przepisu
        private async void OnViewRecipeClicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;

            if(button.CommandParameter is int id)
            {
                await Shell.Current.GoToAsync($"{nameof(ViewRecipePage)}?recipeId={id}");
            }
        }
        // Dodanie przepisu do ulubionych
        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.CommandParameter is Recipe recipe)
            {
                recipe.IsFavorite = !recipe.IsFavorite;
                button.Text = recipe.IsFavorite ? "♥" : "♡";
            }
        }
        // Zmiana motywu z jasnego na ciemny i odwrotnie
        private void OnThemeToggleClicked(object sender, EventArgs e)
        {
            if (Application.Current.UserAppTheme == AppTheme.Dark)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                ((Button)sender).Text = "🌙";
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                ((Button)sender).Text = "☀️";
            }
        }
        // Zmienna przechowywująca tryb sortowania
        private bool _sortAscending = true;
        // Funkcja odświeżająca listę na podstawie wybranych kategorii i zmienionym trybie sortowania
        private void RefreshList()
        {
            var query = SearchEntry.Text?.ToLower() ?? "";
            var category = CategoryPicker.SelectedItem?.ToString();

            var result = _recipeService.Recipes.AsEnumerable();

            // filtr po nazwie
            if (!string.IsNullOrWhiteSpace(query))
                result = result.Where(r => r.Title.ToLower().Contains(query));

            // filtr po kategorii
            if (!string.IsNullOrWhiteSpace(category) && category != "Wszystkie")
                result = result.Where(r => r.Category == category);

            // sortowanie
            result = _sortAscending
                ? result.OrderBy(r => r.PreparationTimeMinutes)
                : result.OrderByDescending(r => r.PreparationTimeMinutes);

            RecipesCollection.ItemsSource = result.ToList();
        }
        // Zmienianie filtrowania po kategorii
        private void OnFilterChanged(object sender, EventArgs e) => RefreshList();
        // Zmienienie trybu sortowania
        private void OnSortClicked(object sender, EventArgs e)
        {
            _sortAscending = !_sortAscending;
            ((Button)sender).Text = _sortAscending ? "Sortuj po czasie ↑" : "Sortuj po czasie ↓";
            RefreshList();
        }

        // Wyszukiwanie tekstu
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e) => RefreshList();
    }
}
