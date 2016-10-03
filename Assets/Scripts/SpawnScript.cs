using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	// Use this for initialization
	public GameObject[] obj;
	public GameObject[] bg_obj;
	
	private float X=-60f;
	private float Y=-2f;
	private float temp_Y=-2f;
	private int id =1;
	private int pre_id=1;
	private int gap = 0;
	private bool rand_again = false;
	
	public GameObject objPaint;
	public GameObject rainbowBox;

	void Start () {
		Spawn ();
		
	}
	
	// Update is called once per frame
	
	void Spawn()
	{
		do{
			temp_Y = Y;
			id = Random.Range (0, 3);
			temp_Y -= (pre_id+id-2)*1.25f;
			rand_again = (temp_Y > 33)||(temp_Y < -27)||((pre_id+id==2) && (pre_id!=id));
		}while(rand_again);
		X += 5f;
		Y = temp_Y;
		pre_id = id;
		int temp = Random.Range (0,2);
		gap = (gap ^ temp) & temp;
		temp = (id*2+gap==3)?Random.Range (3, 8):0;
		int items = id * 2 + gap + temp;
		Instantiate (obj [items], new Vector3(X,Y,0), Quaternion.identity);
		Invoke ("Spawn",5.0f/GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed);
		//create paints
		/*if (items < 7 && Random.Range (0, 2) == 1) {
			int randomBox = Random.Range(1,21);
			Vector3 vPaintPos = new Vector3 (X, Y + Random.Range (1, 3)*2, 0);
			if(randomBox!=20)
				Instantiate (objPaint, vPaintPos, transform.rotation);
			else
				Instantiate (rainbowBox, new Vector3 (X, Y +4.0f, 0), transform.rotation);
		}*/

	}

	public void spawn_bg(){
		float X = GameObject.Find ("Player").transform.position.x + 27f;
		float Y = GameObject.Find ("Player").transform.position.y +3f;
		int bg_id = Random.Range (0,4);
		Instantiate (bg_obj [bg_id], new Vector3(X,Y,0), Quaternion.identity);
	}
}
