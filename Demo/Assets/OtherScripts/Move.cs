using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject bridgeParent;
    public GameObject Text;
    float dis;
    Vector3 origen;
    GameObject go;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
        origen = transform.position;
        go= GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.SetParent(transform);
        go.transform.position = transform.position + new Vector3(0, 5, 0);
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        unlocked = true;
    }
    bool start;
    bool unlocked;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            dis = transform.position.z - origen.z;
            if (dis > 100 && dis < 200)
            {
                go.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (dis > 200)
            {
                go.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (dis > 50)
            {
                go.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (dis > 10)
            {
                go.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            if (unlocked)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += Vector3.left * 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += Vector3.right * 10f * Time.deltaTime;
                }
            }
         
        }
        if (unlocked) { 
        }
        else
        {
            Release();
        }
       
       
    }

    private void Release()
    {
        if (bridgeParent.transform.childCount.Equals(0))
        {
            transform.GetChild(transform.childCount - 1).gameObject.transform.SetParent(bridgeParent.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.Equals("End"))
        {
           
            start = false;
            animator.SetBool("Run", false);
            Text.SetActive(true);
        }
        if (other.gameObject.name.Equals("AbyssEnd"))
        {

            unlocked = true;
        }
        if (other.gameObject.name.Equals("AbyssStart"))
        {

            unlocked = false;
        }

    }
}
