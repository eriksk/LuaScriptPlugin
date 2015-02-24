using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Duality;
using Duality.Editor;
using LuaScriptPlugin.Resources;

namespace LuaScriptPlugin.Editor.Importers
{
    public class LuaScriptImporter : IFileImporter
    {
        public bool CanImportFile(string srcFile)
        {
            string ext = Path.GetExtension(srcFile).ToLower();
            return ext == LuaScript.RawFileExt;
        }

        public string[] GetOutputFiles(string srcFile, string targetName, string targetDir)
        {
            string targetResPath = PathHelper.GetFreePath(Path.Combine(targetDir, targetName), LuaScript.FileExt);
            return new string[] {targetResPath};
        }

        public void ImportFile(string srcFile, string targetName, string targetDir)
        {
            string[] output = this.GetOutputFiles(srcFile, targetName, targetDir);

            var data = new LuaScript();
            data.LoadFile(srcFile);
            data.Save(output.First());
        }

        public bool CanReImportFile(ContentRef<Resource> r, string srcFile)
        {
            return CanImportFile(srcFile);
        }

        public bool IsUsingSrcFile(ContentRef<Resource> r, string srcFile)
        {
            return r.As<LuaScript>() != null && r.Res.SourcePath == srcFile;
        }

        public void ReImportFile(ContentRef<Resource> r, string srcFile)
        {
            var f = r.Res as LuaScript;

            if (f != null)
                f.LoadFile(srcFile);
        }
    }
}
