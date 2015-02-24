<root dataType="Struct" type="LuaScriptPlugin.Resources.LuaScript" id="129723834">
  <_content dataType="String">-- Wiggle.lua
import ('OpenTK')

local time = 0.0;

function start()
end

function update(delta)
	time = time + delta;
	gameObject.Transform.Angle = math.sin(time * 0.01); 
end</_content>
  <sourcePath dataType="String">Source\Media\Scripts\Wiggle.lua</sourcePath>
</root>
<!-- XmlFormatterBase Document Separator -->
