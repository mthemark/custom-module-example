using DecisionsFramework.Design.Flow;

namespace CustomModule.Models;

public abstract class DecisionsModule : IDecisionsModule
{
    [AutoRegisterMethod("GetAssemblyFullName")]
    public abstract string GetAssemblyFullName();// => typeof(DecisionsModule).Assembly.FullName!;
}