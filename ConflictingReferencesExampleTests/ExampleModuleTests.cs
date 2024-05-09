using ConflictingReferencesExample;
using FluentAssertions;
using static ServiceReference.CalculatorSoapClient;

namespace ConflictingReferencesExampleTests
{
    public class ExampleModuleTests
    {
        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public void GetAssemblyFullName(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            //Act
            var result = exampleModule.GetAssemblyFullName();
            //Assert
            result.Should().Contain(nameof(ConflictingReferencesExample));
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public void AddTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = exampleModule.Add(x, y);
            //Assert
            result.Should().Be(x + y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public async Task AddAsyncTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = await exampleModule.AddAsync(x, y);
            //Assert
            result.Should().Be(x + y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public void DivideTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = exampleModule.Divide(x, y);
            //Assert
            result.Should().Be(x / y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public async Task DivideAsyncTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = await exampleModule.DivideAsync(x, y);
            //Assert
            result.Should().Be(x / y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public void MultiplyTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = exampleModule.Multiply(x, y);
            //Assert
            result.Should().Be(x * y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public async Task MultiplyAsyncTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = await exampleModule.MultiplyAsync(x, y);
            //Assert
            result.Should().Be(x * y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public void SubtractTest(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = exampleModule.Subtract(x, y);
            //Assert
            result.Should().Be(x - y);
        }

        [Theory]
        [InlineData(EndpointConfiguration.CalculatorSoap)]
        [InlineData(EndpointConfiguration.CalculatorSoap12)]
        public async Task SubtractAsync(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            int x = 125;
            int y = 25;
            //Act
            var result = await exampleModule.SubtractAsync(x, y);
            //Assert
            result.Should().Be(x - y);
        }
    }
}