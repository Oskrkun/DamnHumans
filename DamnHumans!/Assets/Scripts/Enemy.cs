using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int hp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void hit(int aDamage)
    {
        hp -= aDamage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
