using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 球
/// </summary>
public class Ball : MonoBehaviour
{
    public int score;
    public AudioClip[] audios;
    private Synthesizer synthesizer;
    private GameObjectPool pool = GameObjectPool.instance;

    private void Start()
    {
        synthesizer = GameObject.FindGameObjectWithTag("Synthesizer").GetComponent<Synthesizer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball" && 
            score == collision.gameObject.GetComponent<Ball>().score)
        {
            if(synthesizer.gameObject.activeSelf && this.GetComponent<Ball>().score != 512)
            {
                synthesizer.Synthesis(this.gameObject, collision.gameObject, score);
                pool.CollectObject(this.gameObject);
            }
        }
    }
}
