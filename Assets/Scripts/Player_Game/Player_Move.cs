using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Move : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    private PhotonView view;
    private Animator animator;

    [Header("Movimiento del jugador")]
    //estas es la variable que se usará para determinar el movimiento del personaje en el eje horizontal y vertical
    private float Horizontal = 0f;
    private float Vertical = 0f;

    //esta variable se usará para comprobar si el jugador esta mirando a la derecha o a la izquierda
    private bool LookRigth = true;

    [SerializeField] private float playerSpeed;
    [SerializeField] private Vector2 direction;
    #endregion

    #region Metodos de Unity
    void Start()
    {
        //obtenemos el rigidBody
        rb = GetComponent<Rigidbody2D>();
        //obtnemos el photon view
        view = GetComponent<PhotonView>();
        //obtenemos el animator
        animator = GetComponent<Animator>(); 
    }

    
    void Update()
    {
        if (view.IsMine)
        {
            //comprobamos si esta pulsando la tecla de movimiento
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");

            animator.SetInteger("Horizontal", (int)Horizontal);
            animator.SetInteger("Vertical", (int)Vertical);

            direction = new Vector2(Horizontal, Vertical);
        }
    }

    private void FixedUpdate()
    {
        //comprobamos si el componente de photon view es el nuestro, de ser asi llamamos a la funcion de moverse
        if (view.IsMine)
        {
            Movement(Horizontal);
        }
       
    }
    #endregion

    //funcion que hace que nuestro personaje se mueva
    private void Movement(float move)
    {
        rb.MovePosition(rb.position + direction * playerSpeed * Time.fixedDeltaTime);

        //comprobamos si esta mirando hacia la derecha o la izquierda y lo giramos para el lado correspondiente
        if (move > 0 && !LookRigth)
        {
            TurnUp();
        }else if (move < 0 && LookRigth)
        {
            TurnUp();
        }
    }

    //funcion que modifica la escala del personaje en la x para que el personaje gire hacia donde esta mirando
    private void TurnUp()
    {
        LookRigth = !LookRigth;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
