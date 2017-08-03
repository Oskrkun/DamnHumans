using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    private float timer;
	public float timeToSpawn;
    public GameObject objectToSpawn;

	public bool spawnAndDestroy;
	public bool spawnInATime;

	// Use this for initialization
	void Start () {
		timer = timeToSpawn;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
			if(spawnAndDestroy)
			{
				SpawnAndDestroyObject();
			}
			else if(spawnInATime)
			{

				SpawnInATimeObject ();
			}
           
        }
	}
    void SpawnAndDestroyObject()
    {
        Instantiate(objectToSpawn,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
	void SpawnInATimeObject()
	{
		Instantiate(objectToSpawn,transform.position,Quaternion.identity);
		timer = timeToSpawn;
	}
}
