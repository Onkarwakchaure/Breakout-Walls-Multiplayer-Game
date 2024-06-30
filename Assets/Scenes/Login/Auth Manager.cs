using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO; // For file handling
using Newtonsoft.Json; // Ensure you have the Newtonsoft.Json package installed

public class AuthManager : MonoBehaviour
{
    public TMP_Text logText;
    public TMP_InputField playerNameInputField; // Add this field for player name input

    public static string PlayerId { get; private set; }
    public static string PlayerName { get; private set; }

    private string filePath;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        filePath = Path.Combine(Application.persistentDataPath, "players.json");
        Debug.Log("Player data will be saved to: " + filePath);

        // Check if the player has logged in before
        if (PlayerPrefs.HasKey("PlayerLoggedIn"))
        {
            // Load the player data
            List<PlayerData> playerDataList = LoadPlayerData();
            PlayerData lastPlayerData = playerDataList[playerDataList.Count - 1];
            PlayerId = lastPlayerData.playerId;
            PlayerName = lastPlayerData.playerName;
            SceneManager.LoadScene("Menu");
        }
    }

    public async void SignIn()
    {
        if(!PlayerPrefs.HasKey("PlayerLoggedIn"))
        {
            await signInAnonymous();
            // Set the flag indicating the player has logged in
            PlayerPrefs.SetInt("PlayerLoggedIn", 1);
        }
    }

    async Task signInAnonymous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            string playerId = AuthenticationService.Instance.PlayerId;
            string playerName = playerNameInputField.text; // Get player name from input field

            print("Sign In Success");
            print("Player ID : " + playerId);
            logText.text = "Player ID : " + playerId;

            SavePlayerData(playerId, playerName);
        }
        catch (AuthenticationException ex)
        {
            print("Sign In Failed!!!");
            Debug.LogException(ex);
        }
    }

    private void SavePlayerData(string playerId, string playerName)
    {
        PlayerData newPlayerData = new PlayerData
        {
            playerId = playerId,
            playerName = playerName
        };

        List<PlayerData> playerDataList = LoadPlayerData();
        playerDataList.Add(newPlayerData);

        string json = JsonConvert.SerializeObject(playerDataList, Formatting.Indented);
        File.WriteAllText(filePath, json);

        print("Player data saved: " + json);

        // Set the static properties
        PlayerId = playerId;
        PlayerName = playerName;
    }

    private List<PlayerData> LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<PlayerData>>(json) ?? new List<PlayerData>();
        }
        else
        {
            return new List<PlayerData>();
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 10f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...!");
        PlayerPrefs.Save();
        Application.Quit();
    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerId;
        public string playerName;
    }
}
