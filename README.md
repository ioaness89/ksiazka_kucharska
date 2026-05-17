# 📖 Książka Kucharska

Aplikacja mobilna stworzona w **.NET MAUI** umożliwiająca przeglądanie, dodawanie i zarządzanie własnymi przepisami kulinarnymi.

---

## Funkcjonalności

- **Lista przepisów** – ekran główny z nazwą, kategorią i czasem przygotowania każdego dania
- **Usuwanie przepisu** – swipe w lewo na przepisie i potwierdzenie operacji
- **Dodawanie przepisu** – formularz z walidacją na osobnym ekranie
- **Szczegóły przepisu** – pełna lista składników, opis przygotowania i czas
- **Edycja przepisu** – przycisk Edytuj w widoku szczegółów
- **Ulubione** – oznaczanie przepisów jako ulubione i osobna zakładka
- **Wyszukiwanie** po nazwie przepisu (filtrowanie na żywo)
- **Filtrowanie** po kategorii (Śniadanie / Obiad / Kolacja / Deser)
- **Sortowanie** po czasie przygotowania (rosnąco / malejąco)
- **Tryb ciemny** – przełącznik w aplikacji

---

## Technologie

- .NET MAUI (net10.0)
- C# 12
- XAML

---

## Struktura projektu

```
ksiazka_kucharska/
├── Models/
│   └── Recipe.cs               # Model przepisu
├── Service/
│   └── RecipeService.cs        # Logika i przechowywanie przepisów
├── Views/
│   ├── AddRecipePage.xaml      # Dodawanie i edycja przepisu
│   ├── ViewRecipePage.xaml     # Szczegóły przepisu
│   └── FavoritesPage.xaml      # Zakładka ulubionych
├── Resources/
│   └── Styles/
│       ├── Colors.xaml         # Paleta kolorów
│       └── Styles.xaml         # Style globalne z obsługą trybu ciemnego
├── App.xaml                    # Punkt wejścia aplikacji
├── AppShell.xaml               # Nawigacja i zakładki
├── MainPage.xaml               # Ekran główny z listą przepisów
└── MauiProgram.cs              # Konfiguracja DI i aplikacji
```

---

## Przykładowe przepisy

Aplikacja zawiera 8 wbudowanych przepisów:

| Nazwa | Kategoria | Czas |
|---|---|---|
| Jajecznica | Śniadanie | 15 min |
| Naleśniki | Śniadanie | 20 min |
| Kanapki z awokado | Śniadanie | 10 min |
| Spaghetti Bolognese | Obiad | 60 min |
| Zupa pomidorowa | Obiad | 40 min |
| Sałatka grecka | Obiad | 10 min |
| Brownie czekoladowe | Deser | 45 min |
| Tiramisu | Deser | 30 min |

---

Aplikacja została przetestowana na urządzeniu Pixel 7 - API 36.0 w emulatorze za pomocą Visual Studio 2026 Community Edition
