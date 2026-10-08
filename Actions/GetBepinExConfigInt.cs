using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Int Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigInt : GetBepinExConfigValue<int>
    {

        public new FsmInt storeVariable;

        public override void DoGetValue()
        {
            if (config.TryGetEntry<int>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<int> value))
                storeVariable.Value = value.Value;
        }

    }
}
