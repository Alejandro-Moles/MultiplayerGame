using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPreFabs;
    [SerializeField] Transform[] spawnPoints;

    private void Start()
    {
        int randomNum = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNum];

        GameObject playerToSpawn = playerPreFabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
       

        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);
        


        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }
}
