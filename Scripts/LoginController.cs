using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{

    [SerializeField] Button _cýkýsButton,_RestartButton;


    public void Cýkýs()
    {
        Application.Quit();
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);      
        Time.timeScale = 1;
       
    }

  

}
