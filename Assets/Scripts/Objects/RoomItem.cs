using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    #region Variables
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI roomName;

    [Header("Scrip externos")]
    private CreateJoinRoom managerRoom;

    [Header("GameObject")]
    private GameObject createJoinObject;
    #endregion

    #region Metodos Unity
    private void Start()
    {
        //saco el objeto que tiene el scrip de CreateJoinRoom mediante el tag
        createJoinObject = GameObject.FindGameObjectWithTag("CreateJoin");
        managerRoom = createJoinObject.GetComponent<CreateJoinRoom>();
    }
    #endregion

    #region Metodos Propios
    //metodo que me asigna el texto que va a tener el boton, es decir el nombre de la sala
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName; 
    }

    //metodo que se ejecuta cuando se hace click en una sala, el cual noshace entrar en la misma
    public void GoJoinRoom()
    {
        managerRoom.JoinToRoom(roomName.text);
    }
    #endregion
}
