using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneManagerScript : MonoBehaviour
{
    public Animator jasper;

    private void Start()
    {
        if (this.gameObject.name == "Jasper")
        {
            jasper = this.GetComponent<Animator>();
        }
        else
        {
            jasper = GameObject.Find("Jasper").GetComponent<Animator>();
        }        
        jasper.Play("Waving");
        StartCoroutine(Wait());
        jasper.Play("Waving");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(0);
            if (!async.isDone)
            {
                Debug.Log("Error in loading the scene!");
            }
        }
    }

    public void OnCorrectAnswer()
    {
        jasper.Play("Victory");
    }

    public void OnWrongAnswer()
    {
        jasper.Play("Sad Idle");
    }

    public void DanceBabe()
    {
        jasper.Play("Wave Hip Hop Dance");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
