using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public MP_CameraFollow cameraFollow; // Reference to the CameraFollow script

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject player = PhotonNetwork.Instantiate(PlayerPrefab.name, randomPosition, Quaternion.identity);

        // Assign the player's transform to the cameraFollow script
        cameraFollow.playerTransform = player.transform;

        // Set the player's name
        //PlayerName playerName = player.GetComponent<PlayerName>();
        //playerName.SetName(PhotonNetwork.NickName); // Set the player's name to their Photon nickname
    }
}
