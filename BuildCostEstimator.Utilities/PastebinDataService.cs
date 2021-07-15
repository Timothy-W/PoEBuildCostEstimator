using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BuildCostEstimator.Models;


namespace BuildCostEstimator.Utilities
{
    public class PastebinDataService
    {
        private static IHttpClientFactory _clientFactory;
        public static XDocument ProcessUrl(PastebinLink pastebinLink, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            var pastebinData = GetPastebinDataFrom(pastebinLink);

            XDocument xmlDoc = null;
            try
            {
                xmlDoc = DecodeAndInflateXmlFrom(pastebinData);
            }
            catch (InvalidDataException e)
            {
                throw e;
 
            }
      

            return xmlDoc;
            
        }


        private static string GetPastebinDataFrom(PastebinLink pastebinLink)
        {
            var rawUrl = ConvertToRawUrl(pastebinLink);

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, rawUrl);

            HttpResponseMessage response = client.Send(request);

            string hash = "";
            if (response.IsSuccessStatusCode)
            {
                hash = response.Content.ReadAsStringAsync().Result;
            }

            return hash;

        

        }

        private static string ConvertToRawUrl(PastebinLink pastebinLink){ 
            
            //https://pastebin.com/7nhJbxk4 ---> https://pastebin.com/raw/7nhJbxk4
            //https://pastebin.com/fmEfjCkS ---> https://pastebin.com/raw/fmEfjCkS

            return pastebinLink.PastebinUrl.Insert(pastebinLink.PastebinUrl.LastIndexOf('/'), "/raw");
        }

        private static XDocument DecodeAndInflateXmlFrom(string base64Encoding)
        {
            var newBase64Encoding = base64Encoding.Replace("-", "+").Replace("_", "/");

            Span<byte> buffer = new Span<byte>(new byte[newBase64Encoding.Length]);
            
            if (!Convert.TryFromBase64String(newBase64Encoding, buffer, out int bytesWritten))
            {
                throw new InvalidDataException("Unable to decode Base64 string, verify data from pastebin link is a valid PoB code.");
            }


            // Convert to byte array
            using (var memStream = new MemoryStream(buffer.ToArray()))
            {
                //Advance two bytes.
                //See http://george.chiramattel.com/blog/2007/09/deflatestream-block-length-does-not-match.html
                //See https://stackoverflow.com/questions/15351501/decode-base64-and-inflate-zlib-compressed-xml
                memStream.ReadByte();
                memStream.ReadByte();

                using (var deflate = new DeflateStream(memStream, CompressionMode.Decompress))
                {
                    StreamReader stream = new StreamReader(deflate, Encoding.UTF8);//.ReadToEnd();
                    XDocument xmlDoc = XDocument.Load(stream);
                    return xmlDoc;
                }
            }

        }
    }
}
