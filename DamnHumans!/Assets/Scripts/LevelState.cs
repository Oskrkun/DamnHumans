using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour {
	public static GameObject goblinSelected;
    public static int cantGoblin;
    public static int infamiaCost;
	public static float levelInfamia;
    public float Infamia;
    public static bool chiefAttacking;

    private void Start()
    {
        levelInfamia = Infamia;
    }
    private void Update()
    {
        Infamia = levelInfamia;
    }
   public void ChiefStartAttack()
    {
		GameObject chief = GameObject.Find("ChiefRange");
		if(chief!=null)
		{
        chiefAttacking = true;
		}
    }
  
}
