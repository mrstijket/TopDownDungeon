using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    // Logic 
    protected bool collected;
    protected override void OnCollide(Collider2D collision)
    {
        if (collision.name == "Player")
            OnCollect();
    }
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
