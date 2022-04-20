using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HUD_Controller.HUD
{
    public class MiniMap
    {
        public static UIHUDMiniMapContext miniMap;
        public static ConfigEntry<Color> MapImage;
        public static ConfigEntry<Color> MapImage2;
        public static void Update()
        {
            if (Input.GetKeyDown(Main.reload.Value) && miniMap != null)
            {
                miniMap.m_mapImage.color = MapImage.Value;
                miniMap.m_mapImage2.color = MapImage2.Value;
            } else if(miniMap == null) {  miniMap = GameObject.FindObjectOfType<UIHUDMiniMapContext>(); }
        }
    }
}
