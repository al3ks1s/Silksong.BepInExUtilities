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

        }

    }
}
