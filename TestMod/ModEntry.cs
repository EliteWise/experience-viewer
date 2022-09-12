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

namespace TestMod
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayEnding += this.OnDayEnding;
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

            string lineBreak = string.Concat(Enumerable.Repeat(" ", 10));
            Game1.chatBox.addMessage("Your xp: " + text, Color.PowderBlue);
            Game1.chatBox.addMessage(lineBreak, Color.Snow);
        }

    }

}