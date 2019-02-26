using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Teoria : MonoBehaviour
{
    List<string> EscenasEmociones_TR = new List<string>();
    List<string> EscenasNT_TR = new List<string>();



    public Teoria()
    {
        //Carga los strings solamente
        CargaEscenariosEmociones_TR();
        CargaEscenariosNT_TR();
        

    }

    private void CargaEscenariosEmociones_TR()
    {
        EscenasEmociones_TR.Add("EscenaMiedo_TR");
        EscenasEmociones_TR.Add("EscenaIRA_TR");
        EscenasEmociones_TR.Add("EscenaDepresion_TR");
        EscenasEmociones_TR.Add("EscenaFelicidad_TR");
        EscenasEmociones_TR.Add("EscenaSorpresa_TR");
        EscenasEmociones_TR.Add("EscenaAnsiedad_TR");
        EscenasEmociones_TR.Add("EscenaAmor_TR");
    }

    private void CargaEscenariosNT_TR()
    {
        /*0*/EscenasNT_TR.Add("EscenaNO_TR");
        /*1*/EscenasNT_TR.Add("EscenaCO_TR"); 
        /*2*/EscenasNT_TR.Add("EscenaAch_TR");
        /*3*/EscenasNT_TR.Add("EscenaGABA_TR");
        /*4*/EscenasNT_TR.Add("EscenaGly_TR");
        /*5*/EscenasNT_TR.Add("EscenaGlu_TR");
        /*6*/EscenasNT_TR.Add("Escena5HT_TR");
        /*7*/EscenasNT_TR.Add("EscenaDopa_TR");
        /*8*/ EscenasNT_TR.Add("EscenaNora_TR");
        /*9*/EscenasNT_TR.Add("EscenaAdr_TR");
        /*10*/EscenasNT_TR.Add("EscenaOxy_TR");
        /*11*/EscenasNT_TR.Add("EscenaNP_TR");
    }

    public void EmocionTeoria(int indice)
    {
        SceneManager.LoadScene(EscenasEmociones_TR[indice]);
    }
    
    
    public void NT_Teoria(int indice)
    {
        SceneManager.LoadScene(EscenasNT_TR[indice]);
    }
    


    public void Siguiente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Anterior()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void VolverPrincipal() // ********VIEJO**********
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
