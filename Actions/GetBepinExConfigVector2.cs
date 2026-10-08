using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;
using UnityEngine;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [UnityEngine.Tooltip("Vector2 Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigVector2 : GetBepinExConfigValue<Vector2>
    {

        public new FsmVector2 storeVariable;

        public override void DoGetValue()
        {
            if (config.TryGetEntry<Vector2>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<Vector2> value))
                storeVariable.Value = value.Value;
        }

    }
}
