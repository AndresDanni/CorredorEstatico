using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float floorSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //floorSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<PlayerScr>().gameOver == false)
        {
            if (this.transform.position.x <= -11.16f)
                this.transform.position = new Vector3(14.11f, this.transform.position.y, this.transform.position.z);

            //this.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
            this.transform.position += Vector3.left * GameObject.Find("Generador").GetComponent<Generador>().gameSpeed * Time.deltaTime;
        }
    }
}
