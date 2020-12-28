using System;
using System.Text.Json;

using Json.Schema;


namespace JsonSchemaDemoLib
{
    public class Validator
    {
        public string Schema { get; set; }
        public bool IsValid(string data, out string result)
        {
            if (!string.IsNullOrWhiteSpace(Schema))
            {
                var doc = JsonDocument.Parse(data);
                JsonSchema schema = JsonSchema.FromText(Schema);

                var validationResult = schema.Validate(doc.RootElement);

                result = validationResult.IsValid ? "Validation Succeeded." : validationResult.Message;
                return validationResult.IsValid;
            }
            else
            {
                throw new Exception("Schema not set");
            }
        }
    }
}
