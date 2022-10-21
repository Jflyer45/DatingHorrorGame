using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypewriterEffect : MonoBehaviour
{
    public float writingSpeed = 50f;
    private string currentText;
    private TMP_Text currentTextBox;
    private AudioSource AS;
    public bool currentlyTyping = false;
    private bool containsDotPause = false;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void Run(string textToType, TMP_Text textLabel)
    {
        if (textToType.Contains(". . .") || textToType.Contains("..."))
        {
            containsDotPause = true;
        }
        StartCoroutine(TypeText(textToType, textLabel));
    }

    public void FinishEarly()
    {
        if (currentlyTyping)
        {
            StopAllCoroutines();
            currentTextBox.text = currentText;
            currentlyTyping = false;
            containsDotPause = false;
        }
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        currentlyTyping = true;
        currentTextBox = textLabel;
        float t = 0;
        int charIndex = 0;
        currentText = textToType;
        string formerText = "";
        AS.Play();

        while (charIndex < textToType.Length)
        {
            if (textToType[charIndex] == '.' && containsDotPause)
            {
                t += Time.deltaTime * 2;
            }
            else
            {
                t += Time.deltaTime * writingSpeed;
            }

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            string newStringLength = textToType.Substring(0, charIndex);
            textLabel.text = newStringLength;

            if(textToType[charIndex] == ' ')
            {
                AS.Play();
            }

            yield return null;
        }
        textLabel.text = textToType;
        currentlyTyping = false;
        containsDotPause = false;

    }
}
