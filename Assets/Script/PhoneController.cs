using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {    
        if (Score.coinAmount == 0)
        {
            findDoor.state = 3;
            Destroy(gameObject);
        }
        
    }
}
