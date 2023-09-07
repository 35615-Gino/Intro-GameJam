using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartButton()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void Level()
    {
        SceneManager.LoadScene("Lijntester");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Gino");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Boris");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Jasper");
    }
}
