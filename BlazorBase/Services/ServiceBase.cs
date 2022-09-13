using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace BlazorBase.Services
{
    public class ServiceBase
    {
        private readonly HttpClient _httpClient;

        public ServiceBase(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri("http://localhost:5259/");
        }
        private string GetTypeName<T>()
        {
            return typeof(T).Name;
        }

        public async Task CreateAsync<T>(T entity)
        {
            var json = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, MediaTypeNames.Application.Json);
            using var response = await _httpClient.PostAsync($@"{GetTypeName<T>()}/CreateAsync", json);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<T>?> ReadAllAsync<T>()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"{GetTypeName<T>()}/ReadAllAsync");
        }

        public async Task<T?> ReadOneAsync<T>(string id)
        {
            var truc = _httpClient.GetFromJsonAsync<T>($"{GetTypeName<T>()}/ReadOneAsync/{id}");
            return await truc;
        }

        public async Task UpdateAsync<T>(string id, T entity)
        {
            var json = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, MediaTypeNames.Application.Json);
            using var response = await _httpClient.PutAsync($@"{GetTypeName<T>()}/UpdateAsync/{id}", json);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOneAsync<T>(string id)
        {
            using var response = await _httpClient.DeleteAsync($@"{GetTypeName<T>()}/DeleteOneAsync/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
