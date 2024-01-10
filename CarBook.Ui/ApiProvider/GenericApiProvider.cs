using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Ui.ApiProvider
{
	public static class GenericApiProvider<TEntity>
	{
		[HttpGet]
		public static async Task<List<TEntity>> GetListAsync(string? controller, string? method)
		{
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync($"https://localhost:44351/api/{controller}{"/"}{method}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonString = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<TEntity>>(jsonString);
				return values;
			}
			return null;
		}
	}
}
