using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Exp_Gradual : MonoBehaviour
{
    public Slider Glu;
    public Slider Dopa;
    public Slider GABA;
    public Slider _5HT;
    public Slider Oxy;

    public Imagen_TIF[] imagenesCaras;
    public Imagen_TIF[] imagenesCerebro;

    Button OxyBotonMas;
    Button OxyBotonMenos;

    public Image PanelEmocion;
    public Text TextoEmocion;
    public Button BotonEmocion;

    public Text TextoLugar;
    public Image ImagenCerebro;
    public Image carita;

    Text TextoGlu;
    Text TextoDopa;
    Text TextoGABA;
    Text Texto5HT;
    Text TextoOxy;

    public enum Lugares : int
    {
        AMIGDALA = 0,
        HIPOTALAMO,
        HIPOCAMPO
    }

    public enum Emociones : int
    {
        NEUTRAL = 0,
        MIEDO,
        IRA,
        DEPRESION,
        FELICIDAD,
        ANSIEDAD,
        AMOR
    }

    List <string> ListaLugares = new List<string>();
    List<string> ListaEmo = new List<string>();
    int IndiceActualDropdownLugares = 0;
    int IndiceActualDropdownEmo = 0;

    public TMP_Dropdown dropdownLugaresTM;
    public TMP_Dropdown dropdownPresets;

    bool banderaEmo = false;


    // Start is called before the first frame update

    void Start()
    {
        PanelEmocion.gameObject.SetActive(false);
        InicializarSliders();

        ListaLugares.Add("Amígdala");
        ListaLugares.Add("Hipotálamo");
        ListaLugares.Add("Hipocampo");

        ListaEmo.Add("Neutral");
        ListaEmo.Add("Miedo");
        ListaEmo.Add("Ira");
        ListaEmo.Add("Depresión");
        ListaEmo.Add("Felicidad");
        ListaEmo.Add("Ansiedad");
        ListaEmo.Add("Amor");

        dropdownLugaresTM.ClearOptions();
        dropdownLugaresTM.AddOptions(ListaLugares);
        dropdownLugaresTM.value = 0;

        dropdownPresets.ClearOptions();
        dropdownPresets.AddOptions(ListaEmo);
        dropdownPresets.value = 0;



        Button[] Botones = FindObjectsOfType<Button>();
        foreach (Button b in Botones)
        {
            if (b.name == "Botón + Oxy")
                OxyBotonMas = b;
            if (b.name == "Botón - Oxy")
                OxyBotonMenos = b;
        }

        if (OxyBotonMas == null || OxyBotonMenos == null)
        {
            Debug.Log("No se encontró el botón");
        }
        
        TextoGlu = GameObject.FindGameObjectWithTag("TextoGlu").GetComponent<Text>();
        TextoDopa = GameObject.FindGameObjectWithTag("TextoDopa").GetComponent<Text>();
        TextoGABA = GameObject.FindGameObjectWithTag("TextoGABA").GetComponent<Text>();
        Texto5HT = GameObject.FindGameObjectWithTag("Texto5HT").GetComponent<Text>();
        TextoOxy = GameObject.FindGameObjectWithTag("TextoOxy").GetComponent<Text>();
        

    }


    // Update is called once per frame
    void Update()
    {

        TextoGlu.text = Glu.value.ToString();
        TextoDopa.text = Dopa.value.ToString();
        TextoGABA.text = GABA.value.ToString();
        Texto5HT.text = _5HT.value.ToString();
        TextoOxy.text = Oxy.value.ToString();

        //*******************ESTADO NEUTRO***********************

        banderaEmo = false;
    
        if ((Glu.value == 3|| Glu.value == 4) && (Dopa.value == 3|| Dopa.value == 4) && (GABA.value == 3|| GABA.value == 4) && (_5HT.value == 3|| _5HT.value == 4))
        {
            if (IndiceActualDropdownLugares == (int)Lugares.HIPOTALAMO)
            {
                if (Oxy.value == 1|| Oxy.value == 2)
                {
                    dropdownPresets.value = (int)Emociones.NEUTRAL;
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "NEUTRAL";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Neutral", carita);
                    BotonEmocion.interactable = false;
                    
                }
                else
                    PanelEmocion.gameObject.SetActive(false);
            }
            else
            {
                dropdownPresets.value = (int)Emociones.NEUTRAL;
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "NEUTRAL";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
                CambiarImagenCara("Neutral", carita);
                BotonEmocion.interactable = false;
            }
        }
        
        else
            BotonEmocion.interactable = true;
        //*****************ESTADOS DE AMIGDALA******************

        if (IndiceActualDropdownLugares == (int)Lugares.AMIGDALA)
        {
            //*****************ESTADOs DE MIEDO******************

            if (((Glu.value >= 5) && (Glu.value <= 7)) && (Dopa.value >= 5 && Dopa.value <= 7) && (GABA.value == 3 || GABA.value == 4) && (_5HT.value >= 5 && _5HT.value <= 7))
            {
                dropdownPresets.value = (int)Emociones.MIEDO;
                int nivel = (int)Glu.value + (int)Dopa.value + (int)_5HT.value;
                if (nivel >14 && nivel < 17)
                {

                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Miedo1";
                    banderaEmo = true;
                    CambiarImagenCara("Miedo1", carita);
                }
                if (nivel > 16 && nivel < 20)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Miedo2";
                    banderaEmo = true;
                    CambiarImagenCara("Miedo2", carita);
                }
                if (nivel > 19 && nivel < 22)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Miedo3";
                    banderaEmo = true;
                    CambiarImagenCara("Miedo3", carita);
                }


            }


        }
    
        //*****************ESTADOS DE HIPOTALAMO******************
        if (IndiceActualDropdownLugares == (int)Lugares.HIPOTALAMO)
        {
            OxyBotonMas.interactable = true;
            OxyBotonMenos.interactable = true;
            Oxy.interactable = true;


            //******************ESTADO DE IRA******************
            if ((Glu.value > 4 && Glu.value < 8) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value == 3 || GABA.value == 4) && (_5HT.value > 4 && _5HT.value < 8)&& (Oxy.value > 0 && Oxy.value < 3))
            {
                dropdownPresets.value = (int)Emociones.IRA;
                int nivel = (int)Glu.value + (int)Dopa.value + (int)_5HT.value;
                if (nivel > 14 && nivel < 17)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ira1";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ira1", carita);
                }
                if (nivel > 16 && nivel < 20)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ira2";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ira2", carita);
                }
                if (nivel > 19 && nivel < 22)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ira3";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ira3", carita);
                }

            }

            //******************ESTADO DE Amor******************
            if ((Glu.value > 2 && Glu.value < 5) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value > 2 && GABA.value < 5) && (_5HT.value > 4 && _5HT.value < 8) && (Oxy.value > 3 && Oxy.value < 8))
            {
                dropdownPresets.value = (int)Emociones.AMOR;
                int nivel = (int)Dopa.value  + (int)_5HT.value + (int)Oxy.value; 
                if (nivel > 13 && nivel < 17)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Amor1";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Amor1", carita);
                }
                if (nivel > 16 && nivel < 20)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Amor2";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Amor2", carita);
                }
                if (nivel > 19 && nivel < 22)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Amor3";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Amor3", carita);
                }
            }
        }
        else
        {
            Oxy.interactable = false;
            OxyBotonMas.interactable = false;
            OxyBotonMenos.interactable = false;
        }


        //******************ESTADOS DE HIPOCAMPO******************
        if (IndiceActualDropdownLugares == (int)Lugares.HIPOCAMPO)
        {
            //******************ESTADO DE DEPRESION******************
            if ((Glu.value > 2 && Glu.value < 8) && (Dopa.value > 0  && Dopa.value < 3) && (GABA.value > 4 && GABA.value < 8) && (_5HT.value > 0 && _5HT.value < 3))
            {
                dropdownPresets.value = (int)Emociones.DEPRESION;
                int nivel = (int) Glu.value + (int) GABA.value;
                if (nivel > 7 && nivel < 10) //Entre 8 y 9
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Depresión1";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Depresion1", carita);
                }
                if (nivel > 9 && nivel < 13) //Entre 10 y 12
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Depresión2";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Depresion2", carita);
                }
                if (nivel > 12 && nivel < 15) //Entre 13 y 14
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Depresión3";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Depresion3", carita);
                }
            }


            //******************ESTADO DE FELICIDAD******************
            if ((Glu.value > 2 && Glu.value < 5) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value > 2 && GABA.value < 5) && (_5HT.value > 4 && _5HT.value < 8))
            {
                dropdownPresets.value = (int)Emociones.FELICIDAD;
                int nivel = (int)Dopa.value + (int)_5HT.value;

                if (nivel > 7 && nivel < 10) //Entre 8 y 9
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Felicidad1";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Felicidad1", carita);
                }
                if (nivel > 9 && nivel < 13) //Entre 10 y 12
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Felicidad2";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Felicidad2", carita);
                }
                if (nivel > 12 && nivel < 15) //Entre 13 y 14
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Felicidad3";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Felicidad3", carita);
                }

            }

            //******************ESTADO DE ANSIEDAD******************
            if ((Glu.value > 4 && Glu.value < 8) && (Dopa.value > 0 && Dopa.value < 3) && (GABA.value > 0 && GABA.value < 3) && (_5HT.value > 0 && _5HT.value < 3))
            {
                dropdownPresets.value = (int)Emociones.ANSIEDAD;
                if (Glu.value == 5)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ansiedad1";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ansiedad1", carita);
                }
                if (Glu.value == 6)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ansiedad2";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ansiedad2", carita);
                }
                if (Glu.value == 7)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "Ansiedad3";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagenCara("Ansiedad3", carita);
                }
            }

        }
        
        if(!banderaEmo)
        {
            PanelEmocion.gameObject.SetActive(false);
            CambiarImagenCara("Incognita", carita);
        }


    }



    public void dropdownCambioTM(int IndiceDropdown)
    {
        dropdownLugaresTM.value = IndiceDropdown;
        dropdownLugaresTM.RefreshShownValue();
        IndiceActualDropdownLugares = IndiceDropdown;
        
        switch (IndiceActualDropdownLugares)
        {
            case (int)Lugares.AMIGDALA:
                CambiarImagenCerebro("Amígdala", ImagenCerebro);
                break;
            case (int)Lugares.HIPOTALAMO:
                CambiarImagenCerebro("Hipotálamo", ImagenCerebro);
                break;
            case (int)Lugares.HIPOCAMPO:
                CambiarImagenCerebro("Hipocampo", ImagenCerebro);
                break;

        }

    }

    public void dropdownPresetsCambio(int IndiceDropdown)
    {
        dropdownPresets.value = IndiceDropdown;
        dropdownPresets.RefreshShownValue();
        IndiceActualDropdownEmo = IndiceDropdown;

            switch (IndiceActualDropdownEmo)
            {
                case (int)Emociones.NEUTRAL:
                    Glu.value = 4;
                    Dopa.value = 4;
                    GABA.value = 4;
                    _5HT.value = 4;
                    if (IndiceActualDropdownLugares == (int)Lugares.HIPOTALAMO)
                        Oxy.value = 2;
                    break;
                case (int)Emociones.MIEDO:
                    Glu.value = 5;
                    Dopa.value = 5;
                    GABA.value = 4;
                    _5HT.value = 5;
                    dropdownCambioTM((int)Lugares.AMIGDALA);
                    break;
                case (int)Emociones.IRA:
                    Glu.value = 5;
                    Dopa.value = 5;
                    GABA.value = 4;
                    _5HT.value = 5;
                    Oxy.value = 2;
                    dropdownCambioTM((int)Lugares.HIPOTALAMO);
                    break;
                case (int)Emociones.DEPRESION:
                    Glu.value = 3;
                    Dopa.value = 2;
                    GABA.value = 5;
                    _5HT.value = 2;
                    dropdownCambioTM((int)Lugares.HIPOCAMPO);
                break;
                case (int)Emociones.FELICIDAD:
                    Glu.value = 4;
                    Dopa.value = 5;
                    GABA.value = 4;
                    _5HT.value = 5;
                    dropdownCambioTM((int)Lugares.HIPOCAMPO);
                    break;
                case (int)Emociones.ANSIEDAD:
                    Glu.value = 5;
                    Dopa.value = 2;
                    GABA.value = 2;
                    _5HT.value = 2;
                    dropdownCambioTM((int)Lugares.HIPOCAMPO);
                break;
                case (int)Emociones.AMOR:
                    Glu.value = 4;
                    Dopa.value = 5;
                    GABA.value = 4;
                    _5HT.value = 5;
                    Oxy.value = 5;
                    dropdownCambioTM((int)Lugares.HIPOTALAMO);
                break;

            }

    }

    public void CambiarImagenCara(string nombre, Image imagen)
    {
        Imagen_TIF I = Array.Find(imagenesCaras, ima => ima.nombre == nombre);
        if (I == null)
        {
            Debug.LogWarning("Imagen " + nombre + " no encontrada");
            return;
        }

        imagen.sprite = I.imagen;
    }

    public void CambiarImagenCerebro(string nombre, Image imagen)
    {
        Imagen_TIF I = Array.Find(imagenesCerebro, ima => ima.nombre == nombre);
        if (I == null)
        {
            Debug.LogWarning("Imagen " + nombre + " no encontrada");
            return;
        }

        imagen.sprite = I.imagen;
    }


    public void IrEmoción()
    {
        if (TextoEmocion.text == "Miedo1" || TextoEmocion.text == "Miedo2" || TextoEmocion.text == "Miedo3")
            SceneManager.LoadScene("EscenaMiedo_TR");
        if (TextoEmocion.text == "Ira1" || TextoEmocion.text == "Ira2" || TextoEmocion.text == "Ira3")
            SceneManager.LoadScene("EscenaIRA_TR");
        if (TextoEmocion.text == "Depresión1" || TextoEmocion.text == "Depresión2" || TextoEmocion.text == "Depresión3")
            SceneManager.LoadScene("EscenaDepresión_TR");
        if (TextoEmocion.text == "Felicidad1" || TextoEmocion.text == "Felicidad2" || TextoEmocion.text == "Felicidad3")
            SceneManager.LoadScene("EscenaFelicidad_TR");
        if (TextoEmocion.text == "Ansiedad1" || TextoEmocion.text == "Ansiedad2" || TextoEmocion.text == "Ansiedad3")
            SceneManager.LoadScene("EscenaAnsiedad_TR");
        if (TextoEmocion.text == "Amor1" || TextoEmocion.text == "Amor2" || TextoEmocion.text == "Amor3")
            SceneManager.LoadScene("EscenaAmor_TR");
    }

    public void Incremento(string nombre)
    {
        if (nombre == "Glu")
        {
            Glu.value++;
        }

        if (nombre == "Dopa")
        {
            Dopa.value++;
        }

        if (nombre == "GABA")
        {
            GABA.value++;
        }

        if (nombre == "5HT")
        {
            _5HT.value++;
        }

        if (nombre == "Oxy")
        {
            Oxy.value++;
        }

    }

    public void Decremento(string nombre)
    {
        if (nombre == "Glu")
        {
            Glu.value--;
        }

        if (nombre == "Dopa")
        {
            Dopa.value--;
        }

        if (nombre == "GABA")
        {
            GABA.value--;
        }

        if (nombre == "5HT")
        {
            _5HT.value--;
        }

        if (nombre == "Oxy")
        {
            Oxy.value--;
        }
    }

    private void InicializarSliders()
    {
        
        Glu.maxValue = 7;
        Glu.minValue = 0;
        Glu.value = 4;
        Glu.wholeNumbers = true;
        Glu.interactable = true;

        Dopa.maxValue = 7;
        Dopa.minValue = 0;
        Dopa.value = 4;
        Dopa.wholeNumbers = true;
        Dopa.interactable = true;

        GABA.maxValue = 7;
        GABA.minValue = 0;
        GABA.value = 4;
        GABA.wholeNumbers = true;
        GABA.interactable = true;

        _5HT.maxValue = 7;
        _5HT.minValue = 0;
        _5HT.value = 4;
        _5HT.wholeNumbers = true;
        _5HT.interactable = true;

        Oxy.maxValue = 7;
        Oxy.minValue = 0;
        Oxy.value = 2;
        Oxy.wholeNumbers = true;
        Oxy.interactable = false;
        
    }






    /**************************RELACIONES MATEMÁTICAS QUE VAMOS A USAR LUEGO**************************/
    /**************************INCREMENTO
    /*
     * 
           if (nombre == "Glu")
           {
               if (Glu.value < 4)
               {
                   Glu.value++;
                   Incremento("GABA");
                   Glu.value++;
               }

           }

           if (nombre == "Dopa")
           {
               if (Dopa.value < 4)
               {
                   Dopa.value++;
                   if (Glu.value < 4)
                       Glu.value++;
                   if (Glu.value == 4 && Dopa.value == 4)
                       Glu.value++;
               }
           }

           if (nombre == "GABA")
           {
               if (GABA.value < 4)
               {
                   GABA.value++;
                   if (GABA.value > 2 && Glu.value > 1)
                   {
                       Glu.value--;
                   }
                   if (GABA.value > 3 && _5HT.value > 1 && Dopa.value > 1)
                   {
                       Dopa.value--;
                       _5HT.value--;
                   }
               }
           }

           if (nombre == "5HT" && _5HT.value < 4)
           {
               _5HT.value++;

           }
     * 
     * /********************************DECREMENTO***************
    *         if (nombre == "Glu")
       {
           if (Glu.value > 1)
           {
               Glu.value--;
               Decremento("GABA");
               Glu.value--;
           }

       }

       if (nombre == "Dopa")
       {
           Dopa.value++;
           if (Glu.value > 1)
               Glu.value++;
       }

       if (nombre == "GABA")
       {
           if (GABA.value > 1)
           {
               GABA.value--;
               if (GABA.value > 2 && Glu.value > 1)
               {
                   Glu.value++;
               }
               if (GABA.value > 3 && _5HT.value > 1 && Dopa.value > 1)
               {
                   Dopa.value++;
                   _5HT.value++;
               }
           }
       }

       if (nombre == "5HT" && _5HT.value > 1)
       {
           _5HT.value--;
       }

       *********************************/
}
