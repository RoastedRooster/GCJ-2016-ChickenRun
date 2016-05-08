using UnityEngine;
using System.Collections;

namespace roastedrooster.chickenrun.laws
{
    public enum TriggeringEventID
    {
        None,
        PlayerJump,
        PlayerMove,
        PlayerStill,
        PlayerTouching
    }

    [CreateAssetMenuAttribute(menuName = "Chicken Run Assets/Law")]
    public class Law : ScriptableObject
    {
        public string name;
        public TriggeringEventID eventID;
        [Range(1f, 10f)]
        public float duration = 5f;
        public float optionalArg = 0f;
    }
}
