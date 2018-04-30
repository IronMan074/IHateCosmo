using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AzureCosmosDBA.Models
{
    public class Students
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Mobile")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "Telephone")]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
    }
}
