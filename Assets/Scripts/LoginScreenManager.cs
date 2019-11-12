using UnityEngine;
using UnityEngine.UI;

public class LoginScreenManager : MonoBehaviour
{
    public InputField id, pass;
    public string ID = "george", PASS="george@1234";
    public GameObject LoginPanel, MainScene;
    public Text incorrectid;
    public AudioSource audio;

    public void OnLoginButtonPressed()
    {
        audio.Play();
        if(id.text==ID && pass.text == PASS)
        {
            LoginPanel.SetActive(false);
            MainScene.SetActive(true);
        }
        else
        {
            Color color = incorrectid.color;
            color.a = 255;
            incorrectid.color = color;
        }
    }
}
