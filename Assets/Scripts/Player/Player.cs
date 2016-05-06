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
        public void Punished()
        {
            Debug.Log(name + "has been punished !");
        }
    }
}
