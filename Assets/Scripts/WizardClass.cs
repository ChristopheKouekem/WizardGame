using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Class")]
public class WizardClass : ScriptableObject
{
    public int maxMana = 100;
    public int currentMana;
    public int manaCostPerShot = 10;
    public int manaRegenPerSecond = 5;
    public float manaRegen;
    public int maxHealth = 100;
    public int currentHealth;
    public float movementSpeed = 8f;
}
