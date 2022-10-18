using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypewriterEffect : MonoBehaviour
{
    public float writingSpeed = 50f;
    private string currentText;
    private TMP_Text currentTextBox;
    public bool currentlyTyping = false;
    private bool containsDotPause = false;
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

        while(charIndex < textToType.Length)
        {
            if (textToType[charIndex] == '.' && containsDotPause)
            {
                Debug.Log("Slow delta");
                t += Time.deltaTime * 2;
            }
            else
            {
                t += Time.deltaTime * writingSpeed;
            }

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
        currentlyTyping = false;
        containsDotPause = false;

    }
}
