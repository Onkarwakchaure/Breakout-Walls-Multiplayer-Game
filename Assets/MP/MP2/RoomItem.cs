using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomItem : MonoBehaviour
{
    public TMP_Text roomName1;

    public void SetRoomName(string _roomName)
    {
        roomName1.text = _roomName;
    }
}


