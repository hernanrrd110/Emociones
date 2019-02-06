/*using System.Collections;
using System.Collections.Generic;*/
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SuperManager : MonoBehaviour
{
    //Arreglo de clases creadas por nosotros que va a contener el clips y algunos datos
    public Sound[] sounds;
    public Imagen_TIF[] Imagenes;

    public static SuperManager instancia;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvasDeFondo;
    Camera camarita;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            //Para cada elemento del arreglo vamos a asignarle los elementos de Sound al componente AudioSource
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.audioMixerGroup;

            }
            DontDestroyOnLoad(gameObject);
            PlaySound("TemaPrincipal");
        }
            
        else
        {
            Destroy(gameObject);
            return;
        }
        
        //DontDestroyOnLoad(gameObject);


        
    }

    private void Start()
    {

        camarita = (Camera)FindObjectOfType(typeof(Camera));
        
        canvas1.worldCamera = camarita;
        canvas1.renderMode = RenderMode.ScreenSpaceCamera;
        canvas1.pixelPerfect = true;
        canvas2.worldCamera = camarita;
        canvas2.renderMode = RenderMode.ScreenSpaceCamera;
        canvas2.pixelPerfect = true;
        canvas3.worldCamera = camarita;
        canvas3.renderMode = RenderMode.ScreenSpaceCamera;
        canvas3.pixelPerfect = true;
        canvasDeFondo.worldCamera = camarita;
        canvasDeFondo.renderMode = RenderMode.ScreenSpaceCamera;
        

    }




    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sonido no encontrado");
            return;
        }
        s.source.Play();
    }

    private void Update()
    {
        if(camarita == null)
        {
            camarita = (Camera)FindObjectOfType(typeof(Camera));
            canvas1.worldCamera = camarita;
            canvas1.renderMode = RenderMode.ScreenSpaceCamera;
            canvas2.worldCamera = camarita;
            canvas2.renderMode = RenderMode.ScreenSpaceCamera;
            canvas3.worldCamera = camarita;
            canvas3.renderMode = RenderMode.ScreenSpaceCamera;
            canvasDeFondo.worldCamera = camarita;
            canvasDeFondo.renderMode = RenderMode.ScreenSpaceCamera;
        }
        string NombreEscena = SceneManager.GetActiveScene().name;
        if (!(NombreEscena == "MenuPrincipal" || NombreEscena == "MenuExperiencias" || NombreEscena == "MenuTeoria"))
        {
            canvasDeFondo.gameObject.SetActive(false);
        }
        else
            canvasDeFondo.gameObject.SetActive(true);
    }

    public void BuscarImagen(string nombre, Image imagen)
    {
        Imagen_TIF I = Array.Find(Imagenes, ima => ima.nombre == nombre);
        if (I == null)
        {
            Debug.LogWarning("Imagen " + nombre + " no encontrada");
            return;
        }
        
        imagen.sprite = I.imagen;
    }

    public void Salir()
    {
        Debug.Log("Salimoooos");
        Application.Quit();
    }

}
