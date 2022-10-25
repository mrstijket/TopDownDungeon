using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    // Damage
    public int damage = 1;
    public float pushForce = 5f;

    protected override void OnCollide(Collider2D collision)
    {
        if (collision.tag == "Fighter" && collision.name == "Player")
        {
            // Create a new damage object, before sending it to player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            collision.SendMessage("ReceiveDamage", dmg);
        }
    }
}
