using ServiceReference;

namespace ConflictingReferencesExample.Services;

public class CalcService(CalculatorSoapClient client) : object(), ICalcService
{
    public async Task<int> AddAsync(int x, int y)
    {
        return await client.AddAsync(x, y);
    }
    public async Task<int> DivideAsync(int x, int y)
    {
        return await client.DivideAsync(x, y);
    }
    public async Task<int> MultiplyAsync(int x, int y)
    {
        return await client.MultiplyAsync(x, y);
    }
    public async Task<int> SubtractAsync(int x, int y)
    {
        return await client.SubtractAsync(x, y);
    }
}
