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
        texto.text = valor.ToString();

    }

   
}
