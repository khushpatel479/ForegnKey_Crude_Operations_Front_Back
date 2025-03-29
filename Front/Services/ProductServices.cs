using Inmemory_Consumer.Models;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Inmemory_Consumer.Services
{
    public class ProductServices:HttpClient
    {
        HttpClient client;
        const string baseurl = "https://localhost:7131/api/ProductCtr";
        public ProductServices(HttpClient _client)
        {
            client = _client;
        }
        public async Task<List<ProductModel>> prget()
        {
            var ty = await client.GetFromJsonAsync<List<ProductModel>>($"{baseurl}/proget");
            return ty;
        }
        public async Task<bool> prins(ProductModel pl)
        {
            var ty = await client.PostAsJsonAsync($"{baseurl}/productins", pl);
            return ty.IsSuccessStatusCode;

        }
        public async Task<ProductModel> getid(int id)
        {
            var ty = await client.GetAsync($"{baseurl}/prgetid/{id}");
            var cont = await ty.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductModel>(cont , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<bool> updpr(ProductModel mp,int id)
        {
            var ty = await client.PutAsJsonAsync($"{baseurl}/prupd/{id}", mp);
            return ty.IsSuccessStatusCode;
        }
        public async Task<ProductModel> disbyid(int id)
        {
            var ty = await client.GetAsync($"{baseurl}/prgetid/{id}");
            var cont = await ty.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductModel>(cont, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }
        public async Task<ProductModel> fghid(int id)
        {
            var ty = await client.GetAsync($"{baseurl}/prgetid/{id}");
            var cont = await ty.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductModel>(cont, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<bool> delpr(int id)
        {
            var ty = await client.DeleteAsync($"{baseurl}/deleteproduct/{id}");
            return ty.IsSuccessStatusCode;  
        }
        public async Task<List<ProductModel>> serchbyname(string name)
        {
            var ty = await client.GetFromJsonAsync<List<ProductModel>>($"{baseurl}/getbyname/{name}");
            return ty;
        }
       
    }
}
