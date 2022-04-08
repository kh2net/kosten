using System;
using Newtonsoft.Json;
using kosten.Support;

namespace kosten.Models.Base
{
    public class CategoryBase : BaseBindableObject
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
        
        boolean active;
        [JsonProperty(PropertyName = "Active")]
        public boolean Active
        {
            get { return active; }
            set { SetValue(ref active, value); }
        }
        
        string titel;
        [JsonProperty(PropertyName = "Titel")]
        public string Titel
        {
            get { return titel; }
            set { SetValue(ref titel, value); }
        }
        
        string[] parent;
        [JsonProperty(PropertyName = "Parent")]
        public string[] Parent
        {
            get { return parent; }
            set { SetValue(ref parent, value); }
        }
        
        public string QualifiedName
        {
            get { return $" { Titel }"; }
        }
    }
}