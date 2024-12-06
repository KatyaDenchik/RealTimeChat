using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Configuration;

namespace RealTimeChat.Services
{
    public class TextAnalyticsService
    {
        private readonly TextAnalyticsClient client;

        public TextAnalyticsService(IConfiguration configuration)
        {
            var endpoint = configuration["AzureCognitiveServices:TextAnalyticsEndpoint"];
            var apiKey = configuration["AzureCognitiveServices:TextAnalyticsKey"];
            client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        }

        public string AnalyzeSentiment(string text)
        {
            var response = client.AnalyzeSentiment(text);
            return response.Value.Sentiment.ToString();
        }
    }
}
