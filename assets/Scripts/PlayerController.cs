using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public bool isDoge;
	public int health;
	public int attack;

	private int facingRight;
	private int facingUp;
	private float moveX;
	private float moveY;
	private bool isVertical;
	private Animator playerAnimator;

	public GameObject weapon;
	//public GameObject PushTool;
	public GameObject PullTool;

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
		if(isDoge) {
			attack = attack * 1;
		}
		else {
			attack = attack * 2;
		}
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
			Attack1 ();
		if(Input.GetMouseButtonDown(1))
			PushPull ();
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
		playerAnimator.SetTrigger ("MainAttack");
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

	void PushPull () {
		if(isDoge) { // pull
			if(!isVertical) {
				if(facingRight == 1) {
					Instantiate (PullTool, new Vector3(transform.position.x + 2,transform.position.y,0.0f), transform.rotation);
				}
				else {
					Instantiate (PullTool, new Vector3(transform.position.x - 2,transform.position.y,0.0f), transform.rotation);
				}
			}
			else {
				if(facingUp == 1) {
					Instantiate (PullTool, new Vector3(transform.position.x,transform.position.y + 2,0.0f), transform.rotation);
				}
				else {
					Instantiate (PullTool, new Vector3(transform.position.x,transform.position.y - 2,0.0f), transform.rotation);
				}
			}
		}
		else { // push
			/*if(!isVertical) {
				if(facingRight == 1) {
					Instantiate (PushTool, new Vector3(transform.position.x + 2,transform.position.y,0.0f), transform.rotation);
				}
				else {
					Instantiate (PushTool, new Vector3(transform.position.x - 2,transform.position.y,0.0f), transform.rotation);
				}
			}
			else {
				if(facingUp == 1) {
					Instantiate (PushTool, new Vector3(transform.position.x,transform.position.y + 2,0.0f), transform.rotation);
				}
				else {
					Instantiate (PushTool, new Vector3(transform.position.x,transform.position.y - 2,0.0f), transform.rotation);
				}
			}*/
		}
	}

}
