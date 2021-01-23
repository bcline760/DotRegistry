using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace DotRegistry.Contract.Provider
{
    public class ProviderVersionsEntity
    {
        [JsonProperty("versions", Required = Required.Always)]
        public List<ProviderVersionEntity> Versions { get; set; }
    }
}
