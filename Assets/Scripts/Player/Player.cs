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
        public int lapCounter = 0;

        public void Punished(Law law)
        {
            Debug.Log(name + "has been punished ! He didn't respect the \"" + law.name + "\" rule !");
            gameObject.transform.position = GameObject.FindGameObjectWithTag("start").transform.position;
        }

        public void increaseLap() {
            lapCounter++;
        }

        public int getLap() {
            return lapCounter;
        }

        void Update() {

            // PAUSE SYSTEM
            if (Input.GetKeyDown(KeyCode.P)) {
                if (Time.timeScale == 1) {
                    Time.timeScale = 0;
                }
                else if (Time.timeScale == 0) {
                    Time.timeScale = 1;
                }
            }
            // END OF PAUSE SYSTEM
        }

    }
}
