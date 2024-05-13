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
        public void GetConflictingReferenceProductVersions(EndpointConfiguration endpointConfiguration)
        {
            //Arrange
            ExampleModule exampleModule = new(endpointConfiguration);
            //Act
            var result = exampleModule.GetConflictingReferenceProductVersions();
            //Assert
            //result.Should().Contain("System.Security.Cryptography.Pkcs.dll6.0.5+70ae3df4a6f3c92fb6b315afc405edd10ff38579");//6.0.1
            result.Should().Contain("System.Drawing.Common.dll 6.0.0+4822e3c3aa77eb82b2fb33c9321f923cf11ddde6");//System.Drawing.Common.dll6.0.0+4822e3c3aa77eb82b2fb33c9321f923cf11ddde6 6.0.0
            result.Should().Contain("System.Security.Cryptography.Pkcs.dll 8.0.0+5535e31a712343a63f5d7d796cd874e563e5ac14");//System.Security.Cryptography.Pkcs.dll 8.0.0
            //result.Should().Contain("System.Security.Cryptography.Pkcs.dll6.0.19+e37fab9fc9f7bce120a7165491ed392a73f8ab51");//System.Security.Cryptography.Pkcs.dll 6.0.4
            result.Should().Contain("System.Security.Cryptography.Xml.dll 8.0.0+5535e31a712343a63f5d7d796cd874e563e5ac14");//System.Security.Cryptography.Xml.dll 8.0.0
            //result.Should().Contain("System.Security.Cryptography.Xml.dll6.0.8+55fb7ef977e7d120dc12f0960edcff0739d7ee0e");//System.Security.Cryptography.Xml.dll 6.0.1
            result.Should().Contain("System.Private.ServiceModel.dll 3.3.0");//System.Private.ServiceModel.dll 4.9.0
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