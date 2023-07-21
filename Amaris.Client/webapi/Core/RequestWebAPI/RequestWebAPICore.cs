using Amaris.WebAPI.Core.RequestWebAPI.Interfaces;
using Amaris.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Amaris.WebAPI.Core.RequestWebAPI
{
    public class RequestWebAPICore : IRequestWebAPICore
    {
        #region Fields
        private readonly HttpClient _httpClient;    
        #endregion

        #region Builder
        public RequestWebAPICore()
        {
            _httpClient = new HttpClient(); 
        }
        #endregion

        #region Methods

        public async Task<string> CallApi()
        {
            return await CallApi(null);
        }

        public async Task<string> CallApi(string? idEmployee)
        {
            try
            {
                string webAddr = string.Empty;
                if (idEmployee == null)
                {
                    webAddr = "https://dummy.restapiexample.com/api/v1/employees";
                }
                else
                {
                    webAddr = "https://dummy.restapiexample.com/api/v1/employee/" + idEmployee;
                }
                var httpWebRequest = await _httpClient.GetAsync(webAddr);
                if(httpWebRequest.StatusCode == HttpStatusCode.OK)
                {
                    return await httpWebRequest.Content.ReadAsStringAsync();
                }
                else if(httpWebRequest.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    return HttpStatusCode.TooManyRequests.ToString();
                }
                return null;

            }
            catch (WebException ex)
            {
                return ex.Message;
            }

        }

        #endregion
    }
}
