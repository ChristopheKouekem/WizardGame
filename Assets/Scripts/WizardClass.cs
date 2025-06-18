using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Class")]
public class WizardClass : ScriptableObject
{
    public float maxMana = 100;
    public float currentMana;
    public float manaCostPerShot = 10;
    public float manaRegenPerSecond = 5;
    public float manaRegen;
    public float maxHealth = 100;
    public float currentHealth;
    public float movementSpeed = 8f;
}
