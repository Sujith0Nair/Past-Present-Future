using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
    public GameObject PlayPanel, QuizPanel, ARPanel, MainScene;
    public GameObject[] questions;
    public Button[] buttons;
    public Sprite WrongAnswer, RightAnswer, Choices;
    int index = 0;
    public bool OnMainScene = true, OnQuizPanel = false, OnARScene = false;
    public AudioSource audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OnMainScene)
            {
                MainScene.SetActive(true);
                PlayPanel.SetActive(false);
                OnMainScene = false;
            }
            else if (OnQuizPanel)
            {
                PlayPanel.SetActive(true);
                QuizPanel.SetActive(false);
                OnQuizPanel = false;
                OnMainScene = true;
            }
            else if (OnARScene)
            {
                PlayPanel.SetActive(true);
                ARPanel.SetActive(false);
                OnARScene = false;
                OnMainScene = true;
            }
        }
    }

    public void OnQuizPressed()
    {
        audio.Play();
        PlayPanel.SetActive(false);
        QuizPanel.SetActive(true);
        OnQuizPanel = true;
    }

    public void OnARPressed()
    {
        audio.Play();
        PlayPanel.SetActive(false);
        ARPanel.SetActive(true);
        OnARScene = true;
    }

    public void OnOptionClick(int index)
    {
        audio.Play();
        switch (index)
        {
            case 0:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 1:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 2:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = RightAnswer;
                    StartCoroutine(Wait());
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 3:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 4:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = RightAnswer;
                    StartCoroutine(Wait());
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 5:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 6:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = RightAnswer;
                    StartCoroutine(Wait());
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 7:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            case 8:
                try
                {
                    buttons[index].GetComponent<Image>().sprite = WrongAnswer;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                break;
            default:
                Debug.Log("Didn't catch the value");
                break;
        }
    }


    public void OnNext()
    {
        for(int i =0; i<9; i++)
        {
            buttons[i].GetComponent<Image>().sprite = Choices;
        }
        questions[index].SetActive(false);
        index++;
        if (index == 3)
        {
            index = 0;
        }
        questions[index].SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.3f);
        OnNext();
    }

    public void OnAROpened()
    {
        audio.Play();
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        if (!async.isDone)
        {
            Debug.Log("Error in loading the scene!");
        }
    }

    public void OnBackPressed()
    {
        audio.Play();
        if (OnMainScene)
        {
            MainScene.SetActive(true);
            PlayPanel.SetActive(false);
            OnMainScene = false;
        }
        else if (OnQuizPanel)
        {
            PlayPanel.SetActive(true);
            QuizPanel.SetActive(false);
            OnQuizPanel = false;
            OnMainScene = true;
        }
        else if (OnARScene)
        {
            PlayPanel.SetActive(true);
            ARPanel.SetActive(false);
            OnARScene = false;
            OnMainScene = true;
        }
    }
}