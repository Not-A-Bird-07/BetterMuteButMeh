using Fusion;
using On;

namespace BetterMuteButMeh.Hooks
{
    public class VRRigSerializerHooks
    {
        public static void Hook()
        {
            VRRigSerializer.PlayHandTapShared += PlayHandTapSharedHook;
            VRRigSerializer.OnHandTapRPCShared += OnHandTapRPCSharedHook;
        }

        public static void UnHook()
        {
            VRRigSerializer.PlayHandTapShared -= PlayHandTapSharedHook;
            VRRigSerializer.OnHandTapRPCShared -= OnHandTapRPCSharedHook;
        }

        private static void OnHandTapRPCSharedHook(VRRigSerializer.orig_OnHandTapRPCShared orig, NetworkBehaviour self, 
            int surfaceindex, bool lefthanded, float handspeed, long packeddir, PhotonMessageInfoWrapped info)
        {
            if (Plugin.Instance.IsModded())
            {
                GorillaNot.IncrementRPCCall(info, "OnHandTapRPCShared");
                return;
            }
            
            orig(self, surfaceindex, lefthanded, handspeed, packeddir, info);
        }

        private static void PlayHandTapSharedHook(VRRigSerializer.orig_PlayHandTapShared orig, NetworkBehaviour self, int soundindex, bool islefthand, float tapvolume, PhotonMessageInfoWrapped info)
        {
            if (Plugin.Instance.IsModded())
            {
                GorillaNot.IncrementRPCCall(info, "PlayHandTapShared");
                return;
            }
            orig(self, soundindex, islefthand, tapvolume, info);
        }
    }
}