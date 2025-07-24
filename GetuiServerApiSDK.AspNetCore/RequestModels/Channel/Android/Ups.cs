using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using GetuiServerApiSDK.AspNetCore.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetuiServerApiSDK.AspNetCore.RequestModels.Channel.Android
{
    public class Ups
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Notification Notification { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Transmission { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PreserveKeysConverter))]
        public Dictionary<string, Dictionary<string, object>> options { get; set; }
    }
}