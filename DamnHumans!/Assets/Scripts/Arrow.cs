using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Transform target;
    public float velocity = 20;
    public int damage;

    //public float speedRotate = 10;
    public void setTarget(Transform aTarget)
    {
        target = aTarget;
    }
    private void Start()
    {
      
 
    }
    // Update is called once per frame
    void Update () {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceInFrames = velocity * Time.deltaTime;

        if (direction.magnitude<=distanceInFrames)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized*distanceInFrames,Space.World);
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    

    }
    void HitTarget()
    {
        if (target.GetComponent<Goblin>().type!="Shielder")
        {
            target.GetComponent<Goblin>().hit(damage);
        }
        Destroy(gameObject);
    }
}
