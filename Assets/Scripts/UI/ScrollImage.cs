using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImage : MonoBehaviour
{
    #region Variables

    [Header("RawImage")]
    [SerializeField] private RawImage scrollabeImage;

    [Header("Variables movimiento")]
    [SerializeField] private float speed;
    Rect rect;

    #endregion

    #region Metodos Unity
    void Start()
    {
        //le asigno a la variable rect el uvRect de la imagen que va a ser scrollable
        rect = scrollabeImage.uvRect;
    }

    void Update()
    {
        //le sumo a ese uvRect el producto de realizar la velocidad a la que quiero que vaya la imagen * el Time.deltaTime
        rect.x += speed * Time.deltaTime;
        //le vuelvo a pasar a la imagen el uvRect ya modificado
        scrollabeImage.uvRect = rect;
    }
    #endregion


}
