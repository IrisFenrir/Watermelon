using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 游戏结束
/// </summary>
public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public Transform target;

    public void SetFinalScore(int score)
    {
        finalScore.text = score.ToString();
    }

    public void Move()
    {
        this.transform.DOMove(target.position, 5);
    }
}
