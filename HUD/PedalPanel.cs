using BepInEx.Configuration;
using Binding.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD_Controller.HUD
{
    public class PedalPanel
    { 
        public static GameObject panel;  
        public static Image panelBG;  
        public static GameObject steerLeft;
        public static GameObject steerRight;
        public static GameObject steerHandle; 

        public static GameObject pedalAccel;
        public static GameObject pedalBrake;
        public static GameObject pedalClutch;

        public static GameObject handBrake;

        public static ConfigEntry<Color> PanelBG;
        public static ConfigEntry<Color> SteerLeft;
        public static ConfigEntry<Color> SteerLeftBG;
        public static ConfigEntry<Color> SteerRight;
        public static ConfigEntry<Color> SteerRightBG;
        public static ConfigEntry<Color> SteerHandle; 

        public static ConfigEntry<Color> PedalAccel;
        public static ConfigEntry<Color> PedalAccelBG;
        public static ConfigEntry<Color> PedalBrake;
        public static ConfigEntry<Color> PedalBrakeBG;
        public static ConfigEntry<Color> PedalClutch;
        public static ConfigEntry<Color> PedalClutchBG;
        public static ConfigEntry<Color> Handbrake;
        public static ConfigEntry<Color> HandbrakeBG; 

        public static void Update()
        {
            if (SceneManager.GetActiveScene().name != "SelectCar")
            {
                if (Input.GetKeyDown(Main.reload.Value) && panel != null)
                {
                    panelBG.color = PanelBG.Value;
                    steerLeft.GetComponent<Image>().color = SteerLeftBG.Value;
                    steerLeft.GetComponentInParent<Image>().color = SteerLeft.Value;
                    steerRight.GetComponent<Image>().color = SteerRightBG.Value;
                    steerRight.GetComponentInParent<Image>().color = SteerRight.Value;
                    steerHandle.GetComponent<Image>().color = SteerHandle.Value;

                    pedalAccel.GetComponent<Image>().color = PedalAccelBG.Value;
                    pedalAccel.GetComponentInParent<Image>().color = PedalAccel.Value;
                    pedalBrake.GetComponent<Image>().color = PedalBrakeBG.Value;
                    pedalBrake.GetComponentInParent<Image>().color = PedalBrake.Value;
                    pedalClutch.GetComponent<Image>().color = PedalClutchBG.Value;
                    pedalClutch.GetComponentInParent<Image>().color = PedalClutch.Value;
                    handBrake.GetComponent<Image>().color = HandbrakeBG.Value;
                    handBrake.GetComponentInParent<Image>().color = Handbrake.Value;
                }
                else if (Input.GetKeyDown(Main.reload.Value) && panel == null)
                {
                    panel = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay");
                    var panelOBJ = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/BG");
                    panelBG = panelOBJ.GetComponent<Image>();

                    steerLeft = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Steer/Left/Bar");
                    steerRight = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Steer/Right/Bar");
                    steerHandle = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Steer/Handle/Anchor/Image");

                    pedalAccel = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Pedals/Accel/Bar");
                    pedalBrake = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Pedals/Brake/Bar");
                    pedalClutch = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Pedals/Clutch/Bar");
                    handBrake = GameObject.Find("KeepAlive(Clone)/UGUI/Root/Contexts/UIInputOverlay/root/Handbrake/Bar");
                }
            }
            else return;
        }
    }
}
