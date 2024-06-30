using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private bool shouldReconnect;

    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        // Only connect if not already connected
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            // If already connected, join the lobby directly
            OnConnectedToMaster();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (!shouldReconnect)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void DisconnectFromServer()
    {
        if (PhotonNetwork.IsConnected)
        {
            shouldReconnect = true;
            PhotonNetwork.Disconnect();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Photon server: " + cause.ToString());

        if (shouldReconnect)
        {
            shouldReconnect = false;
            StartCoroutine(Reconnect());
        }
    }

    private IEnumerator Reconnect()
    {
        // Wait for a short period to ensure the disconnection is fully processed
        yield return new WaitForSeconds(0.5f);
        Connect();
    }

    public void OnReturnToMainMenu()
    {
        shouldReconnect = false;
        DisconnectFromServer();
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToLobby()
    {
        shouldReconnect = false;
        DisconnectFromServer();
        SceneManager.LoadScene("Lobby");
    }
}