using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 切换场景
/// </summary>
public class Menu : MonoBehaviour
{
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }    

    public void Exit()
    {
        Application.Quit();
    }
}
