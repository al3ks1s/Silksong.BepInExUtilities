using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HutongGames.PlayMaker;

namespace BepInExUtilities.Actions
{

    [ActionCategory("BepInEx Utilities")]
    [Tooltip("Generic Bepin Ex configuration retrieval action, use specific typed actions for better stability")]
    public class GetBepinExConfigValue<T> : FsmStateAction
    {

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The plugin ID as defined in the main class.")]
        public string BepinExPluginID;

        [RequiredField]
        public string BepinExConfigSection;
        
        [RequiredField]
        public string BepinExConfigKey;

        public NamedVariable storeVariable;

        protected ConfigFile config;

        public override void Awake()
        {
            if (!Chainloader.PluginInfos.TryGetValue(BepinExPluginID, out var plugin))
            {
                base.Finish();
                return;
            }

            config = plugin.Instance.Config;        
        }

        public override void OnEnter()
        {
            DoGetValue();
            base.Finish();
        }

        public virtual void DoGetValue()
        {
            if (config.TryGetEntry<T>(BepinExConfigSection, BepinExConfigKey, out ConfigEntry<T> value))
                storeVariable.RawValue = value.Value;
        }

    }
}
