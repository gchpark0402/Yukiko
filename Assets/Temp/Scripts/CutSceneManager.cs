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
        speak[0] = "����. ������ �ڰ� �ִ� �ž�? �Ͼ ��ٷ����. ���� ���� �� �����ϱ� ���̾�.";
        speak[1] = "�׷�. ��ó�� �� ����Ʒ��ε� �� ��ܺ��ڱ�.";
        speak[2] = "�¾Ƹ¾�. ���������̶�� �ϸ� ����Ʒ����ݾ�? ��¥ ���ȴ�.";
        speak[3] = "�ٵ� ���� �ҹ��� �� ���� ������?";
        speak[4] = "�ҹ��� ���ϸ� �����ô붧 �� ���� ��� ���ڸ� ���� �� ���� ���� �繫���̰� ������ٰ�,";
        speak[5] = " �ڽ��� �޾����� ���� ȱ�迡 �ϰ����� �����ߵ�. ���� ������. ��� ����� �׷� �� ����?";
        speak[6] = "�׷��� ���̾�. �׷��� �� ���ڰ� �������� �� ���� �׾������ �ͽ��� �Ǿ��ٴ� ��⿴��?";
        speak[7] = "���� ���� ���� Ȯ���� �� �ְ���. ����Ƶ� �������� ���ӿ��� Ʋ������.";
        speak[8] = "������ Ÿ�� �ָ� �Դµ� �ð� ���� �ƴϾ����� ���ڴ�.";
        speak[9] = "�����߾�. �ٵ� ������ ����";
        speak[10] = "��...�����ߴ� �� ���� �� ��� ���� ���̳�. �� ���� �� ����.";
        speak[11] = "��... �׷��� �Ʊ���� �ڰ� �ִ� �������� ���� ����? ��Ģ���� �� ������ �ؾ���.";
        speak[12] = "�װ� ����! �ʰ� ���� ����.";
        speak[13] = "���� �������� �����ϳ�. �� �� � ������.";
        speak[14] = "���?! �����ϳ�.  ���� �� �����!";

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
