using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Float Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigFloat : GetBepinExConfigValue<float>
    {

        public new FsmFloat storeVariable;

        public override void DoGetValue()
        {
            if (config.TryGetEntry<float>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<float> value))
                storeVariable.Value = value.Value;
        }

    }
}
