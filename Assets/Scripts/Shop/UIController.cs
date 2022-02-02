using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;

    private void ClickSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void MouseClick(string buttonType)
    {
        if (buttonType == "Exit")
            Application.Quit();
        if (buttonType == "HowToPlay")
            menuCanvas.SetActive(true);
        if (buttonType == "Start")
            SceneManager.LoadScene("SampleScene");
    }
}
