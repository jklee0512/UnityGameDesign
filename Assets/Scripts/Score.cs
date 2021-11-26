using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 5;

        text = GetComponent<Text>();
        text.text = string.Format("³²Àº °¹¼ö : {0}", coinAmount);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("³²Àº °¹¼ö : {0}", coinAmount);
    }
}
