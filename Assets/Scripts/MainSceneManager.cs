using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public GameObject MainScenePanel ,learnPanel, playPanel, learnSubPanel, playSubPanel;
    LearnPanelManager learnManager;
    PlaySceneManager playManager;
    public AudioSource audio;
    
    public void OnLearnPressed()
    {
        MainScenePanel.SetActive(false);
        learnPanel.SetActive(true);
        learnSubPanel.SetActive(true);
        learnManager.OnMainPage = true;
        audio.Play();
    }

    public void OnPlayPressed()
    {
        MainScenePanel.SetActive(false);
        playPanel.SetActive(true);
        playSubPanel.SetActive(true);
        playManager.OnMainScene = true;
        audio.Play();
    }
}
