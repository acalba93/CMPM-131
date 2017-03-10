using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	[SerializeField] private float MaxRight = 0f;
	[SerializeField] private float MaxLeft = 0f;
	[SerializeField] private float Speed = 30f;
	private float direction = 1;
	private Vector3 initialPos;
	private float R;
	private float L;
	private Rigidbody2D carbody;


	private void Awake()
	{
		carbody = GetComponent<Rigidbody2D>();
		initialPos = carbody.position;
		L = initialPos.x-MaxLeft;
		R = initialPos.x+MaxRight;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (carbody.position.x <= L) {
			direction = 1;
		} else if (carbody.position.x >= R) {
			direction = -1;
		}	
		carbody.velocity = new Vector2 (direction*Speed, carbody.velocity.y);
	}
}
