using roastedrooster.chickenrun.laws;
using roastedrooster.chickenrun.player;
using roastedrooster.chickenrun.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace roastedrooster.chickenrun.game {
    public class Game : MonoBehaviour
    {
        public GameObject[] players { get; set; }
        GameObject panel;

        public void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            panel = GameObject.Find("Panel");
            startGame();
        }

        public void Update() {
            if(players.Count() > 0) {
                foreach (GameObject player in players) {
                    Player pl = player.GetComponent<Player>();
                    if (pl.getLap() == 3) {
                        panel.GetComponent<DisplayRule>().enabled = false;
                        // Search texts and clear time one
                        GameObject text = GameObject.Find("Rule Name");
                        GameObject.Find("Rule Time").GetComponent<Text>().text = "";

                        // Change text to win message
                        // text.GetComponent<Text>().text = pl.name + " WIN !";
                        text.GetComponent<Text>().text = "We have a WINNER !";

                        StartCoroutine(restartGame());
                    }
                }
            } else {
                players = GameObject.FindGameObjectsWithTag("Player");
            }
        }

        IEnumerator restartGame() {
            
            foreach (GameObject player in players) {
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            

            yield return new WaitForSeconds(2f);

            foreach (GameObject player in players) {
                GameObject.Destroy(player);
            }

            SceneManager.LoadScene("lobby", LoadSceneMode.Single);
        }

        public void startGame() {
            foreach (GameObject player in players) {
                PlayerController pl = player.GetComponent<PlayerController>();
                pl.setGameStarted(true);
            }
        }
    }
}
