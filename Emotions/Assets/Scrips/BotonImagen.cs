using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonImagen : MonoBehaviour
{
    public Animator animador;
    public Button BotonMas;
    public Button BotonMenos;

    public void Aumentar()
    {
        if (animador != null)
        {
            animador.SetTrigger("Aumentar");
            BotonMas.gameObject.SetActive(false);
            BotonMenos.gameObject.SetActive(true);
        }
    }

    public void Disminuir()
    {
        if (animador != null)
        {
            animador.SetTrigger("Disminuir");
            BotonMas.gameObject.SetActive(true);
            BotonMenos.gameObject.SetActive(false);
        }
    }





}
