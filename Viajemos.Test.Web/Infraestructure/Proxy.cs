using RestSharp;
using System;
using System.Collections.Generic;

namespace Viajemos.Test.Web.Infraestructure
{
    public class Proxy<TModel> : IProxy<TModel> where TModel : class
    {
        private readonly RestClient client;

        public Proxy()
        {
            client = new RestClient();
        }

        public IEnumerable<TModel> Get(string baseUrl, string endpoint)
        {
            client.BaseUrl = new Uri(baseUrl);
            var request = new RestRequest(endpoint, Method.GET);
            var response = client.Execute<List<TModel>>(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? response.Data
                                                                       : new List<TModel>();
        }

        public IRestResponse Post(string baseUrl, string endpoint, TModel model)
        {
            client.BaseUrl = new Uri(baseUrl);
            var request = new RestRequest(endpoint, Method.POST);
            request.AddJsonBody(model);

            return client.Execute(request);

        }
    }
}
