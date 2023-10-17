using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChoose : MonoBehaviour
{
    public void LoadOne()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void LoadTwo()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void LoadThree()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void LoadFour()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void LoadFive()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void LoadSix()
    {
        SceneManager.LoadSceneAsync(7);
    }
}
