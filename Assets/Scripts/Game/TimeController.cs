using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Photon.Pun.UtilityScripts;

public class TimeController : MonoBehaviour
{
    #region Variables
    //esta variable es la que guarda el texto del canvas donde estar? el contador
    [SerializeField] private TextMeshProUGUI time_txt;
    [SerializeField] private TextMeshProUGUI poin_txt;

    private int time;

    private GameObject player;
    private Player_Points player_Points;

    //esta variable es una version de una Hash Table pero adaptada para Photon, y se utilizar? para la imagen del personaje que quiera utilizar el jugador
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    #endregion

    #region Metodos Unity
    private void Start()
    {
        //ponemos el tiempo en 30 segundos
        time = 30;
        //llamamos a la corrutina que empieza a contar el tiempo
        StartCoroutine("TimeStart");

        //encontramos al objeto con el tag de Player para sacar su script
        player = GameObject.FindGameObjectWithTag("Player");
        player_Points = player.GetComponent<Player_Points>();

        //indicamos las propiedades de Photon
        playerProperties["playerPoint"] = 0;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    private void Update()
    {
        //muestro en la pantallde juego la puntuacion que tiene el jugador local
        poin_txt.text = "Points: " +player_Points.GetSetNumberOfCoins.ToString();
    }
    #endregion


    #region Metodos Propios
    private IEnumerator TimeStart() 
    {
        //mientras el tiempo sea menor de 30 y mayor a 0 se repetira este bucle
        while (time <= 30 && time > 0)
        {
           yield return new WaitForSeconds(1f);
           time--;
           time_txt.text = time.ToString();
        }

        //indicamos las propiedades de photon y le a?adimos la puntuacion del jugador
        playerProperties["playerPoint"] = player_Points.GetSetNumberOfCoins;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
       

        //nos dirigimos a la pantalla de final del juego
        SceneManager.LoadScene("FinalScene");
    }
    #endregion


}
