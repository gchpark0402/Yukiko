using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUICanvas : MonoBehaviour
{
    public GameObject jadeUI;
    public GameObject amuletUI;
    public GameObject swordUI;

    // Start is called before the first frame update
    void Start()
    {
        jadeUI = this.transform.GetChild(0).gameObject;
        amuletUI = this.transform.GetChild(1).gameObject;
        swordUI = this.transform.GetChild(2).gameObject;
    }

    

    public void ActiveSword()
    {
        swordUI.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void ActiveJade()
    {
        jadeUI.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void ActiveAmulet()
    {
        amuletUI.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void DeactiveSword()
    {
        swordUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void DeactiveJade()
    {
        jadeUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void DeactiveAmulet()
    {
        amuletUI.SetActive(false);
        Time.timeScale = 1;
    }
}
