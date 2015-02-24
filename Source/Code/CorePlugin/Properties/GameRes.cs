/*
 * A set of static helper classes that provide easy runtime access to the games resources.
 * This file is auto-generated. Any changes made to it are lost as soon as Duality decides
 * to regenerate it.
 */
namespace GameRes
{
	public static class Data {
		public static class Scripts {
			public static Duality.ContentRef<LuaScriptPlugin.Resources.LuaScript> Default_LuaScript { get { return Duality.ContentProvider.RequestContent<LuaScriptPlugin.Resources.LuaScript>(@"Data\Scripts\Default.LuaScript.res"); }}
			public static Duality.ContentRef<LuaScriptPlugin.Resources.LuaScript> Wiggle_LuaScript { get { return Duality.ContentProvider.RequestContent<LuaScriptPlugin.Resources.LuaScript>(@"Data\Scripts\Wiggle.LuaScript.res"); }}
			public static void LoadAll() {
				Default_LuaScript.MakeAvailable();
				Wiggle_LuaScript.MakeAvailable();
			}
		}
		public static Duality.ContentRef<Duality.Resources.Scene> Scene_Scene { get { return Duality.ContentProvider.RequestContent<Duality.Resources.Scene>(@"Data\Scene.Scene.res"); }}
		public static void LoadAll() {
			Scripts.LoadAll();
			Scene_Scene.MakeAvailable();
		}
	}

}
