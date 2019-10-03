using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VersionTester.Models.V1;

namespace VersionTester
{
    static class Program
    {
        private static async Task Main ()
        {
            await ReadDefaultAsync().ConfigureAwait(false);
            await ReadV2WithQueryStringAsync().ConfigureAwait(false);
            await ReadV2WithHeaderAsync().ConfigureAwait(false);
        }

        private static async Task ReadDefaultAsync()
        {
            var client = GetHttpClient();
            var result = await client.GetAsync("Concerns").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                using (var stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var concern = (List<Concern>) await new JsonMediaTypeFormatter()
                        .ReadFromStreamAsync(typeof(List<Concern>), stream, result.Content,
                            null).ConfigureAwait(false);
                }
            }
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient {BaseAddress = new Uri("http://localhost:3134/")};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static async Task ReadV2WithQueryStringAsync()
        {
            var client = GetHttpClient();
            var result = await client.GetAsync("Concerns?api-version=2.0").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                using (var stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var concern = (List<Models.V2.Concern>) await new JsonMediaTypeFormatter()
                        .ReadFromStreamAsync(typeof(List<Models.V2.Concern>), stream, result.Content,
                            null).ConfigureAwait(false);
                }
            }
        }

        private static async Task ReadV2WithHeaderAsync()
        {
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Add("api-version", "2.0");
            var result = await client.GetAsync("Concerns?api-version=2.0").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                using (var stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var concern = (List<Models.V2.Concern>) await new JsonMediaTypeFormatter()
                        .ReadFromStreamAsync(typeof(List<Models.V2.Concern>), stream, result.Content,
                            null).ConfigureAwait(false);
                }
            }
        }

    }
}
