using DecisionsFramework.Design.Flow;

namespace CustomModule.Models;

public interface IDecisionsModule
{
    /// <summary>
    /// Replaced at build time to version 
    /// </summary>
    public const string Version = "1.0";
    [AutoRegisterMethod("GetVersionedName")]
    string GetAssemblyFullName();
}
