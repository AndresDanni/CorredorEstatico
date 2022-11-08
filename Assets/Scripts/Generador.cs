using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generador : MonoBehaviour
{
    private IEnumerator coEnemySpawn;

    public GameObject cajas;
    public GameObject flies;

    public Text accion;
    public Text txtVel;

    public float gameSpeed;

    void Start()
    {
        //InvokeRepeating("InstanciarCajas", 2.0f, 5.0f);
        coEnemySpawn = EnemySpawn(Random.Range(2.0f, 3.0f));
        StartCoroutine(coEnemySpawn);
        StartCoroutine(inscreaseSpeed());
        gameSpeed = 3.0f;
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver)
            StopAllCoroutines();
            //CancelInvoke("InstanciarCajas");
    }

    /*
    private void InstanciarCajas()
    {
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(cajas, new Vector3(13.0f, -2.295f, 0.0f), cajas.transform.rotation);
        }
        else
        {
            Instantiate(cajas, new Vector3(13.0f, -2.295f, 0.0f), cajas.transform.rotation);
            Instantiate(cajas, new Vector3(13.0f, -0.5f, 0.0f), cajas.transform.rotation);
        }
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(flies, new Vector3(13.0f, Random.Range(-2.525f, 2.55f), 0.0f), flies.transform.rotation);
        }
    }*/

    IEnumerator inscreaseSpeed()
    {
        while (gameSpeed < 9)
        {
            yield return new WaitForSeconds(5.0f);
            Debug.Log("Speed++");
            gameSpeed++;
            txtVel.text = "Velocidad de juego: " + gameSpeed;
        }
    }

    IEnumerator EnemySpawn(float timeInterval)
    {
        yield return new WaitForSeconds(timeInterval);
        int action = Random.Range(0, 3);
        switch (action)
        {
            case 0:
                accion.text = "Siguiente evento: caja sospechosa";
                Instantiate(cajas, new Vector3(Random.Range(13.0f, 18.0f), -3.192f, 0.0f), cajas.transform.rotation);
                Debug.Log("Action: caja");
                break;
            case 1:
                accion.text = "Siguiente evento: ojo malvado";
                Instantiate(flies, new Vector3(Random.Range(13.0f, 18.0f), Random.Range(-2.525f, 2.55f), 0.0f), flies.transform.rotation);
                Debug.Log("Action: fly");
                break;
            default:
                accion.text = "Siguiente evento: libre de amenazas";
                Debug.Log("Action: nothing");
                break;
        }
        StartCoroutine(EnemySpawn(Random.Range(2.0f, 3.5f)));
    }
}
