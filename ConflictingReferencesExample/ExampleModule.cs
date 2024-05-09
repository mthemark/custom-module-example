using ConflictingReferencesExample.Models;
using ConflictingReferencesExample.Services;
using DecisionsFramework.Design.Flow;

namespace ConflictingReferencesExample;

[AutoRegisterMethodsOnClass(true, "ConflictingReferencesv" + IDecisionsModule.Version, nameof(ExampleModule))]
public class ExampleModule : DecisionsModule
//public class ExampleModule(ServiceReference.CalculatorSoapClient.EndpointConfiguration endpointConfiguration) : DecisionsModule
{
    readonly CalcService? calcService;
    public ExampleModule() : this(ServiceReference.CalculatorSoapClient.EndpointConfiguration.CalculatorSoap) { }
    public ExampleModule(ServiceReference.CalculatorSoapClient.EndpointConfiguration endpointConfiguration)
    {
        calcService = new CalcService(new ServiceReference.CalculatorSoapClient(endpointConfiguration));
    }
    public override string GetAssemblyFullName() => typeof(DecisionsModule).Assembly.FullName!;
    public int Add(int x, int y) => AddAsync(x, y).Result;
    public async Task<int> AddAsync(int x, int y) => await calcService!.AddAsync(x, y);
    public int Divide(int x, int y) => DivideAsync(x, y).Result;
    public async Task<int> DivideAsync(int x, int y) => await calcService!.DivideAsync(x, y);
    public int Multiply(int x, int y) => MultiplyAsync(x, y).Result;
    public async Task<int> MultiplyAsync(int x, int y) => await calcService!.MultiplyAsync(x, y);
    public int Subtract(int x, int y) => SubtractAsync(x, y).Result;
    public async Task<int> SubtractAsync(int x, int y) => await calcService!.SubtractAsync(x, y);
}
