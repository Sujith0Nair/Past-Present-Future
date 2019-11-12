using UnityEngine;
using System.Collections;

public class LocalSelectARScript : MonoBehaviour
{
    bool firstOne = true;
    public ARSceneManagerScript manager;
    public GameObject[] bulbs;
    public GameObject one, two;
    public AudioSource right, wrong;

    private void Start()
    {
        if (manager == null)
        {
            manager = GameObject.Find("Jasper").GetComponent<ARSceneManagerScript>();
        }
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                string optionName = hit.transform.name;
                Debug.Log(optionName);
                if (firstOne)
                {
                    switch (optionName)
                    {
                        case "a":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                        case "b":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                        case "c":
                            manager.OnCorrectAnswer();
                            one.SetActive(false);
                            two.SetActive(true);
                            firstOne = false;
                            right.Play();
                            StartCoroutine(Wait());
                            break;
                        case "d":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                    }
                }
                else
                {
                    switch (optionName)
                    {
                        case "a":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                        case "b":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                        case "c":
                            manager.OnCorrectAnswer();
                            one.SetActive(true);
                            two.SetActive(false);
                            firstOne = true;
                            right.Play();
                            StartCoroutine(Wait());
                            break;
                        case "d":
                            hit.transform.gameObject.SetActive(false);
                            manager.OnWrongAnswer();
                            wrong.Play();
                            break;
                    }
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < 4; i++)
        {
            bulbs[i].SetActive(true);
        }
    }
}