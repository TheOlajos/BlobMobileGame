using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;

    public GameObject obj;
    public Text txt;

    public Vector3 motion;
    public float duration;
    public float lastShown;


    public void Show(){
        active = true;
        lastShown = Time.time;
        obj.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        obj.SetActive(active);
    }

    public void UpdateFloatingText()

    {
        if(!active) 
        {
            return;
        }

        if(Time.time - lastShown > duration) 
        {
            Hide();
        }

        obj.transform.position += motion * Time.deltaTime;

    }

    
}
