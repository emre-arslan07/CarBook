using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

        [HttpPost]
        public static async Task<bool> AddTentityAsync(string? controller, string? method, TEntity? tentity)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(tentity);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync($"https://localhost:44351/api/{controller}{"/"}{method}",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<bool> DeleteTentityAsync(string controller, string method, int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:44351/api/{controller}{"/"}{method}{"?id="}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [HttpPost]
        public static async Task<bool> UpdateTentityAsync(string controller,string method,TEntity tentity)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(tentity);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync($"https://localhost:44351/api/{controller}{"/"}{method}",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [HttpGet]
        public static async Task<List<TEntity>> GetListAsyncById(string? controller, string? method,int? id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:44351/api/{controller}{"/"}{method}{"?id="}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TEntity>>(jsonString);
                return values;
            }
            return null;
        }

        [HttpGet]
        public static async Task<TEntity?> GetAsyncById(string? controller, string? method, int? id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:44351/api/{controller}{"/"}{method}{"?id="}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TEntity>(jsonString);
                return values;
            }
            return default(TEntity);
        }

        [HttpGet]
        public static async Task<TEntity?> GetStatisticAsync(string? controller, string? method)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:44351/api/{controller}{"/"}{method}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TEntity>(jsonString);
                return values;
            }
            return default(TEntity);
        }
    }
}
