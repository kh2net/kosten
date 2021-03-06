using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kosten.Rest.Security
{
    public class TokenExpiredHandler : DelegatingHandler
    {
        #region Constants

        public static readonly string TOKEN_EXPIRED_MESSAGE = "TokenExpired";

        #endregion

        public TokenExpiredHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();

            if (content.Equals("No Token Provided"))
                MessagingCenter.Send<TokenExpiredHandler, bool>(this, TOKEN_EXPIRED_MESSAGE, true);

            return response;
        }
    }
}
