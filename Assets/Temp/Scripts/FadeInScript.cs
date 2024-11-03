using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    public Image image;
    private bool tempbool = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FadeInImage");
        if (tempbool)
        {
            Destroy(this.gameObject);
            tempbool = false;
        }
    }

    IEnumerator FadeInImage()
    {
        Color color = image.color;

        for (int i = 300; i >= 0; i--)
        {
            color.a -= Time.deltaTime * 0.035f;

            image.color = color;

            if(image.color.a <= 0)
            {
                tempbool = true;
            }
        }

        yield return null;
    }
}
