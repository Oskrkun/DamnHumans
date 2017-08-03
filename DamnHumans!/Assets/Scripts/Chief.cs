using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chief : MonoBehaviour {
    public List<GameObject> nearGoblins;
    public float attackTimer = 0;
    public float durationAttack;
    public float attackOrderCoolDown;
    public float attackOrderTimer;
    public bool canSendOrder=true;

    // Use this for initialization
    void Start () {
        attackOrderTimer = attackOrderCoolDown;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateNearGoblinsList();
        if (LevelState.chiefAttacking == false && attackTimer>0)
        {
            StopAttackNearEnemy();
        }
        if (LevelState.chiefAttacking && canSendOrder)
        {
            AttackNearEnemy();

        }
        else if(!canSendOrder)
        {
            
            StopAttackNearEnemy();
            attackOrderTimer -= Time.deltaTime;
            if (attackOrderTimer <= 0)
            {
                canSendOrder = true;
                attackOrderTimer = attackOrderCoolDown;
            }
        }

    
	}

	private void UpdateNearGoblinsList()
	{
		if(nearGoblins!=null)
		{
			for(int i=0;i<nearGoblins.Count;i++)
			{
				if (nearGoblins[i]==null)
				{
					nearGoblins.Remove(nearGoblins[i]);
				}
			}

		}
	}

    public void AttackNearEnemy()
    {


        GetComponentInParent<Goblin>().Attack();

        foreach (GameObject goblin in nearGoblins)

        {

            if (goblin!=null)
            {
                goblin.GetComponent<Goblin>().Attack();
            }
        }
           
           
        
        attackTimer += Time.deltaTime;
        if (attackTimer >= durationAttack)
        {
            StopAttackNearEnemy();
            canSendOrder = false;
            attackTimer = 0;
        }

    }
    public void StopAttackNearEnemy()
    {
        GetComponentInParent<Goblin>().StopAttack();
        foreach (GameObject goblin in nearGoblins)
        {
            if (goblin!=null)
            {
                goblin.GetComponent<Goblin>().StopAttack();
            }
        }
        LevelState.chiefAttacking = false;
        attackTimer = 0;
        canSendOrder = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            nearGoblins.Add(collision.gameObject);
        }
    }
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			nearGoblins.Remove(collision.gameObject);
		}
	}

}
