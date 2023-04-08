using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject fadeBg;

    public void Start()
    {
        anim =Camera.main.GetComponent<Animator>();   
    }

    public void GameStart()
    {
        StartCoroutine(StartGame());
    }



    public IEnumerator StartGame()
    {
        anim.SetTrigger("play");
        fadeBg.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
        
}

