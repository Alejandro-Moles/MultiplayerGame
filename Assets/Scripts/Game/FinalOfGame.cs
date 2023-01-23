using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinalOfGame : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["playerPoint"]);
    }
}
