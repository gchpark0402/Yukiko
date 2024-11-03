using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CutSceneManager : MonoBehaviour
{
    public Canvas canvas;
    public Animator GirlAnimator;
    public GameObject text;
    private TMP_Text tmpText;

    private bool GirlTalking;
    public string[] speak;
    private int speakIndex = -1;
    private float speakTimeLimit = 0;

    public GameObject speak1;
    public GameObject speak2;


    // Start is called before the first frame update
    void Start()
    {
        speak = new string[20];
        text.SetActive(false);
        GirlTalking = false;
        Addspeak();
        tmpText = text.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GirlAnimator != null) GirlAnimator.SetBool("Talking", GirlTalking);

        if (speakTimeLimit < 8.2f) speakTimeLimit += Time.deltaTime;

        if(speakIndex >= 0) tmpText.text = speak[speakIndex];

        if (speakTimeLimit > 8) text.SetActive(false);
    }

    public void Talking()
    {
        GirlTalking = true;
    }
    
    public void StopTalking()
    {
        GirlTalking = false;
    }

    public void Addspeak()
    {
        speak[0] = "어이. 아직도 자고 있는 거야? 일어나 잠꾸러기야. 이제 거의 다 왔으니까 말이야.";
        speak[1] = "그래. 모처럼 온 담력훈련인데 좀 즐겨보자구.";
        speak[2] = "맞아맞아. 여름방학이라고 하면 담력훈련이잖아? 진짜 기대된다.";
        speak[3] = "근데 정말 소문의 그 집이 맞을까?";
        speak[4] = "소문에 의하면 에도시대때 그 집에 살던 여자를 보고 한 눈에 반한 사무라이가 찝적대다가,";
        speak[5] = " 자신을 받아주지 않자 홧김에 일가족을 몰살했데. 정말 끔찍해. 어떻게 사람이 그럴 수 있지?";
        speak[6] = "그러게 말이야. 그래서 그 여자가 원통함을 못 참고 죽어버려서 귀신이 되었다는 얘기였지?";
        speak[7] = "직접 가서 보면 확인할 수 있겠지. 어찌됐든 으스스한 곳임에는 틀림없어.";
        speak[8] = "차까지 타고 멀리 왔는데 시간 낭비만 아니었으면 좋겠다.";
        speak[9] = "도착했어. 다들 차에서 내려";
        speak[10] = "으...생각했던 거 보다 더 기분 나쁜 집이네. 난 먼저 안 들어갈래.";
        speak[11] = "음... 그러면 아까까지 자고 있던 누군가가 먼저 들어갈까? 벌칙으로 그 정도는 해야지.";
        speak[12] = "그거 좋네! 너가 먼저 들어가봐.";
        speak[13] = "안은 생각보다 깨끗하네. 좀 더 어서 들어가보자.";
        speak[14] = "우와?! 위험하네.  빨리 내 손잡아!";

    }

    public void ChangeText()
    {
        speakIndex++;
        text.SetActive(true);
        speakTimeLimit = 0;
    }

    public void ChangeText2()
    {
        speakIndex = 10;
        text.SetActive(true);
        speakTimeLimit = 0;
    }

    public void ChangeText3()
    {
        speak1.SetActive(true);
        speakIndex = 13;
        text.SetActive(true);
        speakTimeLimit = 0;
    }

    public void ChangeText4()
    {
        speak1.SetActive(false);
        speak2.SetActive(false);
        speakIndex = 14;
        text.SetActive(true);
        speakTimeLimit = 0;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("CinemaScene2");
    }
}
