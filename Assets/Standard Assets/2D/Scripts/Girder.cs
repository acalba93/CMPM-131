using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girder : MonoBehaviour {
	[SerializeField] private float MaxRight = 0f;
	[SerializeField] private float MaxLeft = 0f;
	[SerializeField] private float MaxUp = 0f;
	[SerializeField] private float MaxDown = 0f;
	[SerializeField] private float SpeedX = 0.3f;
	[SerializeField] private float SpeedY = 0.3f;
	private float hor = 1;
	private float vert = 1;
	private Vector3 initialPos;
	private float R;
	private float L;
	private float U;
	private float D;
	//private Rigidbody2D transform;


	private void Awake()
	{
		//transform = GetComponent<Rigidbody2D>();
		initialPos = transform.position;
		L = initialPos.x-MaxLeft;
		R = initialPos.x+MaxRight;
		D = initialPos.y-MaxDown;
		U = initialPos.y+MaxUp;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < L) {
			hor = 1;
		} else if (transform.position.x > R) {
			hor = -1;
		} else if (transform.position.x == L && transform.position.x == R) {
			hor = 0;
		}
		if (transform.position.y < D) {
			vert = 1;
		} else if (transform.position.y > U) {
			vert = -1;
		} else if (transform.position.y == U && transform.position.y == D) {
			vert = 0;
		}
		//transform.Translate (new Vector3 (hor * SpeedX, vert * SpeedY,0),Space.Self);
		transform.position+=new Vector3 (hor * SpeedX, vert * SpeedY,0);
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag.CompareTo ("Player") == 0) {
			other.gameObject.transform.SetParent(transform);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag.CompareTo ("Player") == 0) {
			other.gameObject.transform.SetParent(null);
		}
	}
}
