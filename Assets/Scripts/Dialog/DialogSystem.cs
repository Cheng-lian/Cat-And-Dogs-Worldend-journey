using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    public TextMeshProUGUI textLabel;
    //public Text textLabel;//��Text�����ק����
    public Image faceImage;//�����ʵ���ı����п���������λ����ʾ�趨�Ľ�ɫ����Image�����ק����

    [Header("�ı��ļ�")]
    public TextAsset textFile; //��Unity�У�����д���ı���ק������
    public int index;//��ʾ�ı������ڼ���
    public float textSpeed;

    [Header("ͷ��")]
    public Sprite Player,Guider;

    public bool cancleTyping;//ȡ����������
    public bool textFinished;//�ı�������

    //�洢�ı�
    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFilr(textFile);
    }
    private void OnEnable()
    {
        /*textLabel.text = textList[index].ToString();
        index++;*/
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        //�����ֵR���в���
        if (Input.GetKeyDown(KeyCode.R)&& index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        /*if (Input.GetKeyDown(KeyCode.R) && textFinished)
        {
            *//*textLabel.text = textList[index].ToString();
            index++;*//*
            StartCoroutine(SetTextUI());
        }*/
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished&& !cancleTyping)
            {
                StartCoroutine(SetTextUI());
            }
            //�����˼����˫������R�Ϳ��Կ���ʵ���ı�����ʾ
            else if (!textFinished && !cancleTyping)
            {
                cancleTyping = true;
            }
        }
    }

    void GetTextFormFilr(TextAsset file)
    {
        textList.Clear();
        index = 0;

        //�и��ı�Text.text���������и�
        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";//��ս�����ʾ���ı����Ա������ı�����ʾ
        
        switch (textList[index].Trim().ToString())
        {
            case "A":
                Console.WriteLine(textList[index]);
                faceImage.sprite = Player;
                index++;
                break;
            case "B":
                faceImage.sprite = Guider;
                index++;
                break;
        }

        /*for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            
            yield return new WaitForSeconds(textSpeed);
        }*/
        int letter = 0;
        while (!cancleTyping && letter < textList[index].Length-1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancleTyping = false;
        textFinished = true;
        index++;
    } 
}
