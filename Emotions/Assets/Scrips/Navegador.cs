using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    List<string> EscenasNavegador = new List<string>();
    bool bandera = false;
    int IndiceEscenaActual = 0;
    public GameObject BotonSiguiente;
    public GameObject BotonAnterior;
    public GameObject Imagencita;

    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        string NombreEscena = SceneManager.GetActiveScene().name;
        if (NombreEscena == "MenuPrincipal" || NombreEscena == "MenuExperiencias" || NombreEscena == "MenuTeoria")
        {
            Imagencita.SetActive(false);
            BotonAnterior.SetActive(false);
            BotonSiguiente.SetActive(false);
        }

    }


    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (!(next.name == "MenuPrincipal" || next.name == "MenuExperiencias" || next.name == "MenuTeoria"))
        {
            //Imagen que contiene los botones
            Imagencita.SetActive(true);

            //Pregunta si se usó los botones de navegador
            if (bandera == false)
            {
                if (IndiceEscenaActual + 1 == EscenasNavegador.Count)
                {
                    IndiceEscenaActual++;
                    EscenasNavegador.Add(next.name);
                }
                else
                {
                    EscenasNavegador.RemoveRange(IndiceEscenaActual + 1, EscenasNavegador.Count - (IndiceEscenaActual + 1));
                    IndiceEscenaActual++;
                    EscenasNavegador.Add(next.name);
                }
            }

            if (BotonAnterior.activeSelf == false)
                BotonAnterior.SetActive(true);
            if (EscenasNavegador.Count == (IndiceEscenaActual + 1))
            {
                if (BotonSiguiente.activeSelf == true)
                    BotonSiguiente.SetActive(false);
            }
            else
            {
                if (BotonSiguiente.activeSelf == false)
                    BotonSiguiente.SetActive(true);
            }
        }
        else 
        {
            //Imagen que contiene los botones
            Imagencita.SetActive(false);
            EscenasNavegador.RemoveRange(0, EscenasNavegador.Count);
            IndiceEscenaActual = 0;
            if (next.name == "MenuExperiencias")
                EscenasNavegador.Add("MenuExperiencias");
            if (next.name == "MenuTeoria")
                EscenasNavegador.Add("MenuTeoria");

            BotonAnterior.SetActive(false);
            BotonSiguiente.SetActive(false);
        }

        bandera = false;
    }

    public void Siguiente()
    {
        bandera = true;
        IndiceEscenaActual++;
        SceneManager.LoadScene(EscenasNavegador[IndiceEscenaActual]);
    }

    public void Anterior()
    {
        bandera = true;
        IndiceEscenaActual--;
        SceneManager.LoadScene(EscenasNavegador[IndiceEscenaActual]);

    }
}
