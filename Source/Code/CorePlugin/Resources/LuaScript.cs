using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Duality;
using Duality.Editor;

namespace LuaScriptPlugin.Resources
{
    [Serializable]
    public class LuaScript : Resource
    {
        public static string RawFileExt = ".lua";
        public new static readonly string FileExt = Resource.GetFileExtByType(typeof(LuaScript));

        protected string _content;

        private const string DefaultData = 
            "-- Lua Script\r\n" + 
            "-- Import namespaces to use CLR objects\r\n" + 
            "import ('OpenTK')\r\n" + 
            "\r\n" + 
            "-- The attached GameObject for this component is already available as a local named gameObject\r\n" + 
            "\r\n" + 
            "-- Called in OnInitialize of the component\r\n" + 
            "function start()\r\n" + 
            "end\r\n" + 
            "\r\n" + 
            "-- Called in OnUpdate of the component, override LuaScriptExecutor to change passed delta\r\n" + 
            "function update(delta)\r\n" + 
            "	-- example: Move the gameObject to the right by delta time\r\n" + 
            "	gameObject.Transform:MoveBy(Vector2(1, 0) * delta);\r\n" + 
            "end\r\n" + 
            "\r\n" + 
            "-- Function ready to be called by overriding LuaScriptExecutorComponent and using \"Engine.CallMethod(\"my_custom_function\", 123);\"\r\n" + 
            "-- Remove if you don't want it\r\n" + 
            "function my_custom_function(number)\r\n" + 
            "	-- TODO: do something\r\n" + 
            "end";

        public string Content
        {
            get { return _content; }
        }

        public void LoadFile(string srcFile)
        {
            SourcePath = srcFile;
            Reload();
        }

        private void Reload()
        {
            _content = File.ReadAllText(SourcePath);
        }

        public void SaveSource(string filePath)
        {
            if (filePath == null) filePath = sourcePath;

			// We're saving this data for the first time
            if (!IsDefaultContent && sourcePath == null) sourcePath = filePath;

            File.WriteAllText(filePath, _content ?? DefaultData);
        }
    }
}
