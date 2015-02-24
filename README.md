# Lua Script Plugin for Duality

This is a Lua script plugin for the [Game Framework Duality](http://duality.adamslair.net)

## Installation

1. Open Duality
2. File -> Manage Packages
3. View "Online Repository"
4. Select "Lua Script Core Plugin" and click "install".
4. Select "Lua Script Editor Plugin" and click "install".
5. Click "Apply"
6. Done!

## Usage

1. Create a GameObject
2. Add a LuaScriptExecutor Component
3. Create a LuaScript Resource in the resource view (or just drop a .lua file in there)
4. Drag the LuaScript resource to the "Script" property on the "LuaScriptExecutor" component.
5. Run!

You can also just create an empty LuaScript resource and open it in a texteditor. This will generate a default script that is pretty self explanatory (with comments).

**Good luck, have fun!**

Here's a sample script:

_Start & update functions are called automatically for the script_

	-- Lua Script
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
	end