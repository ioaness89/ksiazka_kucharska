using ksiazka_kucharska.Views;

namespace ksiazka_kucharska
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddRecipePage), typeof(AddRecipePage));
            Routing.RegisterRoute(nameof(ViewRecipePage), typeof(ViewRecipePage));
            Routing.RegisterRoute(nameof(FavoritesPage), typeof(FavoritesPage));
        }
    }
}
