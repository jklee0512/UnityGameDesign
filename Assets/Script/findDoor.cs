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
            text.text = "����� ���� �ⱸ�� ã������";
        }
        if(state == 2)
        {
            text.text = "���� �ڸ��� ���� �� �ڵ����� ã�ƿ�����";
        }
        if(state == 3)
        {
            text.text = "����ϼ���";
        }
        if(state == 4)
        {
            text.text = "Ending";
        }
    }
}
