using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public int damage = 50;

    private Transform target;

    void Start()
    {
        // ������ʱ���� Boss ����
        target = GameObject.FindGameObjectWithTag("Boss2").transform;

        if (target == null)
        {
            Debug.LogError("Boss not found!");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Seek();
        }
        else
        {
            // ���û��Ŀ�꣬���ٵ���
            Destroy(gameObject);
        }
    }

    void Seek()
    {
        // ���㵼������
        Vector2 direction = (target.position - transform.position).normalized;

        // ������ת�Ƕ�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��ת����
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

        // �ƶ�����
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // ���õ����ĳ�ʼ����
    public void SetInitialDirection(float direction)
    {
        transform.localScale = new Vector3(direction, 1f, 1f);
    }

    // ����������������ײʱ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss2"))
        {
            collision.GetComponent<Tentacle>().BeHit(damage);
            Destroy(gameObject); // ��ײ�����ٵ���
        }
    }
}
