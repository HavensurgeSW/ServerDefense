using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy> OnEnemyHit;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    public float CURRENTHEALTH { get; set; }

    private Image healthBar;
    private Enemy enemy;

    private void Start()
    {
        CreateHealthBar();
        CURRENTHEALTH = initialHealth;
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            DealDamage(5);
        }
        //healthBar.fillAmount = MathF.Lerp(healthBar.fillAmount, CURRENTHEALTH / maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar() {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        healthBar = container.FillAmountImage;
    }

    public void DealDamage(int damageReceived) {
        CURRENTHEALTH -= damageReceived;
        if (CURRENTHEALTH <= 0)
        {
            CURRENTHEALTH = 0;
            //Die();
        }
        else {
            OnEnemyHit?.Invoke(enemy);
        }
    }

}
