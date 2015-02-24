using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duality;
using Duality.Editor;
using LuaScriptPlugin.Resources;

namespace LuaScriptPlugin.Editor.Actions
{
    public class EditorActionOpenLuaFile : EditorSingleAction<Resource>
    {
        public override string Description
        {
            get { return "Open resource";  }
        }

        public override bool MatchesContext(string context)
        {
            return context == DualityEditorApp.ActionContextOpenRes;
        }

        public override void Perform(Resource obj)
        {
            var lua = obj as LuaScript;

            if(lua != null)
                FileImportProvider.OpenSourceFile(lua, LuaScript.RawFileExt, lua.SaveSource);
        }
    }
}
