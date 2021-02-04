using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏结束线
/// </summary>
public class EndLine : MonoBehaviour
{
    public float intervalTime = 1f;
    public float maxEnterTime = 3f;
    private SpriteRenderer render;
    private float enterTime;
    public bool isFlash;
    private bool flashEnd = true;
    public GameOver gameOver;

    private void Start()
    {
        render = this.GetComponent<SpriteRenderer>();
    }

    public void InitEndLine()
    {
        enterTime = 0;
        isFlash = false;
        flashEnd = true;
    }

    private void Update()
    {
        if(isFlash && flashEnd)
        {
            StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        flashEnd = false;
        render.enabled = true;
        yield return new WaitForSeconds(intervalTime);
        render.enabled = false;
        yield return new WaitForSeconds(intervalTime);
        flashEnd = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enterTime += Time.deltaTime;
        if (enterTime >= maxEnterTime)
        {
            Generator.instance.enabled = false;
            gameOver.SetFinalScore(Scorer.instance.currentScore);
            gameOver.Move();
            this.GetComponent<EdgeCollider2D>().enabled = false;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enterTime = 0;
    }
}
