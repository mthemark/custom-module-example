using DecisionsFramework.Design.Flow;

namespace ConflictingReferencesExample.Models;

public interface IDecisionsModule
{
    /// <summary>
    /// Replaced at build time to version 
    /// </summary>
    public const string Version = "1.8";
    [AutoRegisterMethod("GetVersionedName")]
    string GetAssemblyFullName();
}
