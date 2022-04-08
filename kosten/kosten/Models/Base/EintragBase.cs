using System;
using Newtonsoft.Json;
using kosten.Support;

namespace kosten.Models.Base
{
    public class EintragBase : BaseBindableObject
    {
         // Id Start
		string _id;
		[JsonProperty(PropertyName = "_id")]
		public string Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}
		 // Id End 
        
        int amount;
        [JsonProperty(PropertyName = "Amount")]
        public int Amount
        {
            get { return amount; }
            set { SetValue(ref amount, value); }
        }
        
        DateTime date;
        [JsonProperty(PropertyName = "Date")]
        public DateTime Date
        {
            get { return date.ToLocalTime(); }
            set { SetValue(ref date, value); }
        }
        
        boolean deleted;
        [JsonProperty(PropertyName = "Deleted")]
        public boolean Deleted
        {
            get { return deleted; }
            set { SetValue(ref deleted, value); }
        }
        
        boolean done;
        [JsonProperty(PropertyName = "Done")]
        public boolean Done
        {
            get { return done; }
            set { SetValue(ref done, value); }
        }
        
        string titel;
        [JsonProperty(PropertyName = "Titel")]
        public string Titel
        {
            get { return titel; }
            set { SetValue(ref titel, value); }
        }
        
        string category;
        [JsonProperty(PropertyName = "Category")]
        public string Category
        {
            get { return category; }
            set { SetValue(ref category, value); }
        }
        
    }
}