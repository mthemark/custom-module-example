using ConflictingReferencesExample.Models;
using DecisionsFramework.Design.Flow;

namespace ConflictingReferencesExample;

[AutoRegisterMethodsOnClass(true, "ConflictingReferencesExample" + "v" + IDecisionsModule.Version, "Example Module")]
public class ExampleModule : DecisionsModule
{
    public override string GetAssemblyFullName() => typeof(DecisionsModule).Assembly.FullName!;
}
