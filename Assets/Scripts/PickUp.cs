using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Score.coinAmount -= 1;
        if(Score.coinAmount == 0)
        {
            findDoor.state = 1;
        }
        Destroy(gameObject);
    }
}
