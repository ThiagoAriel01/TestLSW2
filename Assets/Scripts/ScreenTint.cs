using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTint : MonoBehaviour
{
    [SerializeField] Color unTintedColor;
    [SerializeField] Color tintedColor;
    float f;
    [SerializeField] float speed = 0.5f;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start() { Tint(); }
    
    public void Tint()
    {
        f = 0f;
        Debug.Log("UnTint");
        StartCoroutine(TintScreen());
    }

    public void UnTint()
    {
        f = 0f;
        
        StartCoroutine(UnTintScreen());
    }

    IEnumerator TintScreen()
    {
        while (f < 1f)
        {
            Debug.Log("TintScreen");
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
        UnTint();
    }

    IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(tintedColor, unTintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }
}
