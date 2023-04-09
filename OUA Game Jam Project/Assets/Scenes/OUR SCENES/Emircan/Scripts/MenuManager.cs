using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject fadeBg;

    [SerializeField] Sprite[] musicIcon;
    [SerializeField] Button musicButton;

    public void Start()
    {
        anim =Camera.main.GetComponent<Animator>();

        if (Save.isMusicSave() == false)
        {
            Save.MusicOnSetValue(1);
        }
        CheckMusicSetting();
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

    public void Music()
    {
        if (Save.MusicOnGetValue() == 1)
        {
            Save.MusicOnSetValue(0);
            MusicManager.instance.MusicPlay(false);
            musicButton.image.sprite = musicIcon[0];
        }
        else
        {
            Save.MusicOnSetValue(1);
            MusicManager.instance.MusicPlay(true);
            musicButton.image.sprite = musicIcon[1];
        }
    }


    void CheckMusicSetting()
    {
        if (Save.MusicOnGetValue() == 1)
        {
            musicButton.image.sprite = musicIcon[1];
            MusicManager.instance.MusicPlay(true);
        }
        else
        {
            musicButton.image.sprite = musicIcon[0];
            MusicManager.instance.MusicPlay(false);
        }
    }
}

