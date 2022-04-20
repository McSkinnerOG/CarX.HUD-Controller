using BepInEx.Configuration;
using Binding.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HUD_Controller.HUD
{
    public class Speedometer
    { 
        public static UIRaceSpeedometerContext ui;
        public static GameObject speedo;
        public static GameObject digits;
        public static GameObject HandBrake;

        
        public static ConfigEntry<Color> distance;
        public static ConfigEntry<Color> odometerPanel;
        public static ConfigEntry<Color> GEAR_D;
        public static ConfigEntry<Color> GEAR_N;
        public static ConfigEntry<Color> GEAR_R;
        public static ConfigEntry<Color> speed;
        public static ConfigEntry<Color> zeroOff;
        public static ConfigEntry<Color> Digits;

        public static ConfigEntry<Color> speedoBG;
        public static ConfigEntry<Color> rPMFill_BG;
        public static ConfigEntry<Color> rPMRedZone;
        public static ConfigEntry<Color> rPMFillLine_White;
        public static ConfigEntry<Color> rPMFillLine_Red;
        public static ConfigEntry<Color> pins;
        public static ConfigEntry<Color> speedUnit;
        public static ConfigEntry<Color> separator;
        public static ConfigEntry<Color> handBrakeOff;
        public static ConfigEntry<Color> handBrakeOn;

        public static void Update() 
        { 
            if (ui != null && Input.GetKeyDown(Main.reload.Value))
            {
                ui.distanceUnit.color = distance.Value;
                ui.GEAR_D = GEAR_D.Value;
                ui.GEAR_N = GEAR_N.Value;
                ui.GEAR_R = GEAR_R.Value;
                ui.speedUnit.color = speedUnit.Value;
                ui.zeroGrayColor = zeroOff.Value;
                speedo = ui.gameObject;
                digits = speedo.FindChildWithName("Digits");
                foreach (Text r in speedo.GetComponentsInChildren<Text>())
                {
                    if (r.name == "0") { r.color = Digits.Value; }
                    if (r.name == "0 (1)") { r.color = Digits.Value; }
                    if (r.name == "0 (2)") { r.color = Digits.Value; }
                    if (r.name == "0 (3)") { r.color = Digits.Value; }
                    if (r.name == "0 (4)") { r.color = Digits.Value; }
                    if (r.name == "0 (5)") { r.color = Digits.Value; }
                    if (r.name == "0 (6)") { r.color = Digits.Value; } 
                    if (r.name == "0 (7)") { r.color = Digits.Value; }
                    if (r.name == "0 (8)") { r.color = Digits.Value; }
                    if (r.name == "0 (9)") { r.color = Digits.Value; }
                    if (r.name == "0 (10)") { r.color = Digits.Value; } 
                }
                var speedImg = speedo.GetComponentInChildren<Image>();
                speedImg.color = speedoBG.Value;
                var speed = speedo.FindChildWithName("Speedometer");
                HandBrake = speed.FindChildWithName("HandbrakeLight");
                var hbCol = HandBrake.GetComponent<ColorToggleBinding>();
                hbCol.trueColor = handBrakeOn.Value;
                hbCol.falseColor = handBrakeOff.Value; 
                foreach (Image i in speedo.GetComponentsInChildren<Image>())
                {
                    if (i.name == "RPMFill_BG") { i.color = rPMFill_BG.Value; }
                    if (i.name == "RPMRedZone") { i.color = rPMRedZone.Value; }
                    if (i.name == "RPMFillLine_White") { i.color = rPMFillLine_White.Value; }
                    if (i.name == "RPMFillLine_Red") { i.color = rPMFillLine_Red.Value; }
                    if (i.name == "PinsBlack") { i.color = pins.Value; }
                    if (i.name == "Separator") { i.color = separator.Value; }
                    if (i.name == "OdometerPanel") { i.color = odometerPanel.Value; }
                }
            } else if(Input.GetKeyDown(Main.reload.Value) && ui == null) { ui = GameObject.FindObjectOfType<UIRaceSpeedometerContext>(); }
        } 
    }
}
