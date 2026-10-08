using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("Al3ks1s Core")]
    [Tooltip("Int Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigBool : GetBepinExConfigValue<bool>
    {

        public new FsmBool storeVariable;

        public override void DoGetValue()
        {
            if (config.TryGetEntry<bool>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<bool> value))
                storeVariable.Value = value.Value;
        }

    }
}
