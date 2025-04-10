using UnityEngine;
using On;

namespace BetterMuteButMeh.Hooks
{
    public class VRRigHooks
    {
        public static void Hook()
        {
            On.VRRig.PlaySplashEffect += PlaySplashEffectHook;
        }

        public static void UnHook()
        {
            On.VRRig.PlaySplashEffect -= PlaySplashEffectHook;
        }

        private static void PlaySplashEffectHook(On.VRRig.orig_PlaySplashEffect orig, VRRig self, Vector3 splashposition, Quaternion splashrotation, float splashscale, float boundingradius, bool bigsplash, bool enteringwater, PhotonMessageInfoWrapped info)
        {
            if (Plugin.Instance.IsModded())
            {
                GorillaNot.IncrementRPCCall(info, "RPC_PlaySplashEffect");
                return;
            }

            orig(self, splashposition, splashrotation, splashscale, boundingradius, bigsplash, enteringwater, info);
        }
    }
}