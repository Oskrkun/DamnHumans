using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {
    public string type;
    public float velocity;
    public GameObject pathObject;
    Transform wayPoints;
    int wayPointIndex=0;
    public int hp = 7;
    public bool attacking;
    public bool moveToEnemy=true;
    public Transform nearEnemy;
    public int damage;
    private float attackTimer = 0;
    public float attackCoolDown;
    private bool canAttack = true;
	public float infamiaAdware;
	private bool nextWaypointAfterAttack;
    // Use this for initialization
    void Start () {

	
	
	}
	
	// Update is called once per frame
	void Update () {
        if (wayPoints==null)
        {
            GetNextWayPoint();
            if (wayPoints == null)
            {
                Destroy(gameObject);
                return;
            }
        }
        Vector3 direction = wayPoints.position - this.transform.localPosition;
        float distanceInFrames = velocity * Time.deltaTime;

        if (direction.magnitude<=distanceInFrames)
        {
            wayPoints = null;
        }
        else if(!attacking || !nearEnemy)
        {
			
            transform.Translate(direction.normalized*distanceInFrames,Space.World);
			


        }
        if (attacking)
        {
            attackEnemy();

        }
	}

    void GetNextWayPoint()
    {
    
        if (wayPointIndex <= pathObject.transform.childCount-1)
        {
            wayPoints = pathObject.transform.GetChild(wayPointIndex);
            wayPointIndex++;
        }
        else
        {
            wayPoints = null;
			LevelState.levelInfamia+=infamiaAdware;
        }
    }
    public void attackEnemy()
    {
		if(!nextWaypointAfterAttack)
		{
			GetNextWayPoint ();
			nextWaypointAfterAttack = true;
		}
         if (nearEnemy)
         { 
      
  
            Vector3 enemyDirection = nearEnemy.position - transform.position;
            float distanceInFrames = velocity * Time.deltaTime;

            if (moveToEnemy)
            {
                
                transform.Translate(enemyDirection.normalized * distanceInFrames, Space.World);
            }
            else
            {

                if (!canAttack)
                {
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= attackCoolDown)
                    {
                        canAttack = true;
                        attackTimer = 0;
                    }
                }
                if (canAttack)
                {
                    nearEnemy.GetComponent<Enemy>().hit(damage);
                    canAttack = false;
                 
                }

            }

         }
         else
         {
            nearEnemy = null;
            moveToEnemy = true;

         }
    }

    public void Attack()
    {
        attacking = true;
    }
    public void StopAttack()
    {
        attacking = false;
        moveToEnemy = true;
		nextWaypointAfterAttack = false;
	}

    public void hit(int aDamage)
    {
        hp -= aDamage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GetComponentInParent<Collider2D>().GetType() == typeof(BoxCollider2D))
        {
            if (collision.tag == "Enemy")
            {
                nearEnemy = collision.transform;
            }
            if (collision.name == "StopGoblinMove")
            {
                moveToEnemy = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GetComponentInParent<Collider2D>().GetType() == typeof(BoxCollider2D))
        {
            if (collision.tag == "Enemy")
            {
                nearEnemy = null;
            }
        }
     
    }

}
