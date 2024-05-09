namespace ConflictingReferencesExample.Services;

public interface ICalcService
{
    Task<int> AddAsync(int x, int y);
    Task<int> DivideAsync(int x, int y);
    Task<int> MultiplyAsync(int x, int y);
    Task<int> SubtractAsync(int x, int y);
}
