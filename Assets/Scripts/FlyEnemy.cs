using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float flySpeed = 3.0f;

    void Start()
    {
        //flySpeed = 3.0f;
    }

    void Update()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == true)
        {
            GetComponent<Animator>().enabled = false;
        }

        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == false)
        {
            if (this.transform.position.x < -13.0f)
                Destroy(gameObject);
            //this.transform.position += Vector3.left * flySpeed * Time.deltaTime;
            this.transform.position += Vector3.left * GameObject.Find("Generador").GetComponent<Generador>().gameSpeed * Time.deltaTime;
        }
    }
}
