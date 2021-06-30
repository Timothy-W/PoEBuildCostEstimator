using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models.PoePricesModels;
using Microsoft.Extensions.Caching.Memory;

namespace BuildCostEstimator.Models.CustomValidations
{
    public class ValidPastebinLinkFormatAttribute : ValidationAttribute
    {
        //Check if input has "https://pastebin.com/" or "http://pastebin.com/"
        public string GetErrorMessageDomain() => "Link is not a pastebin link, should be: 'http(s)://pastebin.com/xxxxxxxx'.";
        public string GetErrorMessageLinkNotFound(string link) => $"{link} returned '404, Not Found', verify link is valid and try again.";
        public string GetErrorMessageRawLink() => "Raw pastebin links are not supported.";

        private IHttpClientFactory _clientFactory;

        // Cleaner solution but need to figure out how to inject IHttpClientFactory dependency
        //ValidPastebinLinkFormatAttribute(IHttpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var link = (PastebinLink)validationContext.ObjectInstance;
            

            // Check for valid formatting
            var validFormat = link.PastebinUrl.Contains("https://pastebin.com/") ||
                        link.PastebinUrl.Contains("http://pastebin.com/");

            if (!validFormat)
            {
                return new ValidationResult(GetErrorMessageDomain());
            }

            // Check link is not raw link
            var isRawLink = !link.PastebinUrl.Contains("raw");

            if (!isRawLink)
            {
                return new ValidationResult(GetErrorMessageRawLink());
            }


            
            
            
            // Cleaner solution but need to figure out how to inject IHttpClientFactory dependency
            // Check for 404 response
            //var client = _clientFactory.CreateClient();

            //var request = new HttpRequestMessage(HttpMethod.Get, link.PastebinUrl);

            //HttpResponseMessage response = client.Send(request);

            //if (response.StatusCode == HttpStatusCode.NotFound)
            //{
            //    return new ValidationResult(GetErrorMessageLinkNotFound(response.RequestMessage?.RequestUri?.AbsoluteUri));
            //}







            // Check for 404 response
            try
            {
                using var client = new WebClient();
                using var stream = client.OpenRead(link.PastebinUrl);
            }
            catch (WebException wex)
            {
                HttpWebResponse res = (HttpWebResponse)wex.Response;

                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    return new ValidationResult(GetErrorMessageLinkNotFound(res.ResponseUri.AbsoluteUri));
                }

                return new ValidationResult(wex.Message);
            }
            catch (Exception ex)
            {
                return new ValidationResult(ex.Message);
            }

            return ValidationResult.Success;



        }
        
    }
}
