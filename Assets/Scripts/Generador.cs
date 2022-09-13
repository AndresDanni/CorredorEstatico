using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject cajas;
    public GameObject flies;

    void Start()
    {
        InvokeRepeating("InstanciarCajas", 2.0f, 3.0f);
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<SpriteRenderer>().sprite.name == "JuegoPlataforma2DOjo - copia")
            CancelInvoke("InstanciarCajas");
    }

    private void InstanciarCajas()
    {
        Instantiate(cajas, new Vector3(13.0f, -2.295f, 0.0f), cajas.transform.rotation);
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(flies, new Vector3(13.0f, Random.Range(-2.525f, 2.55f), 0.0f), flies.transform.rotation);
        }
    }

}
