using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float range = 3f;
    [SerializeField] private int damage = 2;
    [SerializeField] private Aimbot aimbot;

    [SerializeField] private float firerate = 1f;
    float timer = 0f;
    private void Awake()
    {
        aimbot.SetRange(range);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void DealDamage(Enemy enemy) {
        enemy.ReceiveDamage(damage);
    }

    private void Update()
    {
        if (timer >= firerate)
        {
            if(aimbot.ContainsTargets())
                DealDamage(aimbot.GetTarget<Enemy>(0));
            timer = 0;
        }
        else {
            timer += Time.deltaTime;
        }
    }
}
