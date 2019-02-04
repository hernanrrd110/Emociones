using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Exp_Gradual : MonoBehaviour
{
    public Slider Glu;
    public Slider Dopa;
    public Slider GABA;
    public Slider _5HT;
    public Slider Oxy;

    public Imagen_TIF[] imagenes;

    Button OxyBotonMas;
    Button OxyBotonMenos;

    public Image PanelEmocion;
    public Text TextoEmocion;

    public Text TextoLugar;
    public Image imagencita;
    public Image carita;

    Text TextoGlu;
    Text TextoDopa;
    Text TextoGABA;
    Text Texto5HT;
    Text TextoOxy;
    

    bool banderaEmo = false;


    // Start is called before the first frame update

    void Start()
    {
        PanelEmocion.gameObject.SetActive(false);
        InicializarSliders();
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
            if (TextoLugar.text == "Hipotálamo")
            {
                if (Oxy.value == 1|| Oxy.value == 2)
                {
                    PanelEmocion.gameObject.SetActive(true);
                    TextoEmocion.text = "NEUTRAL";
                    banderaEmo = true;
                    carita.gameObject.SetActive(true);
                    CambiarImagen("Miedo", carita);


                }
                else
                    PanelEmocion.gameObject.SetActive(false);
            }
            else
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "NEUTRAL";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
                CambiarImagen("Miedo", carita);
            }
        }
        
        //*****************ESTADOS DE AMIGDALA******************
        
        if (TextoLugar.text == "Amígdala")
        {
            //*****************ESTADO DE MIEDO******************
            if (((Glu.value >= 5) && (Glu.value <=7)) && (Dopa.value >= 5 && Dopa.value <= 7) && (GABA.value == 3 || GABA.value == 4) && (_5HT.value >= 5 && _5HT.value <= 7))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Miedo";
                banderaEmo = true;
            }

        }
    
        //*****************ESTADOS DE HIPOTALAMO******************
        if (TextoLugar.text == "Hipotálamo")
        {
            OxyBotonMas.interactable = true;
            OxyBotonMenos.interactable = true;
            Oxy.interactable = true;

            //******************ESTADO DE IRA******************
            if ((Glu.value > 4 && Glu.value < 8) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value == 3 || GABA.value == 4) && (_5HT.value > 4 && _5HT.value < 8)&& (Oxy.value > 0 && Oxy.value < 3))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Ira";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
            }

            //******************ESTADO DE Amor******************
            if ((Glu.value > 2 && Glu.value < 5) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value > 2 && GABA.value < 5) && (_5HT.value > 4 && _5HT.value < 8) && (Oxy.value > 3 && Oxy.value < 8))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Amor";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
            }


        }
        else
        {
            Oxy.interactable = false;
            OxyBotonMas.interactable = false;
            OxyBotonMenos.interactable = false;
        }




        //******************ESTADOS DE HIPOCAMPO******************
        if (TextoLugar.text == "Hipocampo")
        {
            //******************ESTADO DE DEPRESION******************
            if ((Glu.value > 2 && Glu.value < 8) && (Dopa.value > 0  && Dopa.value < 3) && (GABA.value > 4 && GABA.value < 8) && (_5HT.value > 0 && _5HT.value < 3))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Depresión";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
                CambiarImagen("Depresion", carita);
            }

            //******************ESTADO DE FELICIDAD******************
            if ((Glu.value > 2 && Glu.value < 5) && (Dopa.value > 4 && Dopa.value < 8) && (GABA.value > 2 && GABA.value < 5) && (_5HT.value > 4 && _5HT.value < 8))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Felicidad";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
                CambiarImagen("Felicidad", carita);
            }

            //******************ESTADO DE ANSIEDAD******************
            if ((Glu.value > 4 && Glu.value < 8) && (Dopa.value > 0 && Dopa.value < 3) && (GABA.value > 0 && GABA.value < 3) && (_5HT.value > 0 && _5HT.value < 3))
            {
                PanelEmocion.gameObject.SetActive(true);
                TextoEmocion.text = "Ansiedad";
                banderaEmo = true;
                carita.gameObject.SetActive(true);
            }

        }
        
        if(!banderaEmo)
        {
            PanelEmocion.gameObject.SetActive(false);
            carita.sprite = null;
            carita.gameObject.SetActive(false);
        }
        
        

    }

    public void Cambiar()
    {
        if (TextoLugar.text == "Amígdala")
        {
            TextoLugar.text = "Hipotálamo";
        }
        else
        {
            if (TextoLugar.text == "Hipotálamo")
                TextoLugar.text = "Hipocampo";
            else
                TextoLugar.text = "Amígdala";
        }

    }

    public void CambiarImagen(string nombre, Image imagen)
    {
        Imagen_TIF I = Array.Find(imagenes, ima => ima.nombre == nombre);
        if (I == null)
        {
            Debug.LogWarning("Imagen " + nombre + " no encontrada");
            return;
        }

        imagen.sprite = I.imagen;
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



    public void Teoría()
    {
        if (TextoEmocion.text == "Miedo")
            SceneManager.LoadScene("EscenaMiedo_TR");
        if (TextoEmocion.text == "Ira")
            SceneManager.LoadScene("EscenaIRA_TR");
        if (TextoEmocion.text == "Depresión")
            SceneManager.LoadScene("EscenaDepresion_TR");
        if (TextoEmocion.text == "Felicidad")
            SceneManager.LoadScene("EscenaFelicidad_TR");
        if (TextoEmocion.text == "Sorpresa")
            SceneManager.LoadScene("EscenaSorpresa_TR");
        if (TextoEmocion.text == "Ansiedad")
            SceneManager.LoadScene("EscenaAnsiedad_TR");
        if (TextoEmocion.text == "Amor")
            SceneManager.LoadScene("EscenaAmor_TR");
    }

    private void InicializarSliders()
    {
        
        Glu.maxValue = 8;
        Glu.minValue = 0;
        Glu.value = 4;
        Glu.wholeNumbers = true;
        Glu.interactable = true;

        Dopa.maxValue = 8;
        Dopa.minValue = 0;
        Dopa.value = 4;
        Dopa.wholeNumbers = true;
        Dopa.interactable = true;

        GABA.maxValue = 8;
        GABA.minValue = 0;
        GABA.value = 4;
        GABA.wholeNumbers = true;
        GABA.interactable = true;

        _5HT.maxValue = 8;
        _5HT.minValue = 0;
        _5HT.value = 4;
        _5HT.wholeNumbers = true;
        _5HT.interactable = true;

        Oxy.maxValue = 8;
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
