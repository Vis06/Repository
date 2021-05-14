using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 scale;
    void Start()
    {
        locked= true;
        scale = new Vector3(0.1f,0.1f,0);
    }
    bool locked;
    // Update is called once per frame
    void Update()
    {
        if (locked)
        {
            if (gameObject.transform.localScale.x < 0.42)
            {
                gameObject.transform.localScale += scale * Time.deltaTime;

            }
            else
            {
                locked = false;
               
            }
        }
        else
        {
            gameObject.transform.localScale -= scale * Time.deltaTime;
            if (gameObject.transform.localScale.x < 0.23)
            {
                locked = true;
            }
        }
       
    }
}
