using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NickName_Player : MonoBehaviour
{
    [SerializeField] private TextMeshPro NickName;
    void Start()
    {
        NickName.text = PhotonNetwork.LocalPlayer.NickName;
    }
}
