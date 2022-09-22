using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float flySpeed = 1.0f;

    void Update()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == false)
        {
            if (this.transform.position.x < -13.0f)
                Destroy(gameObject);
            this.transform.position += Vector3.left * flySpeed * Time.deltaTime;
        }
    }
}
