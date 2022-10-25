using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    int chestValue;
    public Sprite emptyChest;
    public Sprite treasureChest;
    int pesosAmount;
    protected override void Start()
    {
        base.Start();
        chestValue = Random.Range(1, 4);
        pesosAmount = Random.Range(3, 31);
    }
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            if (chestValue == 1 || chestValue == 2)
            {
                GetComponent<SpriteRenderer>().sprite = treasureChest;
                GameManager.instance.ShowText("+" + pesosAmount + " altın!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
                //Debug.Log("Grant " + pesosAmount + " pesos!");
            }
            else if (chestValue == 3)
            {
                GameManager.instance.ShowText("Altın yok! Sandık boş!", 20, Color.red, transform.position, Vector3.up * 50, 2.5f);
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                //Debug.Log("Grant 0 pesos! Chest Empty!");
            }
            else
                Debug.LogError("chestValue out of limits!!");
        }
    }
}
