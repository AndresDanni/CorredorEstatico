using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -11.16f)
            this.transform.position = new Vector3(14.11f, this.transform.position.y, this.transform.position.z);

        this.transform.position += Vector3.left * 3.0f * Time.deltaTime;
    }
}
