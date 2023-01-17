using System;
using BepInEx;
using UnityEngine.InputSystem;

namespace CcDemoSkeletonKey
{
    [BepInPlugin(PluginInfo.PluginGuid, PluginInfo.PluginName, PluginInfo.PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PluginGuid} is loaded!");
        }

        private void Update()
        {
            if (Keyboard.current.uKey.wasPressedThisFrame)
            {
                Logger.LogInfo("Opening doors...");
                var doors = FindObjectsOfType<CcDoor>();
                foreach (var ccDoor in doors)
                {
                    ccDoor.locked = false;
                    ccDoor.OpenDoor();
                }
                Logger.LogInfo("Opening vents...");
                var vents = FindObjectsOfType<CcVentDoor>();
                foreach (var ccVentDoor in vents)
                {
                    ccVentDoor.isLocked = false;
                    ccVentDoor.OpenDoor();
                }
            }
        }
    }
}