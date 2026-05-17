using System;
using System.Collections.Generic;
using System.Text;
using ksiazka_kucharska.Models;
using System.Collections.ObjectModel;

namespace ksiazka_kucharska.Service
{
    public class RecipeService
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public RecipeService()
        {
            Recipes = new ObservableCollection<Recipe>
            {
                new Recipe
                {
                    Id = 1,
                    Title = "Jajecznica",
                    Category = "Śniadanie",
                    PreparationTimeMinutes = 15,
                    Ingredients = ["jajka","sól","masło"],
                    Description = "Rozbij jajka do miski i lekko je roztrzep widelcem, aż białko i żółtko się połączą. Dopraw solą i pieprzem. Rozgrzej patelnię z odrobiną masła lub oleju na średnim ogniu. Wlej jajka na patelnię i smaż, cały czas delikatnie mieszając, aż zaczną się ścinać, ale nadal będą miękkie i kremowe. Zdejmij z ognia, gdy osiągną preferowaną konsystencję, żeby nie przesuszyć. Opcjonalnie dodaj szczypiorek, ser lub kawałki wędliny przed podaniem.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Spaghetti Bolognese",
                    Category = "Obiad",
                    PreparationTimeMinutes = 60,
                    Ingredients = ["mięso mielone","cebula","czosnek","passata pomidorowa","oliwa lub olej","sól","pieprz","makaron spaghetti","koncentrat pomidorowy"],
                    Description = "Podsmaż cebulę i czosnek na oliwie. Dodaj mięso mielone i smaż, aż się zarumieni. Wlej passatę pomidorową i dodaj koncentrat. Dopraw solą i pieprzem. Duś całość ok. 15–20 minut na małym ogniu. Ugotuj makaron spaghetti. Wymieszaj sos z makaronem i podawaj.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Naleśniki",
                    Category = "Śniadanie",
                    PreparationTimeMinutes = 20,
                    Ingredients = ["mąka","jajka","mleko","masło","szczypta soli"],
                    Description = "Wymieszaj mąkę, jajka, mleko i sól na gładkie ciasto. Odstaw na 10 minut. Smaż na rozgrzanej patelni z odrobiną masła, po około 1-2 minuty z każdej strony. Podawaj z dżemem, twarogiem lub owocami.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 4,
                    Title = "Zupa pomidorowa",
                    Category = "Obiad",
                    PreparationTimeMinutes = 40,
                    Ingredients = ["passata pomidorowa","bulion warzywny","cebula","czosnek","śmietana","sól","pieprz","cukier","makaron"],
                    Description = "Podsmaż cebulę i czosnek na oleju. Wlej bulion i passatę. Gotuj 20 minut na małym ogniu. Dopraw solą, pieprzem i szczyptą cukru. Zmiksuj zupę, dodaj śmietanę i podgrzej. Podawaj z ugotowanym makaronem.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 5,
                    Title = "Sałatka grecka",
                    Category = "Obiad",
                    PreparationTimeMinutes = 10,
                    Ingredients = ["ogórek","pomidory","cebula czerwona","oliwki","ser feta","oliwa","oregano","sól"],
                    Description = "Pokrój ogórka, pomidory i cebulę w kostkę. Dodaj oliwki i pokruszoną fetę. Skrop oliwą, posyp oregano i solą. Wymieszaj delikatnie i podawaj od razu.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 6,
                    Title = "Brownie czekoladowe",
                    Category = "Deser",
                    PreparationTimeMinutes = 45,
                    Ingredients = ["czekolada gorzka","masło","jajka","cukier","mąka","kakao","szczypta soli"],
                    Description = "Rozpuść czekoladę z masłem w kąpieli wodnej. Ubij jajka z cukrem, dodaj przestudzoną czekoladę. Wsyp mąkę, kakao i sól, wymieszaj. Wylej do formy i piecz 25 minut w 180°C. Brownie powinno być lekko wilgotne w środku.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 7,
                    Title = "Kanapki z awokado",
                    Category = "Śniadanie",
                    PreparationTimeMinutes = 10,
                    Ingredients = ["chleb pełnoziarnisty","awokado","jajko","sok z cytryny","sól","pieprz","płatki chili"],
                    Description = "Rozgnieć awokado widelcem, dopraw sokiem z cytryny, solą i pieprzem. Posmaruj tosty pastą z awokado. Na wierzch połóż jajko sadzone lub w koszulce. Posyp płatkami chili i podawaj.",
                    IsFavorite = false
                },
                new Recipe
                {
                    Id = 8,
                    Title = "Tiramisu",
                    Category = "Deser",
                    PreparationTimeMinutes = 30,
                    Ingredients = ["mascarpone","jajka","cukier","kawa espresso","biszkopty","kakao","amaretto"],
                    Description = "Ubij żółtka z cukrem, dodaj mascarpone i wymieszaj. Ubij białka na sztywno i delikatnie połącz z masą. Nasącz biszkopty w kawie z amaretto. Układaj warstwami: biszkopty, masa, biszkopty, masa. Posyp kakao i schłódź minimum 4 godziny.",
                    IsFavorite = false
                }
            };
        }
        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        public Recipe GetRecipeById(int id)
        {
            return Recipes.FirstOrDefault(r => r.Id == id);
        }
    }
}
