using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProfileManager : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text playerIdText;

    void Start()
    {
        LoadPlayerProfile();
    }

    private void LoadPlayerProfile()
    {
        string playerName = AuthManager.PlayerName;
        string playerId = AuthManager.PlayerId;

        if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(playerId))
        {
            playerNameText.text = "Player Name: " + playerName;
            playerIdText.text = "Player ID: " + playerId;
        }
        else
        {
            playerNameText.text = "No player data found.";
            playerIdText.text = "XXXXXX";
        }
    }
}
