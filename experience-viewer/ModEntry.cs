using System;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System.Collections.Generic;
using StardewValley.Menus;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace experienceviewer
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {

        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            helper.Events.GameLoop.DayEnding += this.OnDayEnding;
        }

        public int parse(string rgba)
        {
            return int.Parse(rgba);
        }

        List<int> experienceLimitPerLevel = new List<int>() { 100, 380, 770, 1300, 2150, 3300, 4800, 6900, 10000, 15000};

        /// <summary>The method called after a new day starts.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDayEnding(object sender, DayEndingEventArgs e)
        {
            Farmer farmer = Game1.player;
            List<int> farmerLevelBySkill = new List<int>(6) { farmer.FarmingLevel, farmer.FishingLevel, farmer.ForagingLevel, farmer.MiningLevel, farmer.CombatLevel, farmer.LuckLevel };
            int index = 0;
            string text = "";

            farmer.experiencePoints.ToList().ForEach(xp => 
            {
                text += $" {Farmer.getSkillNameFromIndex(index)}: {xp}/{experienceLimitPerLevel[farmerLevelBySkill[index]]} ";
                index++;
            });

            if(this.Config.DisplayHudMessage == false)
            {
                string lineBreak = string.Concat(Enumerable.Repeat(" ", 10));
                string rgba = this.Config.RgbaMessageColor;
                string[] rgbaList = Regex.Replace(rgba, @"\s", "").Split(",");
                Game1.chatBox.addMessage("Your xp: " + text, new Color(parse(rgbaList[0]), parse(rgbaList[1]), parse(rgbaList[2]), parse(rgbaList[3]))); // Default Color: 176, 224, 230, 255 //
                Game1.chatBox.addMessage(lineBreak, Color.White);

            } else
            {
                Game1.addHUDMessage(new HUDMessage(text, Color.PowderBlue, this.Config.HudMessageSecondLeft * 1000f, true));
            }
            
        }

    }

}