using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "Score: " + score;
        text2.text = "Mana: " + GameObject.FindWithTag("Player").GetComponent<Player>().currentMana + "/100";
        text3.text = "Health: " + GameObject.FindWithTag("Player").GetComponent<Player>().currentHealth + "/100";
        Mana.rectTransform.localScale = new Vector3(GameObject.FindWithTag("Player").GetComponent<Player>().currentMana / 100f, 1, 1);
        Health.rectTransform.localScale = new Vector3(GameObject.FindWithTag("Player").GetComponent<Player>().currentHealth / 100f, 1, 1);

    }
}
