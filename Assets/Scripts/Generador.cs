using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    private IEnumerator coEnemySpawn;

    public GameObject cajas;
    public GameObject flies;

    void Start()
    {
        //InvokeRepeating("InstanciarCajas", 2.0f, 5.0f);
        coEnemySpawn = EnemySpawn(Random.Range(2.0f, 3.0f));
        StartCoroutine(coEnemySpawn);
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

    IEnumerator EnemySpawn(float timeInterval)
    {
        yield return new WaitForSeconds(timeInterval);
        int action = Random.Range(0, 3);
        switch (action)
        {
            case 0:
                Instantiate(cajas, new Vector3(Random.Range(13.0f, 18.0f), -2.296f, 0.0f), cajas.transform.rotation);
                Debug.Log("Action: caja");
                break;
            case 1:
                Instantiate(flies, new Vector3(Random.Range(13.0f, 18.0f), Random.Range(-2.525f, 2.55f), 0.0f), flies.transform.rotation);
                Debug.Log("Action: fly");
                break;
            default:
                Debug.Log("Action: nothing");
                break;
        }
        StartCoroutine(EnemySpawn(Random.Range(2.0f, 3.5f)));
    }
}
