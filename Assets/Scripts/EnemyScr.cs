using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public float boxSpeed = 1.0f;

    private void Update()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == true)
        {
            GetComponent<Animator>().enabled = false;
        }

        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == false)
        {
            if (this.transform.position.x < -21.0f)
                Destroy(gameObject);
            this.transform.position += Vector3.left * boxSpeed * Time.deltaTime;
        }
    }
}
