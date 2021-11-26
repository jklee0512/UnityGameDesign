using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("√‚±∏ø° ∫ŒµÛ»˚");
        if (Score.coinAmount == 0)
        {
            if (findDoor.state != 3)
            {
                findDoor.state = 2;
            }
        }
        if(findDoor.state == 3)
        {
            SceneManager.LoadScene(1);
            findDoor.state = 4;
        }
    }
}
