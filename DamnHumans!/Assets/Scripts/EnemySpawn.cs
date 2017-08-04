using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    private float timer;
	public float timeToSpawn;
    public GameObject objectToSpawn;
	public Transform positionSpawn;
	public int cantObjects;

	public bool spawnAndDestroy;
	public bool spawnInATime;
	public Transform destinyPoint;
	public float destinyRange;


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
		if (objectToSpawn.name == "HumanWarrior") 
		{
			for (int i = 0; i < cantObjects; i++) 
			{
				GameObject humanWarrior =	Instantiate (objectToSpawn, positionSpawn.position, Quaternion.identity);
				humanWarrior.GetComponent<HumanWarrior> ().setDestinyPoint (destinyPoint);
				humanWarrior.GetComponent<HumanWarrior> ().setDestinyRange (destinyRange);
			}
		} 
		else 
		{
		
			for (int i = 0; i < cantObjects; i++) 
			{
				Instantiate (objectToSpawn, positionSpawn.position, Quaternion.identity);

			}
		}
		Destroy(gameObject);
    
	}
	void SpawnInATimeObject()
	{
		if(objectToSpawn.name=="HumanWarrior")
		{
			for (int i = 0; i < cantObjects; i++) 
			{
				GameObject humanWarrior =	Instantiate (objectToSpawn, positionSpawn.position, Quaternion.identity);
				humanWarrior.GetComponent<HumanWarrior> ().setDestinyPoint (destinyPoint);
				humanWarrior.GetComponent<HumanWarrior> ().setDestinyRange (destinyRange);
			}
		}
		timer = timeToSpawn;
	}

}
