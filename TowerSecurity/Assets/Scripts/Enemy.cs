using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] private GameObject target;

    EnemyData ENEMYDATA;
    public int DAMAGE { get => damage; }

    [SerializeField]Healthbar enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        damage = ENEMYDATA.DAMAGE;
        speed = ENEMYDATA.SPEED;
        hp = ENEMYDATA.HP;
        
        enemyHP.SetMaxHP(hp);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }

    public void ReceiveDamage(int dmg)
    {
        hp = hp - dmg;
        enemyHP.SetHealthbarFill(hp);
        if (hp <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
