using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ��������˺�ֵ
    public int damage = 10;

    // ��������ƶ��ٶ�
    public Vector2 moveSpeed = new Vector2(3f, 0);

    // ������Ļ�������
    public Vector2 knockback = new Vector2(0, 0);

    // �������
    Rigidbody2D rb;

    // �ڽű�����ʱִ�еķ���
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // �ڽű�����ʱִ�еķ���
    void Start()
    {
        // ���ø�����ٶȣ�ʹ����������ָ�������ƶ�
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    // ��������������Collider2D��ײʱ���õķ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��ȡ����������ײ�Ķ����Damageable���
        Damageable damageable = collision.GetComponent<Damageable>();

        // �����ײ�Ķ������Damageable���
        if (damageable != null)
        {
            // ���������﷽������ʵ�ʵĻ�������
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            // ����Damageable�����Hit�����������������˺��ͻ�������
            bool getHit = damageable.Hit(damage, deliveredKnockback, Enums.DamageType.Ranged);

            // ����ɹ�����
            if (getHit)
            {
                // �ڿ���̨���������Ϣ
                Debug.Log(collision.name + " hit for " + damage);

                // �������������
                Destroy(gameObject);
            }
        }
    }
}
