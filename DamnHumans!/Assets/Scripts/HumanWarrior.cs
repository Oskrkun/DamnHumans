using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWarrior : MonoBehaviour {
	public Transform destinyPoint;
	public float destinyRange;

	private Vector3 destinyPosition;
	public float velocity;
	public bool move;

	// Use this for initialization
	void Start () {
		destinyPosition = new Vector3 (destinyPoint.position.x + randomValue (), destinyPoint.position.y + randomValue (), destinyPoint.position.z);
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3	direction= destinyPosition - this.transform.localPosition;
	
		float distanceInFrames = velocity * Time.deltaTime;
		if (direction.magnitude <= distanceInFrames) 
		{
			move = false;
		} 
		else
		{
			move = true;
		}
		if (move) 
		{
			transform.Translate (direction.normalized * distanceInFrames, Space.World);
		}

	}
	public void setDestinyPoint(Transform aDestinyPoint)
	{
		destinyPoint = aDestinyPoint;
	}
	public void setDestinyRange(float aDestinyRange)
	{
		destinyRange = aDestinyRange;
	}
	private float randomValue()
	{
		float value = Random.Range (0, destinyRange);
		if (Random.Range (0, 2) == 0) 
		{
			
			value = -value;
		
		}
		return value;
	
	}
}
