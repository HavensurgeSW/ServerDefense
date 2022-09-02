using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int hp = 3;

    public int DAMAGE { get => damage; }

    [SerializeField]Healthbar enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP.SetMaxHP(hp);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
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
