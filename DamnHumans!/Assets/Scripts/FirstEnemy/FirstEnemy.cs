using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour {
    private Goblin target;
    private Queue<Goblin> goblins = new Queue<Goblin>();
    private bool canAttack=true;
    private float attackTimer = 0;
    public float attackCoolDown;
    public GameObject arrowPrefab;
    public Transform firePoint;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Attack();
	}
    private void Attack()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer>=attackCoolDown)
            {
                canAttack = true;
                attackTimer = 0;
            }
        }

        if (target==null && goblins.Count>0)
        {
            target = goblins.Dequeue();
        }
        if (target!=null && target.isActiveAndEnabled)
        {
            if (canAttack)
            {
                Shoot();
                canAttack = false;
            }
        }
    }
    private void Shoot()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject arrowGO = Instantiate(arrowPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        if (arrow != null)
        {
            arrow.setTarget(target.transform);
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            goblins.Enqueue(collision.GetComponent<Goblin>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = null;
        }
    }
}
