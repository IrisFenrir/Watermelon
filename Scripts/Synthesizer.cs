using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成器
/// </summary>
public class Synthesizer : MonoBehaviour
{
    public GameObject[] balls;
    private int[] scores;
    private GameObjectPool pool;
    private Scorer scorer;
    private AudioManager audioManager;

    private void Start()
    {
        pool = GameObjectPool.instance;
        scorer = Scorer.instance;
        audioManager = AudioManager.instance;
        scores = ArrayHelper.Select(balls, g => g.GetComponent<Ball>().score);
    }

    public void Synthesis(GameObject obj1,GameObject obj2,int score)
    {
        if (obj1.activeSelf && obj2.activeSelf)
        {
            GameObject target = obj1.transform.position.y < obj2.transform.position.y ? obj1 : obj2;

            AudioClip[] audios = target.GetComponent<Ball>().audios;
            audioManager.PlayAudio(audios[UnityEngine.Random.Range(0, audios.Length - 1)]);
            
            int index = BallIndex(target.GetComponent<Ball>().score);
            GameObject go = pool.CreateObject(balls[index].name, balls[index], target.transform.position, Quaternion.identity);
            scorer.UpdateScore(scorer.currentScore + score);
        }
    }

    private int BallIndex(int targetScore)
    {
        int index = Array.IndexOf(scores, targetScore);
        return index + 1 == scores.Length ? index : index + 1;
    }
}
