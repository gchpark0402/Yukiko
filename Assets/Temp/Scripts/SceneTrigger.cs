using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public int temp;
    public CutSceneManager cutSceneManager;
    private float timer;
    private bool isFalling = false;
    private bool isEnemySpawned = false;

    private void Update()
    {
        if(isFalling)
        {
            timer += Time.deltaTime;
            if(timer > 4)
            {
                GameObject floor2 = GameObject.FindWithTag("Floor2");
                if (floor2 != null) Destroy(floor2);
                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (SceneManager.GetActiveScene().name == "CinemaScene2")
        {
            if (temp == 0)
            {
                cutSceneManager.ChangeText3();
                Destroy(this.gameObject);
            }
            else if (temp == 1)
            {
                GameObject floor = GameObject.FindWithTag("Floor");
                GameObject terrian = GameObject.FindWithTag("Terrain");
                GameObject aisle = GameObject.FindWithTag("Aisle");
                if (floor != null) Destroy(floor);
                terrian.SetActive(false);
                aisle.SetActive(true);
                cutSceneManager.ChangeText4();
                Destroy(this.gameObject);
            }
            else if (temp == 2)
            {
                isFalling = true;
            }
            else
            {
                SceneManager.LoadScene("CaveScene");
            }

        }
        else if (SceneManager.GetActiveScene().name == "CaveScene")
        {
            SceneManager.LoadScene("HouseScene");
            BGMController.Instance.ChangeBGM1();
        }
        else if (SceneManager.GetActiveScene().name == "HouseScene")
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if(!isEnemySpawned && temp == 0)
                {
                    GameManager.Instance.SpawnEnemy2();
                    isEnemySpawned = true;
                }
                else
                {
                    Application.Quit();
                }
                              
            }
            if(collision.gameObject.CompareTag("Enemy"))
            {
                if(temp == 1)
                {
                    BGMController.Instance.ChangeBGM2();
                }
            }
            
        }
       
    }
}
