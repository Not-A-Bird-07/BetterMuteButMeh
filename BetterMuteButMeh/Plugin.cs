using BepInEx;
using BetterMuteButMeh.Hooks;

namespace BetterMuteButMeh
{
    [BepInPlugin(Plugin_Info.GUID, Plugin_Info.NAME, Plugin_Info.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;

        public Plugin()
        {
            VRRigHooks.Hook();
            VRRigSerializerHooks.Hook();
        }
        
        public void Awake() => Instance = this;

        public bool IsModded()
        {
            if (NetworkSystem.Instance.GameModeString.Contains("MODDED")) return true;
            
            return false;
        }
    }
}