using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalOfGame : MonoBehaviour
{
    #region Variables
    //variables que controlan los diferenmtes elementos de la ui en la pantalla final del juego
    [SerializeField] private GameObject Loading_txt;
    [SerializeField] private GameObject Points_Panel;
    [SerializeField] private TextMeshProUGUI Winner;
    [SerializeField] private TextMeshProUGUI NickName;
    [SerializeField] private TextMeshProUGUI Points;

    //variable que guarda los puentos del jugador local
    private int MyPoints;
    //variable que nos indicará si el jugador ha ganado o ha perdido
    private bool isWinner;
    #endregion

    #region Metodos Unity
    private void Start()
    {
        //activamos el panel de loading y desactivamos el de la infirmacion
        Loading_txt.SetActive(true);
        Points_Panel.SetActive(false);

        //empezamos la corrutina que nos mostrara los datos
        StartCoroutine("ViewPoints");
    }
    #endregion

    #region Metodos Propios
    private IEnumerator ViewPoints()
    {
        //esperamos 4 segundos para que se puedan actualizar los datos del juegador en photon y que no nos de problemas
        yield return new WaitForSeconds(4f);
        //llamamaos a la funcion que nos muestra los datos
        ViewData();
        //llamamos a la funcion que comprueba si hemos ganado
        IsWinner();
    }

    private void ViewData()
    {
        //indicamos que cambie el panel de loading al de los datos
        Loading_txt.SetActive(false);
        Points_Panel.SetActive(true);

        //ponemos los respectivos datos, el nombre del jugador y su puntuacion
        NickName.text = PhotonNetwork.LocalPlayer.NickName;
        Points.text = PhotonNetwork.LocalPlayer.CustomProperties["playerPoint"].ToString();

        //su puntuacion la guardamos en la variable global para compararla
        MyPoints = (int)PhotonNetwork.LocalPlayer.CustomProperties["playerPoint"];
    }

    private void IsWinner()
    {
        //sacamos la lista de jugadores que hay conectados en el servidor de photon
        var ListPlayer = PhotonNetwork.PlayerList;

        //por cada jugador en la lista comprobamos si tiene mas puntos que el jugador local
        foreach (var player in ListPlayer)
        {
            if(MyPoints >= (int)player.CustomProperties["playerPoint"])
            {
                //si tiene mas puntos nuestro jugaodr local declaramos que es el ganador
                isWinner= true;
            }
            else
            {
                //si tiene menos muntos nuestro jugador local, declaramos que es el perdedor (nuestro jugador local) y nos salimos del bucle
                isWinner = false;
                break;
            }
        }

        Debug.Log(isWinner);

        //le asignamos el texto de ganador o perdedor respectivamente
        if(isWinner)
        {
            Winner.text = "You Win";
        }
        else
        {
            Winner.text = "You Lose";
        }
    }

    public void GOStart()
    {
        SceneManager.LoadScene("ConnectScene");
    }

    #endregion


}
