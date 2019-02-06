using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImagenEDCara : MonoBehaviour
{
    SuperManager superManager;
    // Start is called before the first frame update
    void Start()
    {
        superManager = FindObjectOfType<SuperManager>();
        if(SceneManager.GetActiveScene().name == "EscenaMiedo_ED")
        {
            superManager.BuscarImagen("CaraMiedo", this.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
