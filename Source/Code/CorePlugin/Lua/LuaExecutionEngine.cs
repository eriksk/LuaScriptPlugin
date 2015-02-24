using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuaScriptPlugin.Lua
{
    public class LuaExecutionEngine
    {
        private readonly string _script;
        private readonly NLua.Lua _lua;

        public LuaExecutionEngine(string script)
        {
            if (script == null) throw new ArgumentNullException("script");
            _script = script;
            _lua = new NLua.Lua();
            _lua.LoadCLRPackage();
            _lua.DoString(script);
        }

        public string OriginalScript 
        {
            get { return _script; }
        }

        public NLua.Lua Runtime 
        {
            get { return _lua; }
        }

        public string GetString(string name)
        {
            return _lua.GetString(name);
        }

        public float GetFloat(string name)
        {
            return (float)_lua.GetNumber(name);
        }

        public double GetDouble(string name)
        {
            return _lua.GetNumber(name);
        }

        public int GetInt(string name)
        {
            return (int)_lua.GetNumber(name);
        }

        public object[] CallMethod(string name, params object[] parameters)
        {
            var result = _lua.GetFunction(name).Call(parameters);
            return result;
        }

        public bool HasMethod(string name)
        {
            return _lua.GetFunction(name) != null;
        }

        public void SetLocal(object obj, string name)
        {
            _lua[name] = obj;
        }

        public void ShutDown()
        {
            _lua.Close();
        }

    }
}
