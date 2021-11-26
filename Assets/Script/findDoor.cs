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
            text.text = "퇴근을 위해 출구를 찾으세요";
        }
        if(state == 2)
        {
            text.text = "원래 자리에 놓고 온 핸드폰을 찾아오세요";
        }
        if(state == 3)
        {
            text.text = "퇴근하세요";
        }
        if(state == 4)
        {
            text.text = "Ending";
        }
    }
}
