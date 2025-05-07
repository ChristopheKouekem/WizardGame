using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static int score;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public Image Mana;
    public Image Health;
    private WizardClass stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Player>().stats;
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "Score: " + score;
        text2.text = "Mana: " + stats.currentMana + "/" + stats.maxMana;
        text3.text = "Health: " + stats.currentHealth + "/" + stats.maxHealth;
        Mana.rectTransform.localScale = new Vector3(stats.currentMana / stats.maxMana, 1, 1);
        Health.rectTransform.localScale = new Vector3(stats.currentHealth / stats.maxHealth, 1, 1);
    }
}
