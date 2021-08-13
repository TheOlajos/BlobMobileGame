using System.Globalization;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTextList = new List<FloatingText>();

    private void Update() 
    {
        foreach (FloatingText txt in floatingTextList)
        {
            txt.UpdateFloatingText();
        }
            
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) 
    {
        FloatingText floatingTxt = GetFloatingText();

        floatingTxt.txt.text = msg;
        floatingTxt.txt.fontSize = fontSize;
        floatingTxt.txt.color = color;

        floatingTxt.obj.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingTxt.motion = motion;
        floatingTxt.duration = duration;

        floatingTxt.Show();
   }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTextList.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.obj = Instantiate(textPrefab);
            txt.obj.transform.SetParent(textContainer.transform);
            txt.txt = txt.obj.GetComponent<Text>();

            floatingTextList.Add(txt);
        }

        return txt;
    }

}
