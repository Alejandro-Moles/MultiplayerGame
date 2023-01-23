using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player_Points player_Points;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player_Points = collision.gameObject.GetComponent<Player_Points>();
            player_Points.SumPoints(1);
            Destroy(gameObject);
        }
    }
}
