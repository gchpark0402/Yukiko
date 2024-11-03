using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("dead");
            GameManager.Instance.CharacterDead();
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.tag);
        }
        else
        { 
            Debug.Log(other.gameObject.tag);
        }
    }
}
