using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneManager:Singleton<LoadSceneManager>
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
        Debug.Log("��è��");
        GameManager.Instance.FindCatAndDog();
        //if (GameManager.Instance.Cat != null) {
        //    Debug.Log("yes");                     //������֤������ת����֮�� èè������ǿյ� ˵����û��ת������
        //}
        //else { Debug.Log("no"); }

        //����֤��      ��Ȼ��è������д��loadScene���� ��ʵ������ȻLoadSceneִ������ è��û���ҵ� ˵��������ʱȴ��û��ת�� ԭ��δ֪

       // StartCoroutine(Initialization());

    }//����������Я�̻��������� ��ֱ����GameManager��Updata���FindCatAndDog�Ϳ��� 
    //IEnumerator Initialization() //0.1�����ִ��
    //{
    //    yield return new WaitForSeconds(0.1f);
    //   GameManager.Instance.FindCatAndDog();
    //}
}