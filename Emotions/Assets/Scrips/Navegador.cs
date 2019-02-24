using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navegador : MonoBehaviour
{
    List<string> EscenasNavegador = new List<string>();
    bool bandera = false;
    [SerializeField]
    int IndiceEscenaActual = 0;

    public Button BotonSiguiente;
    public Button BotonAnterior;
    public Button Esc;


    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        string NombreEscena = SceneManager.GetActiveScene().name;
        if (NombreEscena == "MenuPrincipal")
        {
            BotonAnterior.gameObject.SetActive(false);
            BotonSiguiente.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
            IndiceEscenaActual = -1;
        }

    }


    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (next.name != "MenuPrincipal")
        {
            BotonAnterior.gameObject.SetActive(true);
            BotonSiguiente.gameObject.SetActive(true);
            Esc.gameObject.SetActive(true);
            if (next.name == "MenuExperiencias" || next.name == "MenuTeoria")
            {
                Esc.interactable = false;
                BotonAnterior.interactable = false;
            }
            else
            {
                Esc.interactable  = true;
                BotonAnterior.interactable = true;
            }
                

            //Pregunta si no se usó los botones de navegador

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

            if (EscenasNavegador.Count == (IndiceEscenaActual + 1))
            {
                BotonSiguiente.interactable = false;
            }
            else
            {
                BotonSiguiente.interactable = true;
            }

        }
        else 
        {
            //eliminamos toda la lista, reiniciamos el navegador
            EscenasNavegador.RemoveRange(0, EscenasNavegador.Count);
            IndiceEscenaActual = -1;
            BotonAnterior.gameObject.SetActive(false);
            BotonSiguiente.gameObject.SetActive(false);
            Esc.gameObject.SetActive(false);
        }

        bandera = false;
    }

    public void Siguiente()
    {
        //Para indicar que se usó el botón de navegador
        bandera = true;
        IndiceEscenaActual++;
        SceneManager.LoadScene(EscenasNavegador[IndiceEscenaActual]);
    }

    public void Anterior()
    {
        //Para indicar que se usó el botón de navegador
        bandera = true;
        IndiceEscenaActual--;
        SceneManager.LoadScene(EscenasNavegador[IndiceEscenaActual]);

    }

    private void Update()
    {
        string NombreEscena = SceneManager.GetActiveScene().name;
        if (!(NombreEscena == "MenuPrincipal" || NombreEscena == "MenuExperiencias" || NombreEscena == "MenuTeoria"))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Anterior();
            }
        }
    }
}
