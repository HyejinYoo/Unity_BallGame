using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCountText;
    public Text PlayerCountText;

    private void Awake()
    {
        stageCountText.text = "/ " + totalItemCount.ToString();
    }

    public void GetItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Stage_" + stage.ToString());
        }   
    }

}
