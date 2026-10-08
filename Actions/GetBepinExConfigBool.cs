using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Bool Bepin Ex configuration retrieval action")]
    internal class GetBepinExConfigBool : GetBepinExConfigValue<bool>
    {

        public new FsmBool storeVariable;

        public override void DoGetValue()
        {

        }

    }
}
