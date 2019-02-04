using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exp_Discreta : MonoBehaviour
{
    List<string> EscenasEmociones_ED = new List<string>();

    public Exp_Discreta()
    {
        CargaEscenariosEmociones_ED();
    }

    private void CargaEscenariosEmociones_ED()
    {
        EscenasEmociones_ED.Add("EscenaMiedo_ED");
        EscenasEmociones_ED.Add("EscenaIRA_ED");
        EscenasEmociones_ED.Add("EscenaDepresion_ED");
        EscenasEmociones_ED.Add("EscenaFelicidad_ED");
        EscenasEmociones_ED.Add("EscenaSorpresa_ED");
        EscenasEmociones_ED.Add("EscenaAnsiedad_ED");
        EscenasEmociones_ED.Add("EscenaAmor_ED");
    }

    /************************Funciones para cada Emoción************************/
    
    public void EmocionExpDiscreta(int indice)
    {
        SceneManager.LoadScene(EscenasEmociones_ED[indice]);
    }


    public void VolverPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Volver()
    {
        //Guarda esta escena primero como la última en una variable auxiliar
        string Last_Scene = SceneManager.GetActiveScene().name;

        Debug.Log(PlayerPrefs.GetString("Last_Scene_Key"));
        SceneManager.LoadScene(PlayerPrefs.GetString("Last_Scene_Key"));

        PlayerPrefs.SetString("Last_Scene_Key", Last_Scene);

    }
}
