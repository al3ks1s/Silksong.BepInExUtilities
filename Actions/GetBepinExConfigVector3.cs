using HutongGames.PlayMaker;
using UnityEngine;

namespace BepInExUtilities.Actions
{
    [ActionCategory("BepInEx Utilities")]
    [UnityEngine.Tooltip("Vector3 Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigVector3 : GetBepinExConfigValue<Vector3>
    {

        public new FsmVector3 storeVariable;

        public override void DoGetValue()
        {

        }

    }
}
