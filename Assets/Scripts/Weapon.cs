using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private Animator weaponAnim;
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponAnim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D collision)
    {
        if (collision.tag == "Fighter")
        {
            if (collision.name == "Player") { return; }
            // Create new damage object, then send it to the fighter whose got hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            collision.SendMessage("ReceiveDamage", dmg);
        }
    }
    private void Swing()
    {
        weaponAnim.SetTrigger("Swing");
    }
}
