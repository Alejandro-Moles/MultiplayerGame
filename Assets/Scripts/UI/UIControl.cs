using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class UIControl : MonoBehaviour
{
    #region Variables

    [Header("Inputs")]
    [SerializeField] private TMP_InputField roomName, maxPlayers;

    [Header("Botones")]
    [SerializeField] private Button CreateRoom;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI[] NameText;

    [Header("PreFab Boton")]
    [SerializeField] private GameObject buttonPreFab;

    #endregion

    #region Metodos de Unity
    private void Update()
    {
        CheckBtnCreateRoom();
    }
    #endregion

    #region Metodos Propios
    //metodo que me activa o desactiva el boton de crear sala
    private void CheckBtnCreateRoom()
    {
        //comprueba que ninguno de los inputs esta vacio
        if (!roomName.text.IsNullOrEmpty() && !maxPlayers.text.IsNullOrEmpty())
            //si no estan vacios me activa el boton de crear sala
            CreateRoom.interactable = true;
        else
            //si estnan vacios me desactiva el boton de crear sala
            CreateRoom.interactable = false;
    }


    public void ChangeNickName(string name)
    {
        foreach(TextMeshProUGUI text in NameText )
        {
            text.text = text.text + " " +name;
        }
    }
    #endregion

    #region Metodos Get/Set
    public TMP_InputField GetSetRoomName { get => roomName; set => roomName = value; }
    public TMP_InputField GetSetMaxPlayers { get => maxPlayers; set => maxPlayers = value; }
    public GameObject GetSetButtonPreFab { get => buttonPreFab; set => buttonPreFab = value; }
    #endregion
}
