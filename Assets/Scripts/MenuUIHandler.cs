using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI playerNameText;


    void Start()
    {
        ScoreManager.Instance.LoadScore();
        bestScoreText.text= "Score :"+ScoreManager.Instance.score+"  Name : "+ScoreManager.Instance.name;
        
    }
    public void StartNew()
    {
        var text=playerNameText.text;
        if(!string.IsNullOrEmpty(text))
        {
            ScoreManager.Instance.name=playerNameText.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            ApplicationException.Quit();
        #endif

    }
}
