using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    #region Variables
    [Header("UI")]
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color higthligthColor;

    [Header("GameObject")]
    [SerializeField] private GameObject LeftArrow, RigthArrow;

    [Header("Variables para el cambio de personaje")]
    //esta variable es una version de una Hash Table pero adaptada para Photon, y se utilizará para la imagen del personaje que quiera utilizar el jugador
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] Image playerAvatar;
    //esta variable es un array que guardará todas las imagenes de los personajes que podra usar el jugador
    [SerializeField] Sprite[] avatars;

    //esta variable es de un tipo que ya esta hecho gracias a photon, la cual nos permitirña realizar diferentes acciones
    Player player;
    #endregion

    #region Metodos Unity
    private void Start()
    {
        backgroundImage = GetComponent<Image>();
    }
    #endregion

    #region Metodos Propios
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = higthligthColor;
        LeftArrow.SetActive(true);
        RigthArrow.SetActive(true);
    }

    //este metodo se ejecuta cuando pulso el boton izquierdo para cambiar el personaje
    public void OnClickLeftArrow()
    {
        //compruebo si la lista esta al priucipio de la misma
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        //si no esta al principiop de la misma voy recorriendo la lista hacia atras para mostrar los diferentes personajes
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    //este metodo se ejecuta cuando se pulsa el boton derecho para cambiar el personaje
    public void OnClickRigthArrow()
    {
        //si esta al final de la lista, la pongo al principio
        if ((int)playerProperties["playerAvatar"] == avatars.Length -1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        //si no voy hechando la lista hacia delante para mostrar los diferentes personajes
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    //este metodo me actualiza pasandole como parametro un jugador, el avatar que tendrá dicho jugador
    private void UpdatePlayerItem(Player player)
    {
        //le asigno la imagen tanto en el servidor como en lo local
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        //hago tambienm un control por si ocurre algun error
        else
        {
            playerProperties["playerAvatar"] = 0;
        }

    }
    #endregion

    #region Metodos Photon
    //este metodo se llama ciando las propiedades del jugador se cambian en el servidor remoto
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        //en este caso cuando ese pasa, llamo al metodo que me actualizará la imagen
        if(player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }
    #endregion
}
