using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    private Transform target;
    public float range;
    private float speedRotate = 30;
    public float fireRate = 1;
    private float fireCountDown = 0;
    public GameObject arrowPrefab;
    public Transform firePoint;

 
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget",0,0.5f);
	}
	void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy!=null && shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;

        }
    }
	// Update is called once per frame
	void Update () {
        if (target==null)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (fireCountDown<=0)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime;
	}

    void Shoot()
    {
        GameObject arrowGO  = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        if (arrow!=null)
        {
            arrow.setTarget(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
