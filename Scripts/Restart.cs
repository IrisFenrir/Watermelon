using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 重新开始
/// </summary>
public class Restart : MonoBehaviour
{
    private GameObjectPool pool;
    private Generator generator;
    private Scorer scorer;
    public EndLine endLine;
    public GameOver gameOver;
    public WarningLine warningLine;
    public Transform target;

    private void Start()
    {
        pool = GameObjectPool.instance;
        generator = Generator.instance;
        scorer = Scorer.instance;
    }

    public void RestartGame()
    {
        pool.ClearAll();
        generator.enabled = true;
        generator.InitGenerator();
        scorer.ClearScore();
        scorer.InitScorer();
        endLine.GetComponent<EdgeCollider2D>().enabled = true;
        endLine.GetComponent<Renderer>().enabled = false;
        endLine.InitEndLine();
        warningLine.InitWarningLine();
        gameOver.transform.DOMove(target.position, 3);
    }
}
