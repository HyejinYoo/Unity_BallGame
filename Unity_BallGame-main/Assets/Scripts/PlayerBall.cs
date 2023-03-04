using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumppower;
    public int itemCount = 0;
    bool isJump;
    public GameManagerLogic manager;
    AudioSource audio;
    Rigidbody rigid;
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") { 
            itemCount++;
            manager.GetItem(itemCount);
            audio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                if (manager.stage == 5)
                {
                    SceneManager.LoadScene("Stage_1");
                }
                else
                {
                    SceneManager.LoadScene("Stage_" + (manager.stage + 1).ToString());
                }
            }
            else
            {
               SceneManager.LoadScene("Stage_" + manager.stage.ToString());
            }
        }
    }
}
