using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using kosten.Models;
using Newtonsoft.Json;

namespace kosten.Rest.Base
{
    public class EintragRestServiceBase : RestClient
    {
        const string EintragApi = "eintrag/";

        //FindByCategory
        /// <summary>
        /// Get a  Eintrag using FindByCategory
        /// </summary>
        /// <returns>Eintrag</returns>
        public async Task<Eintrag> findByCategory(string id)
        {
            Eintrag eintrag = new Eintrag();
            try
            {
                var content = await Client.GetStringAsync(EintragApi + "findByCategory/" + id  );
                eintrag = JsonConvert.DeserializeObject<Eintrag>(content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"				ERROR {0}", e);
            }
            return eintrag;
        }
    }
}
