using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combined.Models;
using combined.Repository;
using combined.Services;
using TestStack.BDDfy;
using Xunit;

namespace CombinedTest
{
    public class CarManagerTest
    {
        private CarManager _manager;
        private Vehicle _vehicle;
        private IVehicleRepository _repository;
        private Action _action;

        [Fact]
        public async void TestAddNewCar()
        {
            this.Given(s => s.RepositoryIsEmpty())
                .When(s => s.NewCarIsAddedAsync())
                .Then(s => s.RepositoryContainsNewCar())
                .BDDfy();
        }

        [Fact]
        public async void TestCarExists()
        {
            this.Given(s => s.RepositoryIsEmpty())
                .When(s => s.NewCarIsAddedAsync())
                .Then(s => s.AddingSameCarFails())
                .BDDfy();
        }

        private async void AddingSameCarFails()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(NewCarIsAddedAsync);
        }

        private void RepositoryContainsNewCar()
        {
            Assert.True(_repository.Vehicles.Any(x => x == _vehicle) == true);
        }

        private async Task NewCarIsAddedAsync()
        {
            _vehicle = await _manager.CreateAsync(new Dictionary<string, string>
            {
                {VehiclePropertyConstants.Make, "BMW"},
                {VehiclePropertyConstants.Model, "525i"},
                {VehiclePropertyConstants.Engine, "v8"},
                {VehiclePropertyConstants.Doors, "1"},
                {VehiclePropertyConstants.Wheels, "4"},
                {VehiclePropertyConstants.BodyType, "Sedan"}
            });
        }
        
        private void RepositoryIsEmpty()
        {
            _repository = new InMemoryVehicleRepository();
            _manager = new CarManager(_repository, new StaticVehicleTypeRegisters());
        }
    }
}