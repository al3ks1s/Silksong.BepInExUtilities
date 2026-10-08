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

        }

    }
}
