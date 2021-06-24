/*
   MIT License

   Copyright(c) 2021 Cairath

   Permission is hereby granted, free of charge, to any person obtaining a copy
   of this software and associated documentation files (the "Software"), to deal
   in the Software without restriction, including without limitation the rights
   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
   copies of the Software, and to permit persons to whom the Software is
   furnished to do so, subject to the following conditions:
   
   The above copyright notice and this permission notice shall be included in all
   copies or substantial portions of the Software.
   
   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
   SOFTWARE.
*/
 
using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using YamlDotNet.Serialization;

namespace ONIMetadataFileGenerator
{
	public class GenerateMetadataFiles : Task
	{
		[Required]
		public string OutputPath { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public string StaticID { get; set; }

		[Required]
		public string SupportedContent { get; set; }

		[Required]
		public int MinimumSupportedBuild { get; set; }

		public string Version { get; set; }

		[Required]
		public int APIVersion { get; set; }

		public override bool Execute()
		{

			var mod = new Mod
			{
				title = Title,
				description = Description,
				staticID = StaticID
			};

			var modInfo = new ModInfo
			{
				supportedContent = SupportedContent,
				minimumSupportedBuild = MinimumSupportedBuild,
				APIVersion = APIVersion,
				version = Version
			};

			var serializer = new SerializerBuilder().Build();
			var modYaml = serializer.Serialize(mod);
			var modInfoYaml = serializer.Serialize(modInfo);

			var modPath = Path.Combine(OutputPath, "mod.yaml");
			var modInfoPath = Path.Combine(OutputPath, "mod_info.yaml");

			try
			{
				File.WriteAllText(modPath, modYaml);
				File.WriteAllText(modInfoPath, modInfoYaml);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}
