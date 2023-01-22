using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    #region Variables
    //variable que guarda los diferentes personajes que puedes utilizar
    [SerializeField] GameObject[] playerPreFabs;
    //variable que guarda todas las posiciones donde pueden aparecer los jugadores
    [SerializeField] Transform[] spawnPoints;
    #endregion

    #region Metodos Unity
    private void Start()
    {
        //sacamos un numero aleatorio
        int randomNum = Random.Range(0, spawnPoints.Length);
        //con ese numero aleatorio sacamos un punto de spwan del array de spawns
        Transform spawnPoint = spawnPoints[randomNum];
        //tambien sacamos que personaje esta usando nuestro jugador
        GameObject playerToSpawn = playerPreFabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];

        //instanciamos unsando el metodo de photon el objeto para que se sincronice
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
       
    }
    #endregion
}
