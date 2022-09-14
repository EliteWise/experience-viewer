using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMod
{
    class ModConfig
    {
        public string RgbaMessageColor { get; set; } = "176, 224, 230, 255";

        public bool DisplayHudMessage { get; set; } = false;

        public int HudMessageSecondLeft { get; set; } = 4;
    }
}
