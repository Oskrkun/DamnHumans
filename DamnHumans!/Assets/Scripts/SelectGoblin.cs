using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGoblin : MonoBehaviour {
	public GameObject goblin;
    public int cant;
    public int goblinCost;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Select()
	{
		
		LevelState.goblinSelected = goblin;
        LevelState.cantGoblin = cant;
        LevelState.infamiaCost = goblinCost;
	}
}
