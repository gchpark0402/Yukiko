using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JadeSocketScript : MonoBehaviour
{
    private bool isJade = false;

    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject handle1;
    [SerializeField]
    private GameObject handle2;
    [SerializeField]
    private GameObject door1;
    [SerializeField]
    private GameObject door2;

    // Start is called before the first frame update

    // Update is called once per frame
    public void CheckJade()
    {
        Debug.Log("checkjade");
        isJade = true;
        Destroy(wall);
        handle1.SetActive(true);
        handle2.SetActive(true);
       
        if (isJade) Destroy(transform.parent.gameObject);
    }
}
