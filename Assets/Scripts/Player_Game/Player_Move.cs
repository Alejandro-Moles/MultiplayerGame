using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Move : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    private PhotonView view;

    [Header("Movimiento del jugador")]
    //esta es la variable que se usará para determinar el movimiento del personaje en el eje horizontal
    private float Horizontal = 0f;

    //esta es la variable que se usara para darle una velocida a nuestro personaje
    [SerializeField] private float playerSpeed;

    //esta variable nos indicará que tanto queremos que tenga el suavizado de movimiento de nuestro personaje
     [Range(0,1)][SerializeField] private float smooth;

    //esta variable se usará para comprobar si el jugador esta mirando a la derecha o a la izquierda
    private bool LookRigth = true;

    private Vector3 speed = Vector3.zero;
    #endregion

    #region Metodos de Unity
    void Start()
    {
        //obtenemos el rigidBody
        rb = GetComponent<Rigidbody2D>();

        view = GetComponent<PhotonView>();
    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * playerSpeed;
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            Movement(Horizontal * Time.fixedDeltaTime);
        }
       
    }
    #endregion

    private void Movement(float move)
    {
        Vector3 targetSpeed = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetSpeed, ref speed, smooth);

        if (move > 0 && !LookRigth)
        {
            TurnUp();
        }else if (move < 0 && LookRigth)
        {
            TurnUp();
        }
    }

    private void TurnUp()
    {
        LookRigth = !LookRigth;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
