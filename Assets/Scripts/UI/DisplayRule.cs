using UnityEngine;
using System.Collections;
using roastedrooster.chickenrun.laws;
using UnityEngine.UI;

namespace roastedrooster.chickenrun.ui
{
    public class DisplayRule : MonoBehaviour
    {
        public Text ruleName;
        public Text ruleTime;

        void Update()
        {
            var lawManager = LawManager.Instance;
            if(lawManager.AppliedLaw != null)
            {
                var text = "Rule : " + lawManager.AppliedLaw.name;
                var remainingTime = lawManager.RemainingTimeForLaw;
                ruleName.text = text;
                ruleTime.text = Mathf.RoundToInt(remainingTime) + "s";
            }
            
        }
    }
}
