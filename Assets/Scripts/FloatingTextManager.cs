using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    private void Update()
    {
        foreach (FloatingText text in floatingTexts)
            text.UpdateFloatingText();
    }
    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.text.text = message;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;

        floatingText.gObject.transform.position = Camera.main.WorldToScreenPoint(position); //Transform world space to screen space sowe can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }
    private FloatingText GetFloatingText()
    {
        FloatingText text = floatingTexts.Find(t => !t.active);
        if (text == null)
        {
            text = new FloatingText();
            text.gObject = Instantiate(textPrefab);
            text.gObject.transform.SetParent(textContainer.transform);
            text.text = text.gObject.GetComponent<Text>();
            floatingTexts.Add(text);
        }
        return text;
    }

}
