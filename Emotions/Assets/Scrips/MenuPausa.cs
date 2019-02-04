using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject Menu;
    string NameScene;

    void Start()
    {

    }

    void Update()
    {
        NameScene = SceneManager.GetActiveScene().name; 
        if(!(NameScene == "MenuPrincipal" || NameScene == "MenuExperiencias" || NameScene == "MenuTeoria"))
            {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Menu.activeSelf == false)
                {
                    Menu.SetActive(true);
                }
                else
                {
                    Menu.SetActive(false);
                }
            }
        }
        else
        {
            if (Menu.activeSelf == true)
            {
                Menu.SetActive(false);
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Silenciar()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


}
