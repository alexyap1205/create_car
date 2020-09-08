using System.Collections.Generic;
using System.Runtime.CompilerServices;
using combined.Models;
using combined.Repository;
using combined.Services;
using TestStack.BDDfy;
using Xunit;

namespace CombinedTest
{
    public class CarValidatorTest
    {
        private StaticVehicleTypeRegisters _register;
        private CarValidator _validator;
        private Dictionary<string, string> _data;

        [Fact]
        public void ValidCase()
        {
            this.Given(s => s.StaticTypeRegisterIsUsed())
                .And(s => s.DoorsCountIsValid())
                .Then(s => s.ValidationSucceeds())
                .BDDfy();
        }

        [Fact]
        public void InvalidCase()
        {
            this.Given(s => s.StaticTypeRegisterIsUsed())
                .And(s => s.DoorsCountIsInvalid())
                .Then(s => s.ValidationFails())
                .BDDfy();
        }

        private void ValidationFails()
        {
            Assert.False(_validator.IsValid(_data));
        }

        private void DoorsCountIsInvalid()
        {
            _data = new Dictionary<string, string>
            {
                {VehiclePropertyConstants.Make, "BMW"},
                {VehiclePropertyConstants.Model, "525i"},
                {VehiclePropertyConstants.Engine, "v8"},
                {VehiclePropertyConstants.Doors, "1"},
                {VehiclePropertyConstants.Wheels, "4"},
                {VehiclePropertyConstants.BodyType, "Sedan"}
            };
        }

        private void ValidationSucceeds()
        {
            Assert.True(_validator.IsValid(_data));
        }

        private void DoorsCountIsValid()
        {
            _data = new Dictionary<string, string>
            {
                {VehiclePropertyConstants.Make, "BMW"},
                {VehiclePropertyConstants.Model, "525i"},
                {VehiclePropertyConstants.Engine, "v8"},
                {VehiclePropertyConstants.Doors, "2"},
                {VehiclePropertyConstants.Wheels, "4"},
                {VehiclePropertyConstants.BodyType, "Sedan"}
            };
        }

        private void StaticTypeRegisterIsUsed()
        {
            _register = new StaticVehicleTypeRegisters();
            _validator = new CarValidator(_register);
        }
    }
}