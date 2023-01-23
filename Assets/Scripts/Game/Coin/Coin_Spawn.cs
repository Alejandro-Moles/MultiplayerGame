using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Coin_Spawn : MonoBehaviour
{
    #region Variables
    //variable que guarda el prefab de la moneda que se va a instanciar
    [SerializeField] GameObject coinPreFab;
    //variable que guarda todos los puntos de spawn de la moneda
    [SerializeField] Transform[] spawnPoints;

    //variable que nos indica cuantas monedas se han instanciado
    private int numOfCoins;

    
    #endregion

    #region Metodos Unity
    void Start()
    {
        //llamamos al metodo que genera monedas
        StartCoroutine("StartSpawn");
    }

    #endregion

    #region Metodos Propios
    private void generateCoin()
    {
       //sacamos un numero aleatorio que nos indicara el punto de spawn
        int randomNum = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNum];

        //instanciamos la monesa usando el metodo de Photon
        PhotonNetwork.Instantiate(coinPreFab.name, spawnPoint.position, Quaternion.identity);
        numOfCoins++; 
    }

    public void restNumCoin()
    {
        numOfCoins--;
    }


    //esta corrutina empezará a spawnear monedas todo el tiempo
    private IEnumerator StartSpawn()
    {
        //sacamos un numero random entre 1 y 7 que sera el tiempo que espere para spawnear una moneda
        int randomTime = Random.Range(1, 7);
        yield return new WaitForSeconds(randomTime);

        //si el nunmero de monedas instanciadas es menor a 5 entonces llamamos al metodo de generar monedas
        if (numOfCoins <= 5)
        {
            generateCoin();
        }

        //volvemos a llamar a la corrutina para que se vuelva a ejecutar
        StartCoroutine("StartSpawn");
    }
    #endregion
}
