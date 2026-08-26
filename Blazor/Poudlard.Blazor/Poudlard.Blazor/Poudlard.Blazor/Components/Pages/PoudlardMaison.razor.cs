using System.Text.Json;

namespace Poudlard.Blazor.Components.Pages
{
    public partial class PoudlardMaison
    {
        HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7050/api/")
        };

        Maison[] maisons = HttpClient.GetFromJsonAsync<Maison[]>("maison", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


        record Maison(Guid Id, string Name, string Fondateur, string Couleur, string Embleme);
    }
}
