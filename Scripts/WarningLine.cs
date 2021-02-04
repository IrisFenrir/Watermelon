using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 警告线
/// </summary>
public class WarningLine : MonoBehaviour
{
    public EndLine endLine;
    public float maxEnterTime = 2f;
    public float enterTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        enterTime += Time.deltaTime;
        if(enterTime >= maxEnterTime)
        {
            print("Warning");
            //endLine.GetComponent<Renderer>().enabled = true;
            endLine.isFlash = true;
        }
    }

    public void InitWarningLine()
    {
        enterTime = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enterTime = 0;
        //endLine.GetComponent<Renderer>().enabled = false;
        endLine.isFlash = false;
    }
}
