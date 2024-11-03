using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null) return null;
            return instance;
        }
    }

    private bool getAmulet = false;
    private bool getSword = false;
    private bool getJade = false;

    [SerializeField]
    private GameObject amulet;
    public Transform playerTransform;
    private float amuletCoolTime = 0;

    public GameObject rightHandCanvas;
    private bool buttonActive = false;
    private float buttonCoolTime = 0;

    public bool hasAmulet = false;
    public bool hasSword = false;
    private float amuletAnimCoolTime = 0;
    private float swordAnimCoolTime = 0;
    public GameObject jyuhu;
    public GameObject sword;

    [SerializeField]
    private GameObject jade;
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject Enemy2;
    private Vector3 EnemySpawnPoint = new Vector3(-25.5f, -6.8f, -43.6f);

    private GameObject Lefthand;
    private GameObject Righthand;
    Vector3 amuletDir;
    XRBaseController LeftControllerForHaptic;
    XRBaseController RightControllerForHaptic;
    public GuideUICanvas guideUI;


    private bool restart;
    private float restartTime = 0;
    private GameObject playerCam;
    public GameObject dyingScene;


    // Start is called before the first frame update
    void Start()
    {
        Lefthand = GameObject.FindWithTag("LeftHand");
        Righthand = GameObject.FindWithTag("RightHand");

        jyuhu = GameObject.FindWithTag("Jyuhu");
        sword = GameObject.FindWithTag("Sword");
        jyuhu.SetActive(false);
        sword.SetActive(false);

        LeftControllerForHaptic = Lefthand.GetComponent<XRBaseController>();
        RightControllerForHaptic = Righthand.GetComponent<XRBaseController>();
        rightHandCanvas = GameObject.FindWithTag("Canvas");
        rightHandCanvas.SetActive(false);
        guideUI = GameObject.FindWithTag("GuideUI").GetComponent<GuideUICanvas>();
        playerCam = Camera.main.gameObject;

        dyingScene = GameObject.FindWithTag("DyingScene");
        dyingScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonCoolTime <= 1.2) buttonCoolTime += Time.deltaTime;
        if (amuletCoolTime <= 2.2) amuletCoolTime += Time.deltaTime;
        if (swordAnimCoolTime <= 1.7) swordAnimCoolTime += Time.deltaTime;
        if (amuletAnimCoolTime <= 1.7) amuletAnimCoolTime += Time.deltaTime;

        amuletDir = Righthand.transform.forward;

        if(restart)
        {
            restartTime += Time.deltaTime;
            if(restartTime > 1f)
            {
                Restart();
                restartTime = 0;
                restart = false;
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Lefthand = GameObject.FindWithTag("LeftHand");
        Righthand = GameObject.FindWithTag("RightHand");

        if (SceneManager.GetActiveScene().name == "HouseScene")
        {
            jyuhu = GameObject.FindWithTag("Jyuhu");
            jyuhu.SetActive(false);
            sword = GameObject.FindWithTag("Sword");
            sword.SetActive(false);
            LeftControllerForHaptic = Lefthand.GetComponent<XRBaseController>();
            RightControllerForHaptic = Righthand.GetComponent<XRBaseController>();
            rightHandCanvas = GameObject.FindWithTag("Canvas");
            rightHandCanvas.SetActive(false);
            if (guideUI == null) guideUI = GameObject.FindWithTag("GuideUI").GetComponent<GuideUICanvas>();
            playerCam = Camera.main.gameObject;
            dyingScene = GameObject.FindWithTag("DyingScene");
            dyingScene.SetActive(false);
        }
    }

    private void UpdatePlayerTransform()
    { playerTransform = GameObject.FindWithTag("Player").transform; }

    public void buttontemp()
    {
        Debug.Log("button click");
        rightHandCanvas.SetActive(false);
        buttonActive = false;
        buttonCoolTime = 0;
        Time.timeScale = 1f;
    }

    public void GetItem(string item)
    {
        switch (item)
        {
            case "sword":
                getSword = true;
                guideUI.ActiveSword();
                break;
            case "amulet":
                getAmulet = true;
                guideUI.ActiveAmulet();
                break;
            case "jade":
                getJade = true;
                guideUI.ActiveJade();
                break;
            default:
                break;
        }
    }

    public void SetItemSelect(string item)
    {
        ItemEvent(item);

        Debug.Log(item);
    }

    private void ItemEvent(string item)
    {
        switch (item)
        {
            case "sword":
                if(getSword)
                {
                    if (swordAnimCoolTime >= 1.5)
                    {
                        if (hasSword)
                        {
                            sword.SetActive(false);

                        }
                        else
                        {
                            sword.SetActive(true);

                        }
                        hasSword = !hasSword;
                        swordAnimCoolTime = 0;
                    }
                }
               
                break;
            case "amulet":
                if(getAmulet)
                {
                    if (amuletAnimCoolTime >= 1.5)
                    {
                        if (hasAmulet)
                        {
                            jyuhu.SetActive(false);
                        }
                        else
                        {
                            jyuhu.SetActive(true);
                        }
                        hasAmulet = !hasAmulet;
                        amuletAnimCoolTime = 0;
                    }
                }
                break;
            case "jade":
                if (getJade)
                {
                    UpdatePlayerTransform();
                    Instantiate(jade, playerTransform.position + new Vector3(0, 1, 0), Quaternion.identity);
                }
                break;
            default:
                break;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, EnemySpawnPoint, Quaternion.identity);
    }
    public void SpawnEnemy2()
    {
        Instantiate(Enemy2, new Vector3(14.7f, 3.5f, -23), Quaternion.identity);
    }




    public void LeftPrimaryButton()
    {
        Debug.Log("Left Primary");
        if (rightHandCanvas != null)
        {
            Debug.Log("rightHandCanvas is ready");
            if (buttonCoolTime >= 1)
            {
                if (!buttonActive)
                {
                    rightHandCanvas.SetActive(true);
                    buttonActive = true;
                    buttonCoolTime = 0;
                    Time.timeScale = 0.1f;
                }
                else
                {
                    rightHandCanvas.SetActive(false);
                    buttonActive = false;
                    buttonCoolTime = 0;
                    Time.timeScale = 1f;
                }
            }
        }
    }

    public void LeftSecondaryButton()
    {
        Debug.Log("left Secondary activated");
        if (amulet != null)
        {
            if (getAmulet)
            {
                if (amuletCoolTime >= 2)
                {
                    Instantiate(amulet, Righthand.transform.position, Quaternion.identity);
                    amulet.GetComponent<ProjectileScript>().dir = amuletDir;
                    amuletCoolTime = 0;
                }
            }

        }
    }
    public void RightPrimaryButton()
    {
        Debug.Log("right primary activated");
        HapticFeedback(0.1f, 0.1f);

        if (rightHandCanvas != null)
        {
            Debug.Log("rightHandCanvas is ready");
            if (buttonCoolTime >= 1)
            {
                if (!buttonActive)
                {
                    rightHandCanvas.SetActive(true);
                    buttonActive = true;
                    buttonCoolTime = 0;
                    Time.timeScale = 0.1f;
                }
                else
                {
                    rightHandCanvas.SetActive(false);
                    buttonActive = false;
                    buttonCoolTime = 0;
                    Time.timeScale = 1f;
                }
            }
        }
    }

    public void RightSecondaryButton()
    {
        Debug.Log("right secondary activated");
        if (amulet != null)
        {
            if (getAmulet)
            {
                if (amuletCoolTime >= 1.5)
                {
                    Instantiate(amulet, Righthand.transform.position, Quaternion.identity);
                    amulet.GetComponent<ProjectileScript>().dir = amuletDir;
                    amuletCoolTime = 0;
                }
            }
        }
    }

    public void HapticFeedback(float amplitude, float duration)
    {
        LeftControllerForHaptic.SendHapticImpulse(amplitude, duration);
        RightControllerForHaptic.SendHapticImpulse(amplitude, duration);
    }

    public void CharacterDead()
    {
        if(!getSword)
        {
            restart = true;
            playerCam.SetActive(false);
            dyingScene.SetActive(true);


        }
        
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        BGMController.Instance.ChangeBGM1();
    }

}


