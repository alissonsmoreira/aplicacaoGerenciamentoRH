using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    [NotMapped]
    public class TokenModel
    {
        public override string ToString()
        {
            return AccessToken;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
    }
}