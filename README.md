# ONI Metadata File Generator
Provides a MSBuild task to automatically generate mod.yaml and mod_info.yaml for Oxygen Not Included mods.

Usage:

```xml
  <Target Name="GenerateMetadataFiles" BeforeTargets="Build">
    <GenerateMetadataFiles
      OutputPath="$(TargetDir)"

      Title="$(ModName)"
      Description="$(ModDescription)"
      StaticID="$(AssemblyName)"
      
      SupportedContent="$(SupportedContent)"
      MinimumSupportedBuild="$(MinimumSupportedBuild)"
      Version="$(FileVersion)"
      APIVersion="$(APIVersion)"
    />
  </Target>
 ```
