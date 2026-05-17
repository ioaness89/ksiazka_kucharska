using ksiazka_kucharska.Models;
using ksiazka_kucharska.Service;

namespace ksiazka_kucharska.Views;

[QueryProperty(nameof(RecipeId), "recipeId")]
public partial class AddRecipePage : ContentPage

{


	private readonly RecipeService _recipeService;
	public AddRecipePage(RecipeService recipeService)
	{
		InitializeComponent();

		_recipeService = recipeService;

		BindingContext = this;
	}

	public List<string> Options { get; } = new()
	{
		"Śniadanie",
		"Obiad",
		"Kolacja",
		"Deser"
	};

	public string SelectedOption { get; set; }

    private async void OnSaveClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlertAsync("Błąd", "Nazwa przepisu jest wymagana", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(TimeEntry.Text) || !int.TryParse(TimeEntry.Text, out _))
        {
            await DisplayAlertAsync("Błąd", "Podaj poprawny czas przygotowania", "OK");
            return;
        }

        if (_editingRecipe != null)
		{
			_editingRecipe.Title = TitleEntry.Text;
			_editingRecipe.Category = SelectedOption;
			_editingRecipe.PreparationTimeMinutes = int.TryParse(TimeEntry.Text, out var d) ? d : 0;
			_editingRecipe.Description = DescriptionEditor.Text;
			_editingRecipe.Ingredients = IngredientsEditor.Text?.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		else
		{

			var recipe = new Recipe
			{
				Title = TitleEntry.Text,
				Category = SelectedOption,
				PreparationTimeMinutes = int.TryParse(TimeEntry.Text, out var t) ? t : 0,
				Description = DescriptionEditor.Text,
				Ingredients = IngredientsEditor.Text?.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList()
			};

			_recipeService.AddRecipe(recipe);
		}

        await Shell.Current.GoToAsync("..");
    }

	private Recipe? _editingRecipe;

	public string RecipeId
	{
		set
		{
			_editingRecipe = _recipeService.GetRecipeById(int.Parse(value));
			if( _editingRecipe != null)
			{
				TitleEntry.Text = _editingRecipe.Title;
				TimeEntry.Text = _editingRecipe.PreparationTimeMinutes.ToString();
				DescriptionEditor.Text = _editingRecipe.Description;
				IngredientsEditor.Text = string.Join("\n", _editingRecipe.Ingredients ?? []);
				SelectedOption = _editingRecipe.Category;
				OnPropertyChanged(nameof(SelectedOption));
			}
		}
	}
}