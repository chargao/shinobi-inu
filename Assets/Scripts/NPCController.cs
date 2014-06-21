using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	
	public float maxSpeed;
	
	private int facingRight;
	private int facingUp;
	private bool isVertical;

	public Transform[] pathing;
	private Transform currentGoal;
	private int currentIndex;
	
	void Awake()
	{
		DontDestroyOnLoad (this);
	}
	
	// Use this for initialization
	void Start () {
		facingRight = -1;
		facingUp = -1;
		isVertical = false;
		for(int i = 0; i < pathing.Length; i++) {
			Debug.Log ("Direction "+i+": "+pathing[i]);
		}
		Debug.Log (transform.position);
		currentIndex = 0;
	}
	
	void Update()
	{

	}
	
	void FixedUpdate()
	{
		MoveHorizontal();
		MoveVertical();
	}
	
	void FlipHorizontal()
	{
		facingRight = -1 * facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	void FlipVertical()
	{
		facingUp = -1 * facingUp;
	}
	
	void MoveHorizontal()
	{
		/*moveX = Input.GetAxis ("Horizontal");
		if((moveX < 0 && facingRight==1) || (moveX > 0 && facingRight==-1))
			FlipHorizontal();
		if(moveX != 0) {
			isVertical = false;
			rigidbody2D.velocity = new Vector2(facingRight * maxSpeed, rigidbody2D.velocity.y);
		}*/
	}
	void MoveVertical() {
		/*moveY = Input.GetAxis ("Vertical");
		if((moveY < 0 && facingUp==1) || (moveY > 0 && facingUp==-1)) {
			FlipVertical();
		}
		if(moveY != 0) {
			isVertical = true;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, facingUp * maxSpeed);
		}*/
	}

	void Move1Square(int direction) {
		if(direction < 2) { // vertical
			if(direction == 0) {
				Debug.Log (transform.position.y + 10);
			}
			else {
				Debug.Log (transform.position.y - 10);
			}
		}
		else { // horizontal
			if(direction == 2) {
				Debug.Log (transform.position.x + 10);
			}
			else {
				Debug.Log (transform.position.x - 10);
			}
		}
	}
}
