using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperienceViewer
{
    class SkillUp
{
        public string farmerName { get; set; }
        public string message { get; set; }
        public int level { get; set; }
        public string skillName { get; set; }

        public SkillUp(string farmerName, string message, int level, string skillName)
        {
            this.farmerName = farmerName;
            this.message = message;
            this.level = level;
            this.skillName = skillName;
        }

        public string setupCompleteMessage()
        {
            return farmerName + " " + message + " " + level + " " + skillName;
        }
    }
}
