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

        public static Inputs GetInputs(JObject variables, IDictionary<string, byte[]> files)
        {
            Inputs inputs = variables?.ToInputs();

            if (files != null)
            {
                foreach (var file in files)
                {
                    inputs[file.Key] = file.Value;
                }
            }

            return inputs;
        }

        public IDictionary<string, byte[]> Files { get; set; }
    }
}
