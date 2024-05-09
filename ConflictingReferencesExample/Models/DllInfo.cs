namespace ConflictingReferencesExample.Models;

public class DllInfo
{
    public string FullName { get; set; } = "";
    public string Location { get; set; } = "";
    public string? Exception { get; set; }
    internal List<DllInfo> ReferencedAssemblies { get; set; } = new List<DllInfo>();
    public List<string> ReferencedAssembliesList { get => ReferenceInvestigationModule.GetFlattenedReferences(this); }
}