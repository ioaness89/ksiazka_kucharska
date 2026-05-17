using ksiazka_kucharska.Models;
using ksiazka_kucharska.Service;

namespace ksiazka_kucharska.Views;

[QueryProperty(nameof(RecipeId), "recipeId")]
public partial class ViewRecipePage : ContentPage
{
	private readonly RecipeService _recipeService;

	public string RecipeId
	{
		set
		{
			var recipe = _recipeService.GetRecipeById(int.Parse(value));

			BindingContext = recipe;
		}
	}
	public ViewRecipePage(RecipeService recipeService)
	{
		InitializeComponent();

		_recipeService = recipeService;
	}

    private async void OnEditClicked(object sender, EventArgs e)
    {
		var recipe = (Recipe)BindingContext;

		await Shell.Current.GoToAsync($"{nameof(AddRecipePage)}?recipeId={recipe.Id}");
    }
}