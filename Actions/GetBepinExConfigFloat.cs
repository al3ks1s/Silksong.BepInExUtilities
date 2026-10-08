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

        }

    }
}
