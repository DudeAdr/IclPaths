using IclPaths.UI.Configuration;
using IclPaths.UI.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace IclPaths.UI.Services
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public RegionRepository(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<RegionViewModel?> AddRegion(RegionViewModel regionViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _apiSettings.IclPathsAPI?.TrimEnd('/') ?? string.Empty;
            var httpRequestMsg = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/api/regions")
            {
                Content = JsonContent.Create(regionViewModel)
            };
            var responseMsg = await client.SendAsync(httpRequestMsg);

            if (responseMsg.IsSuccessStatusCode)
            {
                return await responseMsg.Content.ReadFromJsonAsync<RegionViewModel>();
            }
            return null;
        }

        public async Task<RegionViewModel?> DeleteRegion(Guid regionId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var baseUrl = _apiSettings.IclPathsAPI?.TrimEnd('/') ?? string.Empty;
                var httpRequestMsg = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/api/regions/{regionId}");
                var responseMsg = await client.SendAsync(httpRequestMsg);

                if (responseMsg.IsSuccessStatusCode)
                {
                    return await responseMsg.Content.ReadFromJsonAsync<RegionViewModel>();
                }
                return null;
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public async Task<List<RegionViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _apiSettings.IclPathsAPI?.TrimEnd('/') ?? string.Empty;
            var response = await client.GetFromJsonAsync<List<RegionViewModel>>($"{baseUrl}/api/regions");
            return response ?? new List<RegionViewModel>();
        }

        public async Task<RegionViewModel?> GetByIdAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _apiSettings.IclPathsAPI?.TrimEnd('/') ?? string.Empty;
            return await client.GetFromJsonAsync<RegionViewModel>($"{baseUrl}/api/regions/{id}");
        }

        public async Task<RegionViewModel?> UpdateRegion(RegionViewModel regionViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _apiSettings.IclPathsAPI?.TrimEnd('/') ?? string.Empty;
            var httpRequestMsg = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/api/regions/{regionViewModel.Id}")
            {
                Content = JsonContent.Create(regionViewModel)
            };
            var responseMsg = await client.SendAsync(httpRequestMsg);

            if (responseMsg.IsSuccessStatusCode)
            {
                return await responseMsg.Content.ReadFromJsonAsync<RegionViewModel>();
            }
            return null;
        }
    }
}
