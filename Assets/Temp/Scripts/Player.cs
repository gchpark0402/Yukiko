using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectile;
    private ProjectileScript projectileScript;
    private GameObject enemy;
    private float waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        projectileScript = projectile.GetComponent<ProjectileScript>();

        waitingTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        Projectile();
    }

    void CharacterMove()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.01f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.01f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, 0.0f, 0.01f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, 0.0f, -0.01f);
        }*/
    }

    void Projectile()
    {
        waitingTime += Time.deltaTime;
        if(waitingTime > 5)
        {
            Instantiate(projectile, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
            waitingTime = 0;
            /*if (Input.GetMouseButton(0))
            {
                
            }*/
        }
    }
}
