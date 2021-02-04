using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 计分器
/// </summary>
public class Scorer : MonoBehaviour
{
    public int currentScore;
    public float numberWidth = 43;
    public GameObject[] numbers;
    private GameObjectPool pool;
    private Dictionary<int, GameObject> scoreDic;
    public static Scorer instance;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        pool = GameObjectPool.instance;
        scoreDic = new Dictionary<int, GameObject>();
        UpdateScore(0);
    }

    public void InitScorer()
    {
        currentScore = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        string currentScoreStr = currentScore.ToString();
        string scoreStr = score.ToString();

        for (int i = 0; i < scoreStr.Length; i++)
        {
            if(scoreStr.Length != currentScoreStr.Length || scoreStr[i] != currentScoreStr[i]
                || score == 0)
            {
                if(scoreDic.ContainsKey(i))
                {
                    pool.CollectObject(scoreDic[i]);
                }
                else
                {
                    scoreDic.Add(i, null);
                }
                int index = int.Parse(scoreStr[i].ToString());
                GameObject number = pool.CreateObject(numbers[index].name, numbers[index],
                    this.transform.position + i * Vector3.right * numberWidth, Quaternion.identity);
                scoreDic[i] = number;
            }
        }
        currentScore = score;
    }

    public void ClearScore()
    {
        scoreDic.Clear();
    }

}
