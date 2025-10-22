using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CW.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<HttpResponseData> SendGetRequestAsync(string url)
        {
            var responseData = new HttpResponseData();

            try
            {
                // 1. Validate URL
                if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    responseData.StatusCode = 400;
                    responseData.StatusDescription = "Bad Request: Invalid or empty URL.";
                    responseData.IsSuccess = false;
                    return responseData;
                }

                // 2. Send HTTP GET request
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // 3. Capture status code and reason
                responseData.StatusCode = (int)response.StatusCode;
                responseData.StatusDescription = response.ReasonPhrase ?? "No Description";
                responseData.HtmlContent = await response.Content.ReadAsStringAsync();

                // 4. Handle specific error codes
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        responseData.StatusDescription = "400 - Bad Request: The server could not understand the request.";
                        responseData.IsSuccess = false;
                        break;

                    case HttpStatusCode.Forbidden:
                        responseData.StatusDescription = "403 - Forbidden: You don’t have permission to access this resource.";
                        responseData.IsSuccess = false;
                        break;

                    case HttpStatusCode.NotFound:
                        responseData.StatusDescription = "404 - Not Found: The requested resource could not be found.";
                        responseData.IsSuccess = false;
                        break;

                    default:
                        responseData.IsSuccess = response.IsSuccessStatusCode;
                        break;
                }
            }
            catch (HttpRequestException ex)
            {
                responseData.StatusCode = 500;
                responseData.StatusDescription = $"Request error: {ex.Message}";
                responseData.IsSuccess = false;
            }
            catch (TaskCanceledException)
            {
                responseData.StatusCode = 408; // Request Timeout
                responseData.StatusDescription = "408 - Request Timeout: The request took too long to complete.";
                responseData.IsSuccess = false;
            }
            catch (Exception ex)
            {
                responseData.StatusCode = 500;
                responseData.StatusDescription = $"Unexpected error: {ex.Message}";
                responseData.IsSuccess = false;
            }

            return responseData;
        }
    }

    public class HttpResponseData
    {
        public int StatusCode { get; internal set; }
        public string StatusDescription { get; internal set; }
        public bool IsSuccess { get; internal set; }
        public string HtmlContent { get; internal set; }
    }
}
