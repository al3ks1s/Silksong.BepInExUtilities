using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("String Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigString : GetBepinExConfigValue<string>
    {

        public new FsmString storeVariable;

        public override void DoGetValue()
        {
            if (config.TryGetEntry<string>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<string> value))
                storeVariable.Value = value.Value;
        }

    }
}
