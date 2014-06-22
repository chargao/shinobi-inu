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
	private bool pulling;
	private float distanceX;
	private float distanceY;
	private Transform boulder;
	private int invulTimer;
	private bool isIdle;

	public GameObject weapon;

	void Awake()
	{
		DontDestroyOnLoad (this);
		playerAnimator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		isIdle = true;
		invulTimer = 100;
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
			pulling = true;
		if(Input.GetMouseButtonUp(1)) {
			pulling = false;
			boulder = null;
		}
		if(!isIdle && moveX == 0 && moveY == 0) {
			//playerAnimator.SetTrigger ("Idle");
			isIdle = true;
		}
		if(invulTimer > 0) {invulTimer--;}
	}

	void FixedUpdate()
	{
		MoveHorizontal();
		MoveVertical();
		if(isDoge && pulling && boulder) {
			boulder.position = new Vector3(transform.position.x + distanceX,transform.position.y + distanceY, -0.5f);
		}
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
			isIdle = false;
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
			isIdle = false;
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

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "boulder") {
			distanceX = other.transform.position.x - transform.position.x;
			distanceY = other.transform.position.y - transform.position.y;
			boulder = other.transform;
		}
		else if(invulTimer <= 0 && other.gameObject.tag == "enemy") {
			health -= 1;
			if(health <= 0) {Debug.Log ("death-a");}
			else {invulTimer = 100;}
		}
	}

}
