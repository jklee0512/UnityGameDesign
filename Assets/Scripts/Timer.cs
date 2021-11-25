using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float time;
    float sec;
    float min;

    private void Start()
    {
        StartCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        while(true)
        {
            time += Time.deltaTime;
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("진행시간 : {0:00}:{1:00}", min, sec);

            yield return null;
        }
    }
}
