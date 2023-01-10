using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;
using WebSocketSharp;
using UnityEngine.UI;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    #region Variables
    [Header("TextMeshPro")]
    [SerializeField] private TMP_InputField NickName;

    [Header("Botones")]
    [SerializeField] private Button ConnectButton;

    [Header("Game Objects")]
    [SerializeField] private GameObject Connect, Loading;
    #endregion 

    #region Metodos Unity
    private void Update()
    {
        //comprobamos que hay algo escrito en el input para asi que se active el boton de conectarse
        if (!NickName.text.IsNullOrEmpty())
            ConnectButton.interactable= true;
        else
            ConnectButton.interactable= false;
        
    }
    #endregion

    #region Metodos Photon
    public override void OnConnectedToMaster()
    {
        //cuando nos conectamos al servidor, entonces se nos envia a la escena del lobby
        SceneManager.LoadScene("Lobby");
    }
    #endregion

    #region Metodos Propios
    //metodo que se ejecuta al darle al boton de conectarse
    public void ConnecToServer()
    {
        //se activa la "pantalla de carga"
        Connect.SetActive(false);
        Loading.SetActive(true);
        //nos conectamnos al servidor indicando el nickName del jugador
        PhotonNetwork.NickName = NickName.text;
        //esto se hace para que se sincronicen tanto el master como el que no lo es y a la ahora de hacer el loadLevel, tambien se haga para el que no es master
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    #endregion
}
