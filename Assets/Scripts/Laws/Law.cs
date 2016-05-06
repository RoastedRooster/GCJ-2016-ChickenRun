using UnityEngine;
using System.Collections;

namespace roastedrooster.chickenrun.laws
{
    public enum TriggeringEventID
    {
        PlayerJump
    }

    public class Law : ScriptableObject
    {
        public string name;
        public TriggeringEventID eventID;
    }
}
