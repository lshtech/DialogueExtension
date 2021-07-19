using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Harmony;
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace DialogueExtension.Patches.Utility
{
  public interface IHarmonyWrapper
  {
    void Create(string id);
    void PatchAll();
    void PatchAll(Assembly assembly);
    DynamicMethod Patch(MethodBase original, HarmonyMethod prefix = null,
      HarmonyMethod postfix = null, HarmonyMethod transpiler = null);
    void UnpatchAll(string harmonyId = null);
    void Unpatch(MethodBase original, HarmonyPatchType type, string harmonyId = null);
    void Unpatch(MethodBase original, MethodInfo patch);
    bool HasAnyPatches(string harmonyId);
    Harmony.Patches GetPatchInfo(MethodBase method);
    IEnumerable<MethodBase> GetPatchedMethods();
    Dictionary<string, Version> VersionInfo(out Version currentVersion);
  }
  public class HarmonyWrapper : IHarmonyWrapper
  {
    private HarmonyInstance _harmonyInstance;

    public void Create(string id) => _harmonyInstance = HarmonyInstance.Create(id);

      public void PatchAll() => 
      _harmonyInstance.PatchAll();

    public void PatchAll(Assembly assembly) => 
      _harmonyInstance.PatchAll(assembly);

    public DynamicMethod Patch(MethodBase original, HarmonyMethod prefix = null, 
      HarmonyMethod postfix = null, HarmonyMethod transpiler = null) => 
      _harmonyInstance.Patch(original, prefix, postfix, transpiler);

    public void UnpatchAll(string harmonyId = null) => 
      _harmonyInstance.UnpatchAll(harmonyId);

    public void Unpatch(MethodBase original, HarmonyPatchType type, string harmonyId = null) =>
      _harmonyInstance.Unpatch(original, type, harmonyId);

    public void Unpatch(MethodBase original, MethodInfo patch) => 
      _harmonyInstance.Unpatch(original, patch);

    public bool HasAnyPatches(string harmonyId) => 
      _harmonyInstance.HasAnyPatches(harmonyId);

    public Harmony.Patches GetPatchInfo(MethodBase method) => 
      _harmonyInstance.GetPatchInfo(method);

    public IEnumerable<MethodBase> GetPatchedMethods() => 
      _harmonyInstance.GetPatchedMethods();

    public Dictionary<string, Version> VersionInfo(out Version currentVersion) =>
      _harmonyInstance.VersionInfo(out currentVersion);
  }
}
