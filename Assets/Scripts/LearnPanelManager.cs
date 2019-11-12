using UnityEngine;
using UnityEngine.UI;

public class LearnPanelManager : MonoBehaviour
{
    public Text percentage;
    public Slider slider;
    public float LevelsCompleted = 0f;
    public GameObject BasicScene, IntermediateScene, LearnPanel, MainScenePanel;
    public bool OnMainPage = true, OnBasicsPanel=false, OnIntermPanel=false;
    public AudioSource audio;

    //After each course 0.25 points get added up to the Levels Completed

    //Learning Scene Objects Received
    public GameObject Bpage1, Bpage2, Ipage1, Ipage2;
    
    public void OnBasicsPressed()
    {
        audio.Play();
        LearnPanel.SetActive(false);
        BasicScene.SetActive(true);
        OnBasicsPanel = true;
    }

    public void OnIntermediatePressed()
    {
        audio.Play();
        LearnPanel.SetActive(false);
        IntermediateScene.SetActive(true);
        OnIntermPanel = true;
    }

    private void Update()
    {
        if (LevelsCompleted > 1)
            LevelsCompleted = 1;
        if (LevelsCompleted != 0)
        {
            slider.value = LevelsCompleted;
            percentage.text = (LevelsCompleted * 100).ToString() + "%";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OnMainPage)
            {
                MainScenePanel.SetActive(true);
                LearnPanel.SetActive(false);
                OnMainPage = false;
            }
            else if(OnBasicsPanel)
            {
                LearnPanel.SetActive(true);
                BasicScene.SetActive(false);
                OnMainPage = true;
                OnBasicsPanel = false;
            }
            else if (OnIntermPanel)
            {
                LearnPanel.SetActive(true);
                IntermediateScene.SetActive(false);
                OnMainPage = true;
                OnIntermPanel = false;
            }
        }
    }

    public void OnNextPageBasics()
    {
        audio.Play();
        Bpage1.SetActive(false);
        Bpage2.SetActive(true);
        LevelsCompleted += 0.25f;
    }

    public void OnCompleteCourseBasics()
    {
        audio.Play();
        LevelsCompleted += 0.25f;
        Bpage1.SetActive(true);
        Bpage2.SetActive(false);
        BasicScene.SetActive(false);
        LearnPanel.SetActive(true);
    }

    public void OnNextPageIntermediate()
    {
        audio.Play();
        Ipage1.SetActive(false);
        Ipage2.SetActive(true);
        LevelsCompleted += 0.25f;
    }

    public void OnCompleteCourseIntermediate()
    {
        audio.Play();
        LevelsCompleted += 0.25f;
        Ipage1.SetActive(true);
        Ipage2.SetActive(false);
        IntermediateScene.SetActive(false);
        LearnPanel.SetActive(true);
    }

    public void OnBackPressed()
    {
        if (OnMainPage)
        {
            audio.Play();
            MainScenePanel.SetActive(true);
            LearnPanel.SetActive(false);
            OnMainPage = false;
        }
        else if (OnBasicsPanel)
        {
            audio.Play();
            LearnPanel.SetActive(true);
            BasicScene.SetActive(false);
            OnMainPage = true;
            OnBasicsPanel = false;
        }
        else if (OnIntermPanel)
        {
            audio.Play();
            LearnPanel.SetActive(true);
            IntermediateScene.SetActive(false);
            OnMainPage = true;
            OnIntermPanel = false;
        }
    }
}