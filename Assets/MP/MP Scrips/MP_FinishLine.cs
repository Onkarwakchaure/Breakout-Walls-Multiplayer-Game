using UnityEngine;
using Photon.Pun;

public class MP_FinishLine : MonoBehaviourPunCallbacks
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (gameEnded)
            return;

        PhotonView playerView = collision.GetComponent<PhotonView>();
        if (playerView != null)
        {
            Debug.Log("PhotonView found. IsMine: " + playerView.IsMine);

            if (playerView.IsMine)
            {
                int winningPlayerActorNumber = playerView.Owner.ActorNumber;
                photonView.RPC("PlayerFinished", RpcTarget.All, winningPlayerActorNumber);
                gameEnded = true;
            }
        }
        else
        {
            Debug.Log("No PhotonView found on the collided object.");
        }
    }

    [PunRPC]
    void PlayerFinished(int winningPlayerActorNumber)
    {
        Debug.Log("PlayerFinished RPC called with winningPlayerActorNumber: " + winningPlayerActorNumber);

        if (MP_UIManager.Instance == null)
        {
            Debug.LogError("UIManager.Instance is null. Ensure UIManager is properly initialized and in the scene.");
            return;
        }

        if (PhotonNetwork.LocalPlayer.ActorNumber == winningPlayerActorNumber)
        {
            Debug.Log("Player won. Showing win panel.");
            MP_UIManager.Instance.ShowWinPanel();
        }
        else
        {
            Debug.Log("Player lost. Showing lose panel.");
            MP_UIManager.Instance.ShowLosePanel();
        }
    }
}
