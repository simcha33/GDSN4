using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2 : MonoBehaviour {

	public float speed; 
	public Vector2 moveVelocity; 

	private Rigidbody2D rb; 
	void Awake () {
		rb = GetComponent<Rigidbody2D>(); 
	}
	
	void Update () {
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 
		moveVelocity = moveInput.normalized * speed; 
	}

	void FixedUpdate() {
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime); 
	}

} 