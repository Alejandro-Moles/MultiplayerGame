using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    #region Variables

    [Header("GameObjects")]
    [SerializeField] private GameObject Start_Panel, CreateRoom_Panel, JoinRoom_Panel, Loading_Panel, PlayerList_Panel;
  

    #endregion


    #region Metodos Unity
    private void Start()
    {
        Start_Panel.SetActive(true);
        CreateRoom_Panel.SetActive(false);
        JoinRoom_Panel.SetActive(false);
        
        Loading_Panel.SetActive(false);
        PlayerList_Panel.SetActive(false);
    }

    #endregion


    #region Metodos Propios
    //metodo que me activa y desactiva los diferentes paneles para que se muestren en el menu solamente los paneles necesarios
    public void PanelController(GameObject PanelName)
    {
        //se desactivan los paneles del inicio, de crear la sala y de unirte a una sala
        Start_Panel.SetActive(false);
        CreateRoom_Panel.SetActive(false);
        JoinRoom_Panel.SetActive(false);
        Loading_Panel.SetActive(false);
        PlayerList_Panel.SetActive(false);

        //se activa el panel que se ha mandado por parametro a esta funcion
        PanelName.SetActive(true);
    }
    #endregion

}
