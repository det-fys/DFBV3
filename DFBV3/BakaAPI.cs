using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 {
    public class BakaAPI {
        private string _AccessToken;
        private string _RefreshToken;
        private string _Address;

        private static readonly HttpClient client = new HttpClient();

        public string getAccessToken() { return _AccessToken; }
        public string getRefreshToken() { return _RefreshToken; }

        public string Login(string Username, string Password, string Address) {
            dynamic loginResult;
            if (Username != "_REFRESH_LOGIN") 
                loginResult = ParsePOSTJSON(Address + "api/login", $"client_id=ANDR&grant_type=password&username={Username}&password={Password}");
            else
                loginResult = ParsePOSTJSON(Address + "api/login", $"client_id=ANDR&grant_type=refresh_token&refresh_token={Password}");

            if (loginResult == null)
                return "_http_error";

            if (loginResult["error"] != null)
                return loginResult["error_description"] | loginResult["error"];

            _AccessToken = loginResult["access_token"];
            _RefreshToken = loginResult["refresh_token"];
            _Address = Address;

            return null;
        }

        public dynamic GetModule(string SubURL, bool isSecondTry = false) {
            string respStr = "";

            try {
                var request = (HttpWebRequest)WebRequest.Create(_Address + SubURL);

                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add($"Authorization: Bearer {_AccessToken}");

                var response = (HttpWebResponse)request.GetResponse();
                respStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
            } catch {
                if (Login("_REFRESH_LOGIN", _RefreshToken, _Address) != null)
                    return null;

                return isSecondTry ? null : GetModule(SubURL, true);
            }

            //MessageBox.Show(respStr);
            //System.IO.File.WriteAllText("D:\\zbynda\\test.json", respStr);
            return JsonConvert.DeserializeObject(respStr);
        }

        private static string POSTReq(string URL, string POSTData) {
            try {
                var request = (HttpWebRequest)WebRequest.Create(URL);

                var data = Encoding.ASCII.GetBytes(POSTData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream()) {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            } catch {
                return "";
            }
        }

        private dynamic ParsePOSTJSON(string URL, string POSTData) {
            return JsonConvert.DeserializeObject(POSTReq(URL, POSTData));
        }
    }
}
