using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CreateJoinRoom : MonoBehaviourPunCallbacks
{
    #region Variables
    [Header("Scripts Externos")]
    [SerializeField] private UIControl uiControl;
    [SerializeField] private PanelManager panelManager;
    [SerializeField] private LobbyManager lobbyManager;

    [Header("Game Objects")]
    [SerializeField] private GameObject connectingPanel;
    [SerializeField] private GameObject Start_Panel;
    [SerializeField] private GameObject PlayerList_Panel;

    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI[] roomName;

    [Header("Room Option")]
    private RoomOptions roomOptions;

    private string CurrentRoomName;
    #endregion

    #region Metodos Unity
    private void Start()
    {
        uiControl.ChangeNickName(PhotonNetwork.NickName);
        roomOptions = new RoomOptions();
    }
    #endregion

    #region Metodos Photon
    public override void OnJoinedRoom()
    {
        //cuando se entra en una sala, se activa el panel de la sala y se cambia el texto al nombre de la sala
        panelManager.PanelController(PlayerList_Panel);

        foreach (TextMeshProUGUI name in roomName)
        {
            name.text = "Room Name : " + PhotonNetwork.CurrentRoom.Name;
        }
        lobbyManager.UpdatePlayerList();
    }
    public override void OnLeftRoom()
    {
        panelManager.PanelController(Start_Panel);
    }

    //funcoin de photon que se llama cuando un jugador entra a la sala
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        lobbyManager.UpdatePlayerList();
    }

    //funcion de photon que se llama cuando un jugador sale de la sala
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        lobbyManager.UpdatePlayerList();
    }

    #endregion

    #region Metodos Propios
    //metoido que s llama para crera una sala
    public void createRoom()
    {
        //le indico las opciones de la sala, que es el numero max de jugadores
        roomOptions.MaxPlayers = byte.Parse(uiControl.GetSetMaxPlayers.text);
        roomOptions.BroadcastPropsChangeToAll = true;
        //indico tambien el nombre que tendrá la sala
        string roomName = uiControl.GetSetRoomName.text;
        PhotonNetwork.CreateRoom(roomName, roomOptions);

        
        panelManager.PanelController(connectingPanel);
    }

    //metodo que se llama cuando se quiere abandonar el servidor
    public void LogOut()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("ConnectScene");
    }

    //metodo que se llama cuando se quiere entar a una sala, tiene como parametro el nombre de la sala
    public void JoinToRoom(string roomName)
    {
        panelManager.PanelController(connectingPanel);
        CurrentRoomName = roomName;
        PhotonNetwork.JoinRoom(roomName);
    }


    public void DisconnectRoom()
    {
        PhotonNetwork.LeaveRoom(roomName[0]);
    }


    public void GoPlayerList()
    {
        panelManager.PanelController(PlayerList_Panel);
    }
    #endregion
}
