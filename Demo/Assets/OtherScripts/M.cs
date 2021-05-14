using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{
    CameraFollow cameraFollow;
    Animator anim;
    bool c;
    Transform OldParent;
  public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        OldParent = GameObject.Find("OldParent").transform;
        //anim = GetComponent<Animator>();
        //anim.SetBool("Run", true);
        //c = false;   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (flag)
        {
            if (other.gameObject.name.Equals("Player"))
            {

                gameObject.transform.position = other.gameObject.transform.Find("Parent").transform.GetChild(other.gameObject.transform.Find("Parent").transform.childCount - 1).transform.position + Vector3.down * 1.5f;
                gameObject.transform.SetParent(other.gameObject.transform.Find("Parent").transform);
                //Debug.Log(other.gameObject.transform.GetChild(other.gameObject.transform.childCount - 1).transform.position);
                // anim.SetBool("Run", false);
                //c = true;
                cameraFollow.offset += new Vector3(0, 0.15f, -1.75f);
            }
        }
        
    }
    // Update is called once per frame
    void Update() { 
    //{
    //    if (c)
    //    {
           
    //        anim.SetTrigger("Hikick");
    //    }
    //    if (OldParent.transform.childCount.Equals(0))
    //    {
    //        c = false;
    //        anim.SetTrigger("DamageDown");
    //        transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    //    }
    }
}
