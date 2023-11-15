using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleDamage : MonoBehaviour
{
    // �����¼�
    public UnityEvent<int, Vector2> damageableHit;  // �ܵ��˺�ʱ�������¼��������˺�ֵ�ͻ�������
    public UnityEvent<int, int> healthChanged;  // ����ֵ�ı�ʱ�������¼���������ǰ����ֵ���������ֵ

    // ���ö������
    Animator animator;

    // �������ֵ����
    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    // ��ǰ����ֵ����
    [SerializeField]
    private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    // �Ƿ�������
    [SerializeField]
    private bool _isAlive = true;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set " + value);
        }
    }

    // �ڽű�����ʱ��ȡ�������������
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // �ܵ��˺��ķ����������Ƿ�ɹ��ܵ��˺�
    public bool Hit(int damage, Vector2 knockback, Enums.DamageType damageType)
    {
        if (IsAlive)
        {
            Health -= damage;
            damageableHit?.Invoke(damage, knockback);
            // ʹ���¶���ķ��������¼�
            CharacterEvents.TriggerCharacterDamaged(gameObject, damage, damageType);

            return true;
        }
        return false;
    }

}
