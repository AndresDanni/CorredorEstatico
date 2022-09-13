using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScr : MonoBehaviour
{
    public Text myText;
    public Text textFPS;
    public Text textTiempo;

    float tiempoDelta = 0f;
    
    int tiempoJuego = 0;
    int contadorJuego = 0;
    int contadorVueltas = 0;

    long puntaje = 0;

    void Start()
    {
        contadorJuego = 0;
        tiempoJuego = 0;
        puntaje = 0;
    }

    private void Update()
    {
        
        tiempoDelta += Time.deltaTime;
        contadorVueltas++;

        if (tiempoDelta >= 1f)
        {
            textFPS.text = "FPS: " + contadorVueltas;
            contadorVueltas = 0;
            tiempoDelta = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    void FixedUpdate()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<SpriteRenderer>().sprite.name != "JuegoPlataforma2DOjo - copia")
        {
            puntaje++;
            myText.text = "Record: " + PlayerPrefs.GetFloat("Puntaje") + "\nPuntaje actual: " + puntaje;
            contadorJuego++;
            if (contadorJuego == 50)
            {
                tiempoJuego++;
                contadorJuego = 0;
            }
            textTiempo.text = "Tiempo de juego: " + tiempoJuego + "s";
            if (puntaje > PlayerPrefs.GetFloat("Puntaje"))
            {
                PlayerPrefs.SetFloat("Puntaje", puntaje);
            }
        }
    }
}
