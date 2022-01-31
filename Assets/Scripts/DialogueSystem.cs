using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image portrait;

    DialogueContainer currentDialog;
    int currentTextLine;

    [Range(0f,1f)] 
    [SerializeField] float visibleTextPercent, timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;

    DialogueSystem dialogueSystem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            PushText();
        TypeOutText();
    }

    void TypeOutText()
    {
        if (visibleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0, 1f);
        UpdateText();
    }

    void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    void PushText()
    {
        if(visibleTextPercent < 1f) { 
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }
        if (currentTextLine >= currentDialog.line.Count)
            Conclude();
        else
            CycleLine();
    }

    void CycleLine()
    {
        lineToShow = currentDialog.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f; 
        targetText.text = "";

        currentTextLine++;
    }

    public void Init(DialogueContainer dialogueContainer)
    {
        Show(true);
        currentDialog = dialogueContainer;
        currentTextLine = 0;
        CycleLine();
        UpdatePortrait();

    }

    void UpdatePortrait()
    {
        portrait.sprite = currentDialog.actor.portrait;
        nameText.text = currentDialog.actor.name;
    }

    void Conclude()
    {
        Debug.Log("The dialogue has ended");
        Show(false);
    }

    void Show(bool v)
    {
        //if (!dialogueSystem.gameObject.activeInHierarchy)
            gameObject.SetActive(v);
    }
}
