using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }
    bool flag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            flag = true;
            transform.Rotate(Vector3.up ,20f);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            transform.Translate(Vector3.forward * 30f * Time.deltaTime);
        }
    }
}
