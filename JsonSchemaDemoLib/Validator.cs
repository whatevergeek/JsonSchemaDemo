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

                var options = new ValidationOptions { OutputFormat = OutputFormat.Detailed };
                var validationResult = schema.Validate(doc.RootElement, options);

                result = GetValidationResultMessage(validationResult);
                return validationResult.IsValid;
            }
            else
            {
                throw new Exception("Schema not set");
            }
        }

        private string GetValidationResultMessage(ValidationResults validationResult)
        {
            var resultMessage = string.Empty;
            if (validationResult.IsValid)
            {
                resultMessage = "Validation Succeeded.";
            }
            else if (validationResult.NestedResults.Count > 0)
            {
                resultMessage = "Validation Errors: ";
                foreach (var result in validationResult.NestedResults)
                {
                    resultMessage += $"{result.Message} found at {result.SchemaLocation.Source}| ";
                }
            }
            else
            {
                resultMessage = $"Validation Errors: {validationResult.Message} found at {validationResult.SchemaLocation.Source}| ";
            }

            return resultMessage;
        }

    }
}
