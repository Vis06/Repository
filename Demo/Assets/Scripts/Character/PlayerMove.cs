using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    None,
    Drunk,
    Hang

}
public class PlayerMove : MonoBehaviour
{
    CameraFollow cameraFollow;
    GameObject GoopSpray;
    int beerBottleCount;
    Transform parent;
   // Transform oldParent;
    float speed;
    Animator animator;
     GameObject endText;
     GameObject bed;
     GameObject finishPanel;
     Text score;
    Rigidbody rigidbody;
    int diamondRecieved;
    Quaternion rotation;
    GameObject Arrows;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        Arrows = GameObject.Find("Canvas").transform.Find("UI").transform.Find("Arrow").gameObject;
        Arrows.SetActive(true);
        endText = GameObject.Find("Canvas").transform.Find("UI").transform.Find("EndText").gameObject;
        bed = GameObject.Find("Bed");
        finishPanel = GameObject.Find("Canvas").transform.Find("UI").transform.Find("FinishPanel").gameObject;
        score = GameObject.Find("Canvas").transform.Find("UI").transform.Find("Score").transform.Find("ScoreText").GetComponent<Text>();
        rigidbody = GetComponent<Rigidbody>();
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        if (gameObject.name.Equals("Player"))
        {
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
                GoopSpray = transform.Find("Character1_Reference").transform.Find("GoopSpray").gameObject;
            }
         
        }
       
        speed = 6f;
        parent = transform.Find("Parent");
        //oldParent = GameObject.Find("OldParent").transform;
        beerBottleCount = 0;
        scorenumber = 0;
        changed = true;
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        playing = true;
        hang = false;
        rigidbody.useGravity= false;
        done = false;
        lookAtBed = false;
        diamondRecieved = PlayerPrefs.GetInt("Diamond");
        Debug.Log(diamondRecieved);
    }
    bool changed;
    bool hang;
    bool playing;
    bool done;
    int scorenumber;
    bool lookAtBed;
    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            
            if (done)
            {
                transform.position = Vector3.MoveTowards(transform.position, bed.transform.position, speed*Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (changed)
                {
                    if (beerBottleCount >= 4)     
                    {
                        if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                        {
                            animator.Play("Land");
                        }
                        else
                        {
                            animator.Play("Spawn");
                        }
                       
                        changed = false;
                        speed /= 2;
                    }
                }

                if (beerBottleCount >= 6)
                {
                    //if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
                    //{
                    //    GoopSpray= transform.Find("Character1_Reference").transform.Find("FlameStream").gameObject;
                    //}
                    hang = true;
                    if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                    {
                        if (gameObject.name.Equals("Player"))
                        {
                            GoopSpray.SetActive(true);
                        }
                    }
                       
                   
                    beerBottleCount = 0;
                }

                if (hang)
                {
                    //if (SceneManager.GetActiveScene().name.Equals("LevelFour")) { }
                    //else
                    //{
                    if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                    {
                        transform.Find("Character1_Reference").Rotate(Vector3.up * 60f * Time.deltaTime);
                    }
                    else
                    {
                       transform.GetChild(0).transform.Rotate(Vector3.up * 60f * Time.deltaTime);
                        Debug.Log(transform.GetChild(0).name);
                    }
                        
                    //}
                        
                }
                else
                {
                    transform.rotation = rotation;
                }

                if (Input.GetMouseButton(0))
                {

                    if (Camera.main.pixelWidth / 2 > Input.mousePosition.x)  
                    {
                        if (this.transform.position.x <= -5.2f)
                        {
                            transform.Translate(Vector3.right * Time.deltaTime * 10);
                        }
                        else
                            transform.Translate(Vector3.left * Time.deltaTime * 10);
                    }
                    else
                    {
                        if (this.transform.position.x >= 5.2f)
                        {
                            transform.Translate(Vector3.left * Time.deltaTime * 10);
                        }
                        else
                            transform.Translate(Vector3.right * Time.deltaTime * 10);
                    }

                }

                if (transform.position.x <= -6f || transform.position.x >= 6f)
                {
                    if (parent != null)
                    {
                        Destroy(parent.gameObject);
                    }
                    //rigidbody.useGravity = true;
                    //rigidbody.isKinematic = false;
                    if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                    {
                        GoopSpray.SetActive(false);
                    }
                       
                    playing = false;
                    animator.SetBool("Run", false);
                    if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                    {
                        animator.Play("DamageDown");
                    }
                    else
                    {
                        animator.Play("Death_Still");
                    }
                      
                    endText.SetActive(true);
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                }
            }
            if (lookAtBed)
            {
                ////Debug.Log("执行了");
                //transform.LookAt(bed.transform.position);
                if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
                {
                    GoopSpray.transform.parent.rotation = rotation;
                }
                else
                {
                    transform.GetChild(0).transform.rotation = rotation;
                }  
                
            }
            
        }
     
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("Bottle"))
        {
            if (other.gameObject.name.Equals("Beer"))
            {
                beerBottleCount++;
            }
            
            //other.gameObject.transform.SetParent(parent);
            //if (parent.childCount.Equals(0))
            //{
            //    other.gameObject.transform.position = parent.position;
            //}
            //else
            //{
            //    other.gameObject.transform.position = parent.GetChild(parent.childCount - 1).transform.position + Vector3.down * 0.5f;
            //}
           
            transform.position += Vector3.up *1.75f;
        }
        if (other.gameObject.name.Equals("End"))
        {
            diamondRecieved += scorenumber;
            playing = false;
            animator.SetBool("Run", false);
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
                animator.Play("DamageDown");
            }
            else
            {
                animator.Play("Death_Still");
            }

                finishPanel.SetActive(true);
            
           int level= PlayerPrefs.GetInt("Level");
            level++;
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.SetInt("Diamond", diamondRecieved);
        }
        if (other.gameObject.name.Equals("BottleOff"))
        {
            Arrows.SetActive(false);
            cameraFollow.ResetPosition();
            gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
           
            lookAtBed = true;
            hang = false;
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
                GoopSpray.SetActive(false);
            }
              
           
            done = true;
            speed = 2f;
            Destroy(parent.gameObject);
        }
        if (other.gameObject.name.Equals("Obstacle"))
        {
            //switch (SceneManager.GetActiveScene().name)
            //{
            //    case "LevelFour":
            //        other.gameObject.AddComponent<SelfRotate>();
            //        transform.position += Vector3.down *1f;
            //        cameraFollow.offset += new Vector3(0, -0.1f, 1f);
            //        break;
            //    default:
                    transform.position += Vector3.down * 1.75f;
                    cameraFollow.offset += new Vector3(0, -0.1f, 1f);
            //        break;
            //}
          
            //parent.GetChild(parent.childCount - 1).gameObject.AddComponent<Rigidbody>();
            //parent.GetChild(parent.childCount - 1).gameObject.GetComponent<M>().flag = false;
            //parent.GetChild(parent.childCount - 1).transform.SetParent(oldParent);
            //parent.GetChild(parent.childCount - 1).transform.position = new Vector3(transform.position.x, 0.5f, transform.position.y);
        }
        if (other.gameObject.name.Equals("Empty"))
        {
            Arrows.SetActive(false);
            if (other.gameObject.transform.childCount > 0)
            {
                Debug.Log(other.gameObject.transform.GetChild(0).name);
            }
            if (parent != null)
            {
                Destroy(parent.gameObject);
            }

            //rigidbody.useGravity = true;
            //rigidbody.isKinematic = false;
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
            GoopSpray.SetActive(false);
            }
               
            playing = false;
            animator.SetBool("Run", false);
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
                animator.Play("DamageDown");
            }
            else
            {
                animator.Play("Death_Still");
            }

                endText.SetActive(true);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
        if (other.gameObject.name.Equals("Diamond"))
        {
            Destroy(other.gameObject,0.35f);
           
            scorenumber += 10;
            score.text = "X" + scorenumber.ToString();
           
        }
        if (transform.position.y < 0)
        {
           
            playing = false;
            animator.SetBool("Run", false);
            if (PlayerPrefs.GetString("CurrentRole").Equals("Player"))
            {
                GoopSpray.SetActive(false);
                animator.Play("DamageDown");
            }
            else
            {
                animator.Play("Death_Still");
            }
                endText.SetActive(true);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (other.gameObject.name.Equals("Floor"))
        {
            transform.position += Vector3.up * 0.5f;
           // cameraFollow.offset += new Vector3(0, -0.1f, 1f);

        }
    }
}
