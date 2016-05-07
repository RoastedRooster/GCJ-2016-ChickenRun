using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using roastedrooster.chickenrun.player;

public class LobbyManager : MonoBehaviour {

    bool _gameStarted = false;
    public Dictionary<int, GameObject> Players { get; set; }
    public GameObject playerPrefab;
    public GameObject startingPosition;

    // Use this for initialization
    void Start() {
        Players = new Dictionary<int, GameObject>();
        // GameRunning = false;
    }

    void Update () {
        // Handle join and leave in the lobby
        if (!_gameStarted) {
            bool playerInLobby = false;

            for (int i = 1; i < 5; i++) {

                playerInLobby = ControllerUsed(i);

                Debug.Log(playerInLobby);

                if (Players.Count < 4 && !playerInLobby && Input.GetButtonDown("Jump_" + i)) {
                    Debug.Log("BONJOUR");
                    AddPlayer(i);
                }

                /*
                if (playerInLobby && Input.GetButtonDown("Fire2_" + i)) {
                    RemovePlayer(i);
                }
                */
            }

        }
    }

    private bool ControllerUsed(int controllerIndex) {
        if (Players.Count < 1)
            return false;

        if (Players.Where(kp => kp.Value.GetComponent<Player>().ControllerIndex == controllerIndex).Count() > 0)
            return true;

        return false;
    }

    private void AddPlayer(int controllerIndex) {
        var availableSlotIndex = GetFirstAvailableSlot();
        if (availableSlotIndex != -1) {

            GameObject player = GameObject.Instantiate(playerPrefab, startingPosition.transform.position, Quaternion.identity) as GameObject;
            player.GetComponent<Player>().ControllerIndex = controllerIndex;
            Players.Add(availableSlotIndex, player);

        }
    }

    private int GetFirstAvailableSlot() {
        for (int i = 1; i < 5; i++) {
            if (!Players.Keys.Contains(i))
                return i;

            if (Players[i] == null)
                return i;
        }

        return -1;
    }
}
