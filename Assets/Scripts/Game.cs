using roastedrooster.chickenrun.laws;
using roastedrooster.chickenrun.player;
using roastedrooster.chickenrun.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace roastedrooster.chickenrun.game {
    public class Game : MonoBehaviour
    {
        GameObject[] players;
        GameObject panel;

        public void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            panel = GameObject.Find("Panel");
            startGame();
        }

        public void Update() {
            foreach(GameObject player in players) {
                Player pl = player.GetComponent<Player>();
                if(pl.getLap() == 3) {
                    panel.GetComponent<DisplayRule>().enabled = false;
                    // Search texts and clear time one
                    GameObject text = GameObject.Find("Rule Name");
                    GameObject.Find("Rule Time").GetComponent<Text>().text = "";

                    // Change text to win message
                    // text.GetComponent<Text>().text = pl.name + " WIN !";
                    text.GetComponent<Text>().text = "We have a WINNER !";
                    Time.timeScale = 0;
                }
            }
        }

        public void startGame() {
            foreach (GameObject player in players) {
                PlayerController pl = player.GetComponent<PlayerController>();
                pl.setGameStarted(true);
            }
        }
    }
}
