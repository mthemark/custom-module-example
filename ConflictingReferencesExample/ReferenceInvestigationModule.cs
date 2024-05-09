using ConflictingReferencesExample.Models;
using DecisionsFramework.Design.Flow;
using System.Reflection;

namespace ConflictingReferencesExample;

[AutoRegisterMethodsOnClass(true, "ConflictingReferencesv" + IDecisionsModule.Version, nameof(ReferenceInvestigationModule))]
public class ReferenceInvestigationModule : DecisionsModule
{
    public override string GetAssemblyFullName() => typeof(DecisionsModule).Assembly.FullName!;

    static IList<string> skipLibraryList = new List<string>
    {
        "System",
        "netstandard",
    };
    static IList<string> keepContextList = new List<string>
    {
        "DecisionsFramework",
    };
    [AutoRegisterMethod("GetDllInfoForDirectory")]
    public static IEnumerable<DllInfo> GetDllInfoForDirectory(string path) =>
        Directory.GetFileSystemEntries(path, "*.dll").Select(GetDllInfoWithReferences).ToList();

    [AutoRegisterMethod("GetDllInfo")]
    public static DllInfo GetDllInfo(string filepath, bool getRefs)
    {
        var path = Path.GetFullPath(filepath);
        try
        {
            var asm = Assembly.LoadFile(path);
            var items = (getRefs) ? asm.GetReferencedAssemblies().Select(a => GetDllInfo(a, getRefs)).ToList() : new List<DllInfo>();
            return new DllInfo { FullName = asm!.FullName!, Location = asm.Location, ReferencedAssemblies = items };
        }
        catch (Exception ex)
        {
            return new DllInfo { FullName = "Error Loading Assembly", Location = path, Exception = ex.Message };
        }
    }

    static DllInfo GetDllInfoWithReferences(string filepath) => GetDllInfo(filepath, true);

    static Dictionary<string, DllInfo> cache = new Dictionary<string, DllInfo>();
    static DllInfo GetDllInfo(AssemblyName name, bool getRefs)
    {
        if (cache.ContainsKey(name.FullName))
            return cache[name.FullName];
        try
        {
            if (skipLibraryList.Any(name.Name!.StartsWith))
                cache.Add(name.FullName, new DllInfo { FullName = name.FullName, });
            else
            {
                var asm = Assembly.Load(name);
                cache.Add(name.FullName, GetDllInfo(asm.Location, getRefs));
            }
        }
        catch (Exception ex)
        {
            cache.Add(name.FullName, new DllInfo { FullName = name.FullName, Exception = ex.Message });
        }
        return cache[name.FullName];
    }

    [AutoRegisterMethod("GetFlattenedReferences")]
    public static List<string> GetFlattenedReferences(DllInfo dllInfo, string context = "")
    {
        var list = new List<string> { };
        if (string.IsNullOrEmpty(context))
            context = dllInfo.FullName.Split(",").First();
        list.Add($"{context} - {dllInfo.FullName}[{dllInfo.Location}]");

        if (!keepContextList.Any(context.StartsWith))
            context = dllInfo.FullName.Split(",").First();

        if (dllInfo.ReferencedAssemblies.Count > 0)
            foreach (var asm in dllInfo.ReferencedAssemblies)
                list.AddRange(GetFlattenedReferences(asm, context));
        return list.Distinct().Order().ToList();
    }
}
