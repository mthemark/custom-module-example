using ConflictingReferencesExample.Models;
using ConflictingReferencesExample.Services;
using DecisionsFramework.Design.Flow;
using System.Diagnostics;

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
    public string GetConflictingReferenceProductVersions()
    {
        var list = new List<FileVersionInfo>
        {
            FileVersionInfo.GetVersionInfo(typeof(System.Drawing.Bitmap).Assembly.Location),
            FileVersionInfo.GetVersionInfo(typeof(System.Security.Cryptography.PbeParameters).Assembly.Location),
            FileVersionInfo.GetVersionInfo(typeof(System.Security.Cryptography.Xml.DataObject).Assembly.Location),
            FileVersionInfo.GetVersionInfo(typeof(System.ServiceModel.BasicHttpBinding).Assembly.Location),
        };
        return list.Select(a => $"{a.InternalName} {a.ProductVersion} {a.FileVersion}").Aggregate((a,b)=>$"{a}\r\n{b}");
    }

    public int Add(int x, int y) => AddAsync(x, y).Result;
    public async Task<int> AddAsync(int x, int y) => await calcService!.AddAsync(x, y);
    public int Divide(int x, int y) => DivideAsync(x, y).Result;
    public async Task<int> DivideAsync(int x, int y) => await calcService!.DivideAsync(x, y);
    public int Multiply(int x, int y) => MultiplyAsync(x, y).Result;
    public async Task<int> MultiplyAsync(int x, int y) => await calcService!.MultiplyAsync(x, y);
    public int Subtract(int x, int y) => SubtractAsync(x, y).Result;
    public async Task<int> SubtractAsync(int x, int y) => await calcService!.SubtractAsync(x, y);
}
