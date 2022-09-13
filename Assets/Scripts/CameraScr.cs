using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScr : MonoBehaviour
{
    public GameObject Jugador;

    public Text myText;
    public Text textFPS;
    public Text textTiempo;

    float tiempoDelta = 0f;
    
    int tiempoJuego = 0;
    int contadorJuego = 0;
    int contadorVueltas = 0;


    void Start()
    {
        contadorJuego = 0;
        tiempoJuego = 0;
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
    {/*
        if (Jugador.GetComponent<PlayerScr>().enabled)
        {
            transform.position = new Vector3(Jugador.transform.position.x + 8f, this.transform.position.y, this.transform.position.z);
            myText.text = "Record: " + PlayerPrefs.GetFloat("Puntaje") + "\nPuntaje actual: " + Mathf.Floor(Jugador.transform.position.x + 10f) + "\nVelocidad de juego: " + PlayerScr.PlayerSpeed;
            contadorJuego++;
            if (contadorJuego == 50)
            {
                tiempoJuego++;
                contadorJuego = 0;
            }
            textTiempo.text = "Tiempo de juego: " + tiempoJuego + "s";
            if (Mathf.Floor(Jugador.transform.position.x + 10f) > PlayerPrefs.GetFloat("Puntaje"))
            {
                PlayerPrefs.SetFloat("Puntaje", Mathf.Floor(Jugador.transform.position.x + 10f));
            }
        }*/
    }
}
