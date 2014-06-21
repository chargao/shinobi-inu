using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;

	private int facingRight;
	private int facingUp;
	private float moveX;
	private float moveY;
	private bool isVertical;
	private Animator playerAnimator;


	public GameObject weapon;

	void Awake()
	{
		DontDestroyOnLoad (this);
		playerAnimator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		facingRight = -1;
		facingUp = -1;
		isVertical = false;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
			Attack1 ();
		if(Input.GetMouseButtonDown(1))
			Attack2 ();
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
		if (facingUp == 1)
			playerAnimator.SetTrigger ("MoveUp");
		else
			playerAnimator.SetTrigger ("MoveDown");
	}

	void MoveHorizontal()
	{
		moveX = Input.GetAxis ("Horizontal");
		if((moveX < 0 && facingRight==1) || (moveX > 0 && facingRight==-1))
			FlipHorizontal();
		if(moveX != 0) {
			isVertical = false;
			rigidbody2D.velocity = new Vector2(facingRight * maxSpeed, rigidbody2D.velocity.y);
		}
	}
	void MoveVertical() {
		moveY = Input.GetAxis ("Vertical");
		if((moveY < 0 && facingUp==1) || (moveY > 0 && facingUp==-1)) {
			FlipVertical();
		}
		if(moveY != 0) {
			isVertical = true;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, facingUp * maxSpeed);
		}
	}

	void Attack1() {
		if(!isVertical) {
			if(facingRight == 1) {
				Instantiate (weapon, new Vector3(transform.position.x + 2,transform.position.y,0.0f), transform.rotation);
			}
			else {
				Instantiate (weapon, new Vector3(transform.position.x - 2,transform.position.y,0.0f), transform.rotation);
			}
		}
		else {
			if(facingUp == 1) {
				Instantiate (weapon, new Vector3(transform.position.x,transform.position.y + 2,0.0f), transform.rotation);
			}
			else {
				Instantiate (weapon, new Vector3(transform.position.x,transform.position.y - 2,0.0f), transform.rotation);
			}
		}
	}

	void Attack2 () {
		Debug.Log("attack 2.");
	}

}
