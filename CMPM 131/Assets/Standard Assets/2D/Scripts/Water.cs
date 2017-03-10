using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	[SerializeField] private float Speed=0.02f; 
	private Vector3 scale;
	private Vector3 pos;
	[SerializeField] private int Timer=200;
	[SerializeField] private float MaxScale=1.5f;
	private bool waterOn=false;

	private void Awake()
	{
		scale = transform.localScale;
		pos = transform.position;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer > 0) {
			Timer--;
			if (waterOn) {
				if (transform.localScale.y<=MaxScale){
					transform.localScale += new Vector3 (Speed/10,Speed,0);
					transform.position += new Vector3 (0,(Speed),0);
				//waterbody.transform.rotation=new Vector3 (0,0,0);
				}
			}
			if (!waterOn) {
				if (transform.localScale.y > scale.y) {
					transform.localScale += new Vector3 (-Speed/10, -Speed, 0);
					transform.position += new Vector3 (0, -(Speed), 0);
					//waterbody.transform.rotation=new Vector3 (0,0,0);
				} else {
					transform.localScale = scale;
					transform.position=pos;
				}
			}
		} else {
			waterOn=!waterOn;
			Timer = 240;
		}
	}
}
