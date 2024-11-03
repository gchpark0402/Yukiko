using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        /*Vector3 screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        dir = Camera.main.ScreenPointToRay(screenCenter).direction;*/

    }

    // Update is called once per frame
    void Update()
    {
        Projectile();
    }

    void Projectile()
    {
        transform.LookAt(dir);
        transform.position += dir * 20 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
