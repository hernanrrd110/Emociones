using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    public void Experiencias()
    {

        SceneManager.LoadScene("MenuExperiencias");
    }

    public void Teoria()
    {
        SceneManager.LoadScene("MenuTeoria");
    }

    public void Exp_Grad()
    {
        SceneManager.LoadScene("Escena_EG2");
    }
    public void Salir()
    {
        Debug.Log("Salidosen");
        Application.Quit();
    }
}
