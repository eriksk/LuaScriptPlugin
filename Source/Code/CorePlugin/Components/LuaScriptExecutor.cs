using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duality;
using LuaScriptPlugin.Lua;
using LuaScriptPlugin.Resources;
using OpenTK;

namespace LuaScriptPlugin.Components
{
    [Serializable]
    public class LuaScriptExecutor : Component, ICmpInitializable, ICmpUpdatable
    {
        public ContentRef<LuaScript> Script { get; set; }

        [NonSerialized]
        private LuaExecutionEngine _engine;

        protected virtual float Delta 
        {
            get { return Time.MsPFMult*Time.TimeMult; }
        }

        protected LuaExecutionEngine Engine
        {
            get { return _engine; }
        }

        public virtual void OnInit(InitContext context)
        {
            if (!Script.IsAvailable) return;

            _engine = new LuaExecutionEngine(Script.Res.Content);

            _engine.SetLocal(GameObj, "gameObject");
            
            if(_engine.HasMethod("start"))
                _engine.CallMethod("start");

        }

        public virtual void OnUpdate()
        {
            if (_engine == null) return;

            if (_engine.HasMethod("update"))
                _engine.CallMethod("update", Delta);
        }

        public void OnShutdown(ShutdownContext context)
        {
        }
    }
}
