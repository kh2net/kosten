using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using kosten.Models;
using SHA3.Net;

namespace kosten.Rest.Security
{
    public class LoginRestService : RestClient
    {
        private const string LoginApi = "login";
        private const string VerifyTokenApi = "verifyToken";
        private const string ChangePasswordApi = "changePassword";

        //LOGIN
        /// <summary>
        /// Login procedure
        /// </summary>
        /// <param name="username">Username inserted by user</param>
        /// <param name="password">Password inserted by user</param>
        /// <returns>TRUE if HttpResonse is successful (code 200), FALSE otherwise</returns>
        public async Task<bool> LoginAsync(string username, string password)
        {
            bool isPresent = false;

            try
            {
                //Password encrypted
                String sb = EncryptPassword(password);

                var json = $"{{\"username\":\"{username}\",\"password\":\"{sb}\"}}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await Client.PostAsync(LoginApi, content);
           
                //If data are correct...
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    isPresent = true;

                    //Extract the token and the id from response body
                    var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

                    //Set the authorization type of client
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

                    //Save token, id, password and current user role permanently
                    Settings.AuthenticationToken = user.Token;
                    Settings.UserId = user.Id;
                    Settings.Password = password;
                    Settings.CurrentUserRole = user.Roles[0];
                }
            }catch (Exception e){
                Debug.WriteLine(@"				ERROR{0}", e);
            }
            return isPresent;
        }

        //VERIFY TOKEN
        /// <summary>
        /// Check if token is still valid or present.
        /// </summary>
        /// <param name="token">Token to check</param>
        /// <returns>TRUE if token is valid, FALSE otherwise</returns>
        public async Task<bool> VerifyToken(string token)
        {
            bool tokenPresent = false;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var json = $"{{\"token\":\"{token}\"}}";
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await Client.PostAsync(VerifyTokenApi, content);
                    if (response.IsSuccessStatusCode)
                    {
                        tokenPresent = true;
                        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                }catch (Exception e){
                    Debug.WriteLine(@"				ERROR{0}", e);
                }
            }
            return tokenPresent;
        }

        //CHANGE PASSWORD
        /// <summary>
        /// Change password procedure
        /// </summary>
        /// <param name="oldPassword">Password to change</param>
        /// <param name="newPassowrd">New Password to set</param>
        /// <returns>TRUE if password is correctly changed, FALSE otherwise</returns>
        public async Task<bool> ChangePassword(string oldPassword, string newPassowrd)
        {
            String oldPass = EncryptPassword(oldPassword);
            String newPass = EncryptPassword(newPassowrd);
            bool correctChange = false;
            try
            {
                var json = $"{{\"passwordNew\":\"{newPass}\",\"passwordOld\":\"{oldPass}\"}}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync(ChangePasswordApi, content);
                correctChange = true;
            }catch(Exception e){
                Debug.WriteLine(@"				ERROR{0}", e);
            }
            return correctChange;
        }

        /// <summary>
        /// Encrypting method using SHA-512 algorithm
        /// </summary>
        /// <param name="password">Password to encrypt</param>
        /// <returns>Encrypted password</returns>
        public String EncryptPassword(string password)
        {
            Sha3 sha512 = Sha3.Sha3512();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = sha512.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2").ToLower());
            }
            return sb.ToString();
        }
    }
}
