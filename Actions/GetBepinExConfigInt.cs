using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Int Bepin Ex configuration retrieval action")]
    public class GetBepinExConfigInt : GetBepinExConfigValue<int>
    {

        public new FsmInt storeVariable;

        public override void DoGetValue()
        {

        }

    }
}
