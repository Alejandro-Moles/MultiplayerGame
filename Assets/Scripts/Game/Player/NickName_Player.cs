using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NickName_Player : MonoBehaviour
{
    [SerializeField] private TextMeshPro NickName;
    private PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        if(view.IsMine) 
        {
            NickName.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            NickName.text = "";
        }
       
    }
}
