<root dataType="Struct" type="LuaScriptPlugin.Resources.LuaScript" id="129723834">
  <_content dataType="String">-- Lua Script
-- Import namespaces to use CLR objects
import ('OpenTK')

-- The attached GameObject for this component is already available as a local named gameObject

-- Called in OnInitialize of the component
function start()
end

-- Called in OnUpdate of the component, override LuaScriptExecutor to change passed delta
function update(delta)
	-- example: Move the gameObject to the right by delta time
	gameObject.Transform:MoveBy(Vector2(1, 0) * delta);
end

-- Function ready to be called by overriding LuaScriptExecutorComponent and using "Engine.CallMethod("my_custom_function", 123);"
-- Remove if you don't want it
function my_custom_function(number)
	-- TODO: do something
end</_content>
  <sourcePath dataType="String">Source\Media\Scripts\Default.lua</sourcePath>
</root>
<!-- XmlFormatterBase Document Separator -->
