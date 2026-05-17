namespace ksiazka_kucharska.Views;

using ksiazka_kucharska.Service;


public partial class FavoritesPage : ContentPage
{
	private readonly RecipeService _recipeService;
	public FavoritesPage(RecipeService recipeService)
	{
		InitializeComponent();
		_recipeService = recipeService;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		FavoritesCollection.ItemsSource = _recipeService.Recipes.Where(r => r.IsFavorite).ToList();
	}
}