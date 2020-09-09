using System.Collections.Generic;
using combined.Models;
using combined.Services;
using Xunit;

namespace CombinedTest
{
    public class BasicSchemaValidatorTest
    {
        [Fact]
        public void ValidCase()
        {
            var vehicleType = new VehicleType("dummy", new List<CustomProperty>
            {
                new CustomProperty("StringProperty", CustomPropertyType.STRING),
                new CustomProperty("IntProperty", CustomPropertyType.INTEGER),
                new CustomProperty("BoolProperty", CustomPropertyType.BOOLEAN)
            });
            var validator = new BasicSchemaValidator(vehicleType);
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"StringProperty", "Value1"},
                {"IntProperty", "5"},
                {"BoolProperty", "false"},
                {"Make", "Make"},
                {"Model", "Model"}
            };
            Assert.True(validator.IsSchemaValid(data));
        }
        
        [Fact]
        public void MissingPropertyCase()
        {
            var vehicleType = new VehicleType("dummy", new List<CustomProperty>
            {
                new CustomProperty("StringProperty", CustomPropertyType.STRING),
                new CustomProperty("IntProperty", CustomPropertyType.INTEGER),
                new CustomProperty("BoolProperty", CustomPropertyType.BOOLEAN)
            });
            var validator = new BasicSchemaValidator(vehicleType);
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"StringProperty", "Value1"},
                {"IntProperty", "5"},
                {"Make", "Make"},
                {"Model", "Model"}
            };
            Assert.False(validator.IsSchemaValid(data));
        }
        
        [Theory]
        [InlineData("IntProperty", CustomPropertyType.INTEGER, "5F")]
        [InlineData("BoolProperty", CustomPropertyType.BOOLEAN, "5F")]
        public void InvalidTypeCase(string propertyName, CustomPropertyType type, string value)
        {
            var vehicleType = new VehicleType("dummy", new List<CustomProperty>
            {
                new CustomProperty(propertyName, type)
            });
            var validator = new BasicSchemaValidator(vehicleType);
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {propertyName, value},
                {"Make", "Make"},
                {"Model", "Model"}
            };
            Assert.False(validator.IsSchemaValid(data));
        }
    }
}