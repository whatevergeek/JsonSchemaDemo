
using System.Text;
using JsonSchemaDemoLib;
using Xunit;


namespace JsonSchemaDemoTest
{
    public class ValidatorTest
    {
        [Fact]
        public void TestValidCase()
        {
            var validator = new Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(validator.IsValid(Encoding.UTF8.GetString(test_data.data_sample1),out message));
            Assert.Equal("Validation Succeeded.", message);
            
        }

        [Fact]
        public void TestInvalidCase()
        {
            var validator = new Validator
            {
                Schema = Encoding.UTF8.GetString(test_data.schema_sample1)
            };

            string message = string.Empty;
            Assert.True(!validator.IsValid(Encoding.UTF8.GetString(test_data.invalid_data_sample1), out message));
            //Assert.Equal("Validation Succeeded.", message);
        }
    }
}
