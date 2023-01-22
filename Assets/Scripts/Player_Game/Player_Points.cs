using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Points : MonoBehaviour
{
    #region Variables
    //variable que guarda los puntos que tiene un jugador
    private int NumberOfCoins = 0;
    #endregion

    #region Metodos Propios
    //funcion que nos suma puntos 
    public void SumPoints(int coin)
    {
        NumberOfCoins += coin;

    }
    #endregion

    private void Update()
    {
       Debug.Log(NumberOfCoins);
    }
}
