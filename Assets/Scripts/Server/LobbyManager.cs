using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    #region Variables
    [Header("Game Objects")]
    [SerializeField] private GameObject roomItemPreFab;
    //este el el prefab que contiene el objeto que porta la informacion del jugador conectado
    [SerializeField] private PlayerItem playerItemPreFab;

    [Header("Transform")]
    [SerializeField] private Transform contentObject;
    //este es el contenedor donde se generaran los prefabs de los jugadores que habrá conectado
    [SerializeField] private Transform playerItemContent;

    [Header("Lista")]
    List<RoomItem> roomItemsList = new List<RoomItem>();
    //lista de todos los jugadores que estan conectados
    List<PlayerItem> playerItemList = new List<PlayerItem>();

    [Header("Empezar el Juego")]
    [SerializeField] private GameObject playButton;
    

    #endregion

    #region Metodos Unity
    private void Start()
    {
        //me conecto al lobby del servidor
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        //si el usuario que se ha conectado es el dueño de la sala y hay como minimo 2 personas en la sala se le daran los permisos para empezar el juego (se activara el boton)
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }
    #endregion

    #region Metodos Photon
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //cada vez que se actualiza la lista de salas,(creandose o borrando salas), llamo al metodo de actualizar la vista del scroll view
        UpdateList(roomList);
    }
    #endregion

    #region Metodos Propios
    private void UpdateList(List<RoomInfo> list)
    {
       //por cada uno de los objetos que habia en la lista que se muetra en el scrollView los destruyo
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        //limpio la lista
        roomItemsList.Clear();

        //con la nueva lista de objetos que se me ha pasado, instancio cada uno de ellos y la añado a la lista
        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPreFab.GetComponent<RoomItem>(), contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }


    public void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPreFab, playerItemContent);
            newPlayerItem.SetPlayerInfo(player.Value);

            if(player.Value == PhotonNetwork.LocalPlayer) 
            { 
                newPlayerItem.ApplyLocalChanges();
            }

            playerItemList.Add(newPlayerItem);
        }
    }

    //metodo que se llama al pulsar el boton de jugar
    public void ClickPlayButton()
    {
        //manda a los jugadores a la escena del juego
        PhotonNetwork.LoadLevel("Game");
    }
    #endregion
}
