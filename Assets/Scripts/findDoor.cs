using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findDoor : MonoBehaviour
{
    Text text;
    public static int state;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1)
        {
            text.text = "get out";
        }
    }
}
