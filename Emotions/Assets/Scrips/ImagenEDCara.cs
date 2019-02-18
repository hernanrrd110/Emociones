using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImagenEDCara : MonoBehaviour
{

    public Image imagenCara;

    public Imagen_TIF[] carucha;


    public void CambioSlider(float valor)
    {
        imagenCara.sprite = carucha[(int) valor].imagen;

    }


}
