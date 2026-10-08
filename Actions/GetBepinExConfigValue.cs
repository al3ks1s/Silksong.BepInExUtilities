using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Generic Bepin Ex configuration retrieval action. This is a stub, use the type specific actions.")]
    public class GetBepinExConfigValue<T> : FsmStateAction
    {

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The plugin ID as defined in the main class.")]
        public string BepinExPluginID;

        [RequiredField]
        public string BepinExConfigSection;
        
        [RequiredField]
        public string BepinExConfigKey;

        // public NamedVariable storeVariable;

        public override void Awake()
        {
    
        }

        public override void OnEnter()
        {
            DoGetValue();
            base.Finish();
        }

        public virtual void DoGetValue()
        {

        }

    }
}
