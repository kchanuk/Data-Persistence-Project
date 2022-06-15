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
    public GameObject pleaseText;



    void Start()
    {
        ScoreManager.Instance.LoadScore();
        bestScoreText.text= "Score :"+ScoreManager.Instance.score+"  Name : "+ScoreManager.Instance.name;
        
    }
    public void StartNew()
    {
        string userName=playerNameText.text.ToString();

        if(userName.Length>1)
        {
            ScoreManager.Instance.playername=userName;
            SceneManager.LoadScene(1);
        }
        else
        {
            pleaseText.SetActive(true);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif

    }
}
