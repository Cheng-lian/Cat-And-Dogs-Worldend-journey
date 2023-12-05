using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class SubmarineController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackCooldown = 1f;
    public GameObject missilePrefab;
    public Transform launchPoint;  // �����

    private float attackTimer = 0f;
    private Rigidbody2D rb;

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���ٴ������룬���ⲿ�������������ö�Ӧ�ķ���
        attackTimer -= Time.deltaTime;
    }

    public void OnMove(Vector2 direction)
    {
        MoveSubmarine(direction);
    }

    public void OnAttack()
    {
        if (attackTimer <= 0f)
        {
            Attack();
            attackTimer = attackCooldown;
        }
    }

    public void setBoolCanMove()
    {
        canMove = true;
    }
    public void setBoolCanNotMove()
    {
        canMove = false;
    }

    void Attack()
    {
        if (missilePrefab != null && launchPoint != null)
        {
            // ��ȡǱˮͧ�ĵ�ǰ����
            float submarineDirection = transform.localScale.x;

            // ʵ�������������ó�ʼ����
            GameObject missileObj = Instantiate(missilePrefab, launchPoint.position, Quaternion.identity);
            Missile missile = missileObj.GetComponent<Missile>();
            missile.SetInitialDirection(submarineDirection);
        }
        else
        {
            Debug.LogWarning("MissilePrefab or LaunchPoint not set!");
        }
    }

    void MoveSubmarine(Vector2 direction)
    {
        if (canMove)
        {
            rb.velocity = direction * moveSpeed;
            // �����ɫ�������ƶ������ֳ��ң�����������ƶ�������ˮƽ��ת
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
