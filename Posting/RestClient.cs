using Posting.Authenticate_With;
using Posting.Authentication_Type;
using Posting.Http_Methods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Posting
{
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpMethods HttpMethod { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public AuthenticationVia AuthenticationVia { get; set; }
        public string PostJSON { get; set; }


        //------------------------------------------------
        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpMethods.GET;
        }

        //-------------------------------------------------

        public string MakeRequest()
        {
            string responseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = HttpMethod.ToString();

            String authHeader = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(UserName + ":" + Password));
            request.Headers.Add("Authorization", "Basic" + authHeader);

            if (request.Method == "POST" && PostJSON != string.Empty)
            {
                request.ContentType = "application/json";
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(PostJSON);
                    writer.Close();
                }
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                responseValue = "{\"errorMessages\":[\"" + exc.Message.ToString() + "\"],\"errors\":{}}";
            }

            return responseValue;
        }
    }
}
