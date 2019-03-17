using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ImagenEDCara : MonoBehaviour
{

    public Image imagenCara;
    public Slider slider;
    public Imagen_TIF[] carucha;
    public TextMeshProUGUI texto;

    public void CambioSlider(float valor)
    {
        imagenCara.sprite = carucha[(int) valor].imagen;
        switch ((int)valor)
        {
            case 3:
                texto.text = "100 %";
                break;
            case 2:
                texto.text = "60 %";
                break;
            case 1:
                texto.text = "30 %";
                break;
            case 0:
                texto.text = "0 %";
                break;
        }
        

    }

   
}
