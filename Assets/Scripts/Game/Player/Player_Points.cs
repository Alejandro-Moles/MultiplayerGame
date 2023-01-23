using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Points : MonoBehaviour
{
    #region Variables
    //variable que guarda los puntos que tiene un jugador
    private int NumberOfCoins = 0;

    //variable que la usaremos para asignarle el objeto de coin_Spawner que tenemos en la escena
    private GameObject coinSpawner;

    //variable que usaremos para indicar que hemos cogido una moeda y por lo tanto se podrá spawnear otra
    private Coin_Spawn coin_Spawn;

    private PhotonView view;
    #endregion


    #region Metodods Unity
    private void Start()
    {
        //encontramos el objeto con el tag de CoinSpawner que es el que tiene el scrip que queremos
        coinSpawner = GameObject.FindGameObjectWithTag("CoinSpawner");

        //sacamos el scrip que tiene ese objeto y se lo asignamos a nuestra variable
        coin_Spawn = coinSpawner.GetComponent<Coin_Spawn>();

        view = GetComponent<PhotonView>();
    }
    #endregion

    #region Metodos Propios

    //funcion que nos suma puntos 
    public void SumPoints(int coin)
    {
        if (view.IsMine)
        {
            //sumamos un punto al jugador que ha cogido la moneda
            NumberOfCoins += coin;
            //restamos al nuimero de moendas spawneadas 1 para que se puedan a volver a spawnear monedas
            coin_Spawn.restNumCoin();
        }
    }
    #endregion

    #region Metodos Get/Set

    //metodo que sirve para obtener o indicar cual es el numero de monedas
    public int GetSetNumberOfCoins { get => NumberOfCoins; set => NumberOfCoins = value; }
    #endregion
}
