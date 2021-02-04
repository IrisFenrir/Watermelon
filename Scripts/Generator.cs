using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成器
/// </summary>
public class Generator : MonoBehaviour
{
    public GameObject[] balls;
    public float intervalTime = 0.5f;
    public float minClickIntervalTime = 2f;
    private int count = 0;
    public float clickIntervalTime;
    public GameObject currentBall;
    private GameObjectPool pool;
    public static Generator instance;

    private void Awake()
    {
        instance = this;
    }

    public void InitGenerator()
    {
        count = 0;
        clickIntervalTime = 0;
    }

    private void Start()
    {
        pool = GameObjectPool.instance;
        StartCoroutine(GenerateBall());
    }

    private void Update()
    {
        if(currentBall && (Input.GetMouseButton(0) || Input.touchCount>0))
        {
            if(currentBall != null)
                currentBall.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    this.transform.position.y,this.transform.position.z);
        }
        if(Input.GetMouseButtonUp(0) || (Input.touches.Length>0 && Input.touches[0].phase == TouchPhase.Ended))
        {
            if(currentBall != null)
                currentBall.GetComponent<Rigidbody2D>().gravityScale = 1;
            currentBall = null;
            if(clickIntervalTime >= minClickIntervalTime)
            {
                StartCoroutine(GenerateBall());
                clickIntervalTime = 0;
            }
        }
        clickIntervalTime += Time.deltaTime;
    }

    public IEnumerator GenerateBall()
    {
        yield return new WaitForSeconds(intervalTime);
        int index = count < 5 ? count : Random.Range(0, 4);
        //currentBall = Instantiate(balls[index], this.transform.position,Quaternion.identity);
        currentBall = pool.CreateObject(balls[index].name, balls[index], this.transform.position, Quaternion.identity);
        currentBall.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (count < 5)
            count++;
    }
}
