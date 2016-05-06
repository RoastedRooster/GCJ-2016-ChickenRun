using roastedrooster.chickenrun.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace roastedrooster.chickenrun.laws
{
    public class LawManager : MonoBehaviour
    {
        #region Singleton Pattern
        private static LawManager sInstance;
        public static LawManager Instance
        {
            get
            {
                return sInstance;
            }
        }
        #endregion

        #region Inspector Fields
        public List<Law> availableLaws;
        public float timeBeforeFirstLaw = 5f;
        #endregion

        public Law AppliedLaw { get; private set; }
        public float RemainingTimeForLaw
        {
            get
            {
                return Mathf.Max(_nextLawChange - Time.realtimeSinceStartup, 0);
            }
        }

        private float _nextLawChange = 0f;

        public void PlayerEvent(TriggeringEventID eventID, Player player, float optionalArg = 0f)
        {
            if (AppliedLaw.eventID == eventID && AppliedLaw.optionalArg == optionalArg)
            {
                player.Punished(AppliedLaw);
            }
        }

        public void Start()
        {
            if (sInstance == null)
                sInstance = this;
        }

        public void Update()
        {
            var now = Time.realtimeSinceStartup;
            if ((AppliedLaw == null && now > timeBeforeFirstLaw) || now > _nextLawChange)
            {
                AppliedLaw = availableLaws[UnityEngine.Random.Range(0, availableLaws.Count)];
                _nextLawChange = now + AppliedLaw.duration;
            }
        }
    }
}
