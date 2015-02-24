-- Wiggle.lua
import ('OpenTK')

local time = 0.0;

function start()
end

function update(delta)
	time = time + delta;
	gameObject.Transform.Angle = math.sin(time * 0.01); 
end