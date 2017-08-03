using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
	public GameObject objectToSpawn,goblin;
	private int cantGoblin;
    public GameObject[] pathes;
	public int positionSpawn;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		objectToSpawn = LevelState.goblinSelected;
        cantGoblin = LevelState.cantGoblin;
    }

	void OnMouseDown()
	{
       
        if (LevelState.infamiaCost<=LevelState.levelInfamia) {
			
            LevelState.levelInfamia -= LevelState.infamiaCost;

            

            for (int i = 1; i <= cantGoblin; i++) {

                int indexPath = Random.Range(0, pathes.Length);
				if(positionSpawn==1)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x - RandomPositionX(), transform.position.y + RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = false;
				}
				if(positionSpawn==2)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x, transform.position.y + RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = false;
				}
				if(positionSpawn==3)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x+ RandomPositionX(), transform.position.y + RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = true;
				}
				if(positionSpawn==4)
				{
				goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x - RandomPositionX(), transform.position.y + RandomPositionAlternate()), Quaternion.identity);
				goblin.GetComponent<SpriteRenderer>().flipX = false;
				}
				if(positionSpawn==5)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x + RandomPositionX(), transform.position.y + RandomPositionAlternate()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = true;
				}
				if(positionSpawn==6)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x - RandomPositionX(), transform.position.y - RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = false;
				}
				if(positionSpawn==7)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x, transform.position.y - RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = false;
				}
				if(positionSpawn==8)
				{
					goblin = Instantiate(objectToSpawn, new Vector2(transform.position.x+RandomPositionX(), transform.position.y - RandomPositionY()), Quaternion.identity);
					goblin.GetComponent<SpriteRenderer>().flipX = true;
				}
                goblin.GetComponent<Goblin>().pathObject = pathes[indexPath];
            }
        }
        else
        {
            //Mostrar error de infamia insuficiente
            Debug.Log("Infamia insuficiente");
        }
    }

	private int RandomPositionX()
	{
		int position= Random.Range(150,300);
		return position;
	}
	private int RandomPositionY()
	{
		int position= Random.Range(150,300);


		return position;
	}
	private int RandomPositionAlternate()
	{
		int position= Random.Range(0,100);
		if(Random.Range(1,2)==1)
		{
			position = -position;

		}

		return position;
	}


}
