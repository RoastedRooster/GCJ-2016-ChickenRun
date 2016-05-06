using roastedrooster.chickenrun.laws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace roastedrooster.chickenrun.player
{
    public class Player : MonoBehaviour
    {
        public string name;
        public void Punished(Law law)
        {
            Debug.Log(name + "has been punished ! He didn't respect the \"" + law.name + "\" rule !");
        }
    }
}
