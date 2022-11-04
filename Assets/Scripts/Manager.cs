using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public AudioClip startSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Nivel()
    {
        GetComponent<AudioSource>().PlayOneShot(startSound);
        SceneManager.LoadScene(1);
    }
}
