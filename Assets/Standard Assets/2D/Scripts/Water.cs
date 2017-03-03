using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	[SerializeField] private float Speed=0.1f; 
	private Rigidbody2D waterbody;
	private Vector3 scale;
	private Vector3 pos;
	private int timer=240;
	private bool waterOn=false;

	private void Awake()
	{
		waterbody = GetComponent<Rigidbody2D>();
		scale = waterbody.transform.localScale;
		pos = waterbody.transform.position;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer--;
			if (waterOn) {
				if (waterbody.transform.localScale.y<=20){
					waterbody.transform.localScale += new Vector3 (0,Speed,0);
					//waterbody.transform.position += new Vector3 (0,(Speed+0.2f),0);
				//waterbody.transform.rotation=new Vector3 (0,0,0);
				}
			}
			if (!waterOn) {
				if (waterbody.transform.localScale.y > scale.y) {
					waterbody.transform.localScale += new Vector3 (0, -Speed, 0);
					//waterbody.transform.position += new Vector3 (0, -(Speed+0.2f), 0);
					//waterbody.transform.rotation=new Vector3 (0,0,0);
				} else {
					waterbody.transform.localScale = scale;
					waterbody.transform.position=pos;
				}
			}
		} else {
			waterOn=!waterOn;
			timer = 240;
		}
	}
}
