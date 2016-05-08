using UnityEngine;
using System.Collections;
using roastedrooster.chickenrun.player;
using UnityEngine.UI;
using roastedrooster.chickenrun.game;

public class PlayerUI : MonoBehaviour {

    public int playerIndex;
    public Text playerLap;
    public Text playerLapText;
    public Text playerName;
    public Game gameHolder;

    private Player _player;

    void Start()
    {
        
    }

	void Update () {

        if(gameHolder.players != null)
        {
            var go = gameHolder.players[playerIndex - 1];
            if (go != null && _player == null)
            {
                _player = go.GetComponent<Player>();
                playerName.text = "P" + playerIndex;
                playerLapText.enabled = true;
            }

            if (_player != null)
            {
                playerLap.text = _player.lapCounter.ToString();
            }
        }
        
	}
}
