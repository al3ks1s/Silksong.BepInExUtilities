using BepInEx;

namespace BepInExUtilities
{
    // TODO - adjust the plugin guid as needed
    [BepInAutoPlugin(id: "io.github.al3ks1s.bepinexutilities")]
    public partial class BepInExUtilitiesPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Put your initialization logic here
            Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
        }
    }
}
