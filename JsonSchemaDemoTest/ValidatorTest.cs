﻿
using System.Text;
using JsonNetSchemaValidation;
using JsonSchemaDemoLib;
using Xunit;


namespace JsonSchemaDemoTest
{
    public class ValidatorTest
    {
        [Fact]
        public void JsonSchemaTestValidCase()
        {
            var validator = new JsonSchemaDemoLib.Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(validator.IsValid(Encoding.UTF8.GetString(test_data.data_sample1),out message));
            Assert.Equal("Validation Succeeded.", message);
            
        }

        [Fact]
        public void JsonSchemaTestInvalidCase()
        {
            var validator = new JsonSchemaDemoLib.Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(!validator.IsValid(Encoding.UTF8.GetString(test_data.invalid_data_sample1), out message));
            Assert.Equal("Some error message at least", message);
        }

        [Fact]
        public void JsonNetSchemaTestValidCase()
        {
            var validator = new JsonNetSchemaValidation.Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(validator.IsValid(Encoding.UTF8.GetString(test_data.data_sample1), out message));
            Assert.Equal("Validation Succeeded.", message);
        }

        [Fact]
        public void JsonNetSchemaTestInvalidCase()
        {
            var validator = new JsonNetSchemaValidation.Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(!validator.IsValid(Encoding.UTF8.GetString(test_data.invalid_data_sample1), out message));
            var expectedError = "Validation Errors: Integer -1 is less than minimum value of 0. Line 4, position 12.| ";
            Assert.Equal(expectedError, message);
        }
    }
}
