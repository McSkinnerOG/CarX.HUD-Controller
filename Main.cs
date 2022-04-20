using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Binding.Components;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace HUD_Controller
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations] 
        public const string MODNAME = "HUD_Controller", AUTHOR = "", GUID = AUTHOR + "_" + MODNAME, VERSION = "1.0.0.0"; 
        internal readonly ManualLogSource log;
        internal readonly Harmony harmony;
        internal readonly Assembly assembly;
        public readonly string modFolder;
        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }
        #endregion 
        public void Start() { harmony.PatchAll(assembly); }
        public void Awake() { InitConfig(); }
        public static ConfigEntry<KeyCode> reload;
        public static ConfigEntry<KeyCode> KeyCode_MUTE;
        public void InitConfig() 
        {
            KeyCode_MUTE = Config.Bind("HUD", "Mute-Cam", KeyCode.G, "Mute all audio while in freecam.");
            reload = Config.Bind("HUD", "Reload", KeyCode.T, "Reload Colors"); 
            HUD.Speedometer.GEAR_D = Config.Bind("Gears", "Drive Gear", Color.white, "Drive Gear Color.");
            HUD.Speedometer.GEAR_N = Config.Bind("Gears", "Neutral Gear", new Color(0.5f, 0.5f, 0.5f, 1), "Neutral Gear Color.");
            HUD.Speedometer.GEAR_R = Config.Bind("Gears", "Race Gear", Color.red, "Race Gear :3 Color.");
            HUD.Speedometer.speed = Config.Bind("Speedometer", "Speed", Color.white, "Current Speed Color");
            HUD.Speedometer.distance = Config.Bind("Speedometer", "Distance", Color.white, "Odometer/Distance Driven");
            HUD.Speedometer.odometerPanel = Config.Bind("Speedometer", "Distance Panel", new Color(0f, 0f, 0f, 0.3843f), "Odometer Panel");
            HUD.Speedometer.zeroOff = Config.Bind("Speedometer", "Off Speed", new Color(127, 127, 127, 255), "Speed Off Zero's Color");
            HUD.Speedometer.Digits = Config.Bind("Speedometer", "Digits", new Color(1, 1, 1, 1), "RPM Marker Digits Color");

            HUD.Speedometer.speedoBG = Config.Bind("Speedometer", "SpeedoBG", new Color(0, 0, 0, 0.3569f), "Speedometer Background Color");
            HUD.Speedometer.pins = Config.Bind("Speedometer", "pins", new Color(0.5189f, 0.5189f, 0.5189f, 1), "Speedometer Marker Pins Color");
            HUD.Speedometer.speedUnit = Config.Bind("Speedometer", "SpeedUnit", Color.white, "Speed Unit Color");
            HUD.Speedometer.separator = Config.Bind("Speedometer", "Separator", Color.white, "Separator Color");
            HUD.Speedometer.handBrakeOff = Config.Bind("Speedometer", "HandBrakeOff", Color.white, "HandBrake Off Color");
            HUD.Speedometer.handBrakeOn = Config.Bind("Speedometer", "HandBrakeOn", Color.red, "HandBrake On Color");

            HUD.Speedometer.rPMFill_BG = Config.Bind("RPM", "RPMFill_BG", new Color(0, 0, 0, 0.502f), "RPM Background Color");
            HUD.Speedometer.rPMRedZone = Config.Bind("RPM", "RPMRedZone", new Color(1, 0.0047f, 0.1448f, 0.3137f), "RPM Redline Zone Color");
            HUD.Speedometer.rPMFillLine_White = Config.Bind("RPM", "RPMFillLine_White", Color.white, "RPM Fill Color");
            HUD.Speedometer.rPMFillLine_Red = Config.Bind("RPM", "RPMFillLine_Red", new Color(1f, 0f, 0.0396f, 1f), "RPM Redline Fill Color");
            
            HUD.PedalPanel.PanelBG = Config.Bind("Pedals", "PanelBG", new Color(0f, 0f, 0f, 0.4627f), " ");
            HUD.PedalPanel.SteerLeft = Config.Bind("Pedals", "SteerLeft", new Color(0f, 0.8003f, 0.9811f, 1f), " ");
            HUD.PedalPanel.SteerLeftBG = Config.Bind("Pedals", "SteerLeftBG", new Color(0f, 0f, 0f, 0.5882f), " ");
            HUD.PedalPanel.SteerRight = Config.Bind("Pedals", "SteerRight", new Color(0f, 0.8003f, 0.9811f, 1f), " ");
            HUD.PedalPanel.SteerRightBG = Config.Bind("Pedals", "SteerRightBG", new Color(0, 0, 0, 0.5882f), " ");
            HUD.PedalPanel.SteerHandle = Config.Bind("Pedals", "SteerHandle", new Color(1f, 1f, 1f, 1f), " ");

            HUD.PedalPanel.PedalAccel = Config.Bind("Pedals", "PedalAccel", new Color(0.1114f, 1f, 0f, 0.7059f), " ");
            HUD.PedalPanel.PedalAccelBG = Config.Bind("Pedals", "PedalAccelBG", new Color(0f, 0f, 0f, 0.5882f), " ");
            HUD.PedalPanel.PedalBrake = Config.Bind("Pedals", "PedalBrake", new Color(1f, 0.0966f, 0f, 1f), " ");
            HUD.PedalPanel.PedalBrakeBG = Config.Bind("Pedals", "PedalBrakeBG", new Color(0f, 0f, 0f, 0.5882f), " ");
            HUD.PedalPanel.PedalClutch = Config.Bind("Pedals", "PedalClutch", new Color(1f, 1f, 1f, 0.7608f), " ");
            HUD.PedalPanel.PedalClutchBG = Config.Bind("Pedals", "PedalClutchBG", new Color(0f, 0f, 0f, 0.5882f), " ");
            HUD.PedalPanel.Handbrake = Config.Bind("Pedals", "Handbrake", new Color(0.6226f, 0f, 0f, 0.7059f), " ");
            HUD.PedalPanel.HandbrakeBG = Config.Bind("Pedals", "HandbrakeBG", new Color(0f, 0f, 0f, 0.5882f), " ");

            HUD.MiniMap.MapImage = Config.Bind("Map", "Img1", new Color(1, 1, 1, 0.5f), " ");
            HUD.MiniMap.MapImage2 = Config.Bind("Map", "Img2", new Color(1,1,1,0), " ");
            
        }
        public void Update() 
        { 
            HUD.MiniMap.Update();  
            HUD.PedalPanel.Update();  
            HUD.Speedometer.Update();
            if (Input.GetKeyDown(KeyCode_MUTE.Value))
            {
                var f = GameObject.Find("KeepAlive(Clone)/States/RootState/SyncNetFreerideRaceModeState");
                if (f.GetComponentInChildren<FreeDroneState>() != null) { var sc = FindObjectsOfType<SoundController>(); foreach (SoundController s in sc) { s.fxAudioPause = true; } }
                else { var sc = FindObjectsOfType<SoundController>(); foreach (SoundController s in sc) { s.fxAudioPause = false; } }
            }
        } 
    }
}
