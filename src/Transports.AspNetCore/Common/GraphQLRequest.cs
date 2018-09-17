using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GraphQL.Server.Transports.AspNetCore.Common
{
    public class GraphQLRequest
    {
        public const string QueryKey = "query";
        public const string VariablesKey = "variables";
        public const string OperationNameKey = "operationName";

        [JsonProperty(QueryKey)]
        public string Query { get; set; }

        [JsonProperty(VariablesKey)]
        public JObject Variables { get; set; }

        [JsonProperty(OperationNameKey)]
        public string OperationName { get; set; }

        public Inputs GetInputs()
        {
            return GetInputs(Variables, Files);
        }

        public static Inputs GetInputs(JObject variables, IEnumerable<byte[]> files)
        {
            Inputs inputs = variables?.ToInputs();
            inputs.Add("files", files);

            return inputs;
        }

        public IEnumerable<byte[]> Files { get; set; }
    }
}
