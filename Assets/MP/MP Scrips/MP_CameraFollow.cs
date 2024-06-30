using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // The transform of the player

    void Update()
    {
        if (playerTransform != null)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
