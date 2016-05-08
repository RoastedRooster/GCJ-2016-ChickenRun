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
        public int ControllerIndex;
        public string name;
        public int lapCounter = 0;

        public void setControllerIndex(int i) {
            ControllerIndex = i;
        }

        public int getControllerIndex() {
            return ControllerIndex;
        }

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

            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach(var p in players)
            {
                if (p == gameObject)
                    continue;

                if(Vector2.Distance(p.transform.position, gameObject.transform.position) < 14)
                {
                    LawManager.Instance.PlayerEvent(TriggeringEventID.PlayerTouching, gameObject.GetComponent<Player>());
                    LawManager.Instance.PlayerEvent(TriggeringEventID.PlayerTouching, p.GetComponent<Player>());
                }
            }
        }
    }
}
