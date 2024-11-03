using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator ghostAnimator;
    private float waitingTime;
    public GameObject target;

    private int health = 3;
    private float healthWaitingTime;
    private bool isDamaged;
    
    public GameObject fireParticle;
    public GameObject bloodParticle;
    Queue<GameObject> projectileEffect = new Queue<GameObject>();
    
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    public NavMeshAgent nav;

    private bool isCollide;
    private bool hasProjectile;
    public AudioClip swordSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        target = GameObject.FindWithTag("Player");
        if (audioSource != null) this.gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player");
        if (nav == null) Debug.Log("nav null");
        if (target == null) Debug.Log("player not found");

        nav.SetDestination(target.transform.position);
        this.gameObject.transform.forward = DestinationVector();

        if (projectileEffect.Count  != 0)
        {
            waitingTime += Time.deltaTime;

            if (waitingTime > 4)
            {
                waitingTime = 0;
                Destroy(projectileEffect.Dequeue());
            }
            if (waitingTime > 1f)
            {
                this.GetComponent<Rigidbody>().AddForce(DestinationVector());
                this.GetComponent<NavMeshAgent>().speed = 4.7f;
                ghostAnimator.SetBool("isDamaged", false);
            }
        }

        if (isDamaged)
        {
            healthWaitingTime += Time.deltaTime;
            if (healthWaitingTime > 1)
            {
                isDamaged = false;
                healthWaitingTime = 0;
            }
        }

        if(health <= 0)
        {
            ghostAnimator.SetBool("isDead", true);
            nav.isStopped = true;
            GameObject wall = GameObject.FindWithTag("Obstacle");
            if (wall != null) Destroy(wall);
        }

        if (isCollide)
        {
            StartCoroutine(RecoverCollision());
            isCollide = false;
        }


    }

    float Distance(Transform target)
    {
        return Vector3.Distance(target.position, this.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            showEffect(collision);
            this.GetComponent<NavMeshAgent>().speed = 3f;
            GameManager.Instance.HapticFeedback(0.2f, 0.2f);
            ghostAnimator.SetBool("isDamaged", true);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            this.GetComponent<Rigidbody>().AddForce(- DestinationVector() * 3f);
            isCollide = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.CharacterDead();
        }
        if(collision.gameObject.tag == "Sword")
        {
            if (!isDamaged)
            {
                GetDamaged();
                showEffect2(collision);
            }
        }


    }



    void showEffect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject Effect = Instantiate(fireParticle, contact.point, rot);
        Effect.transform.SetParent(this.transform);
        projectileEffect.Enqueue(Effect);
    }

    void showEffect2(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject Effect = Instantiate(bloodParticle, contact.point, rot);
        Effect.transform.SetParent(this.transform);
    }



    IEnumerator RecoverCollision()
    {
        Debug.Log("collide");
        this.GetComponent<Rigidbody>().AddForce(DestinationVector());
        yield return new WaitForSeconds(1.5f);
        
    }

    Vector3 DestinationVector() { return (target.transform.position - transform.position).normalized; }

    private void GetDamaged()
    {
        GameManager.Instance.HapticFeedback(0.2f, 0.2f);
        isDamaged = true;
        health -= 1;
    }
}
