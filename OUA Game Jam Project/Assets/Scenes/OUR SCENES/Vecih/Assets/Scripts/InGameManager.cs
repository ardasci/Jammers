using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcon;

    [SerializeField]
    Button musicButton;

    private void Start()
    {
        CheckMusicSetting();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(1);
        UnityEngine.Time.timeScale = 1;
    }

    public void GamePause()
    {
        UnityEngine.Time.timeScale = 0;
    }

    public void GameResume()
    {
        UnityEngine.Time.timeScale = 1;
    }
    public void GameExit()
    {
        UnityEngine.Time.timeScale = 1;
        Application.Quit();
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