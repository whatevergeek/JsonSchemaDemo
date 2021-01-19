using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonNetSchemaValidation
{
    public class Validator
    {
        public string Schema { get; set; }
        public bool IsValid(string data, out string result)
        {
            if (!string.IsNullOrWhiteSpace(Schema))
            {
                var doc = JObject.Parse(data);
                JsonSchema schema = JsonSchema.Parse(Schema);

                IList<string> messages;
                bool isValid = doc.IsValid(schema, out messages);

                if (messages.Count > 0)
                {
                    result = "Validation Errors: ";
                    foreach (var errorMessage in messages)
                    {
                        result += $"{errorMessage}| ";
                    }
                }
                else
                {
                    result = "Validation Succeeded.";
                }

                return isValid;
            }
            else
            {
                throw new Exception("Schema not set");
            }
        }
    }
}
