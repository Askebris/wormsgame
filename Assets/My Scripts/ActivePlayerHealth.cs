using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] private TextMeshProUGUI Kills;

    public float currentHealth;
    public Slider slider;
    public int kills = 0;
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        Kills.text = Mathf.RoundToInt(kills).ToString();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            SetMaxHealth(currentHealth);
            transform.position = initialPosition;
            transform.eulerAngles = initialRotation;
            kills++;
        }

    }

 
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float Health)
    {
        slider.value = Health;
    }
}
