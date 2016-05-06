using roastedrooster.chickenrun.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace roastedrooster.chickenrun.laws
{
    public class LawManager : ScriptableObject
    {
        public List<Law> availableLaws;
        private List<Law> _appliedLaws;

        public LawManager()
        {
            _appliedLaws = new List<Law>();
        }

        public void PlayerEvent(TriggeringEventID eventID, Player player)
        {
            if(_appliedLaws.Count(law => law.eventID == eventID) > 0)
            {
                player.Punished();
            }
        }

    }
}
