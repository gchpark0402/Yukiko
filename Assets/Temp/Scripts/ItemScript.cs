using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemScript : MonoBehaviour
{
    public string itemname;
    private XRGrabInteractable xrGrab;


    public void GetItem()
    {
        GameManager.Instance.GetItem(itemname);
        Destroy(gameObject);
    }

    public void RemoveYashiro()
    {
        GameObject yashrio = GameObject.FindWithTag("yashiro").gameObject;

        if (yashrio != null) Destroy(yashrio);
    }

    public void SpawnEnemy()
    {
        GameManager.Instance.SpawnEnemy();
    }

    public void BGMChange()
    {
        BGMController.Instance.ChangeBGM2();
    }

    
}
