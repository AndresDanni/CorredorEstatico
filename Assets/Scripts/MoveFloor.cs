using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float floorSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == false)
        {
            if (this.transform.position.x <= -11.16f)
                this.transform.position = new Vector3(14.11f, this.transform.position.y, this.transform.position.z);

            this.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
        }
    }
}
