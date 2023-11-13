using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // ������Transform
    public Transform launchPoint;

    // �������Ԥ����
    public GameObject projectilePrefab;

    private Damageable launcherDamageable;

    // ����������ķ���
    public void FireProjectile()
    {
        if (launcherDamageable != null && launcherDamageable.Fir())
        {
            // ʵ��������������ڷ����λ�ã���ʹ��������Ԥ�������ת
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);

            // ��ȡ������ԭʼ������
            Vector3 origScale = projectile.transform.localScale;

            // ���ݷ����ķ�����������������ţ�ȷ�������ﳯ����ȷ�ķ���
            projectile.transform.localScale = new Vector3(
                origScale.x * transform.localScale.x > 0 ? 1 : -1,// �������㷽���ң��򱣳�ԭʼ���ţ�����ת������
                origScale.y,
                origScale.z
                );
        }
        else
        {
            Debug.Log("Not enough MP to fire!");
        }
    }
}
