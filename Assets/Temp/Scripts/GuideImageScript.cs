using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideImageScript : MonoBehaviour
{
    private float time = 0;
    private bool temp = false;

    public void SetActive()
    {
        this.gameObject.SetActive(true);
        temp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(temp)
        {
            time += Time.deltaTime;
            if(time > 2)
            {
                this.gameObject.SetActive(false);
                time = 0;
            }
        }
        
    }
}
