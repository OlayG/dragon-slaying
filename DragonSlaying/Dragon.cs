using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlaying
{
    public class Dragon
    {
        public string Name { get; set; }
        public int Offense { get; set; }
        public int Defense { get; set; }
        public int MaxHitPoints { get; set; }
        public int HitPoints { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine("==========");
            sb.AppendFormat("Off: {0}\tDef: {1}\n", Offense, Defense);
            sb.AppendFormat("HP: {0}/{1}\n", HitPoints, MaxHitPoints);

            return sb.ToString();
        }

        /// <summary>
        /// Checks if the Dragon is alive.
        /// <para>A Dragon is alive if their <see cref="HitPoints"/> are greater than 0.</para>
        /// </summary>
        /// <returns>true if the Dragon is alive, false if they are not</returns>
        public bool IsAlive()
        {
            // TODO
            if(HitPoints > 0)
            {
                return true;
            } else
            {
                return false;
            }

           
        }

    }
}
