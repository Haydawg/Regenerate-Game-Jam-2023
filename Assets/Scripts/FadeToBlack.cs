using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack Instance;
    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        Instance= this;
    }
    public void StartFade(int time)
    {
        StartCoroutine(Fade(time));
    }
   
    public IEnumerator Fade(int time, int fadeSpeed = 5)
    {
        Color fadeColor = fadeImage.color;
        float fadeAmount;


        while(fadeImage.color.a < 1)
        {
            fadeAmount = fadeColor.a + (fadeSpeed * Time.deltaTime);

            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
            fadeImage.color = fadeColor;
            yield return null;
        }
        
        yield return new WaitForSeconds(time);

        while (fadeImage.color.a > 0)
        {
            fadeAmount = fadeColor.a - (fadeSpeed * Time.deltaTime);
            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
            fadeImage.color = fadeColor;
            yield return null;
        }
        
    }

}
