using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	
	public float maxSpeed;
	public int health;
	
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

	void Start () {
		facingRight = -1;
		facingUp = -1;
		isVertical = false;
		Debug.Log (transform.position);
		currentIndex = 0;
	}
	
	void Update()
	{

	}
	
	void FixedUpdate()
	{
		WaypointMove ();
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

	void WaypointMove() {

		Transform currentGoal = pathing[currentIndex];
		Vector3 relative = currentGoal.position - transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		float distanceToWaypoint = relative.magnitude;
		//float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;

		if (distanceToWaypoint < 0.1)
		{
			if (currentIndex + 1 < pathing.Length)
			{
				currentIndex++;
			}
			else
			{
				currentIndex = 0;
			}
			rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
		}
		else
		{
			rigidbody2D.AddForce(new Vector2(movementNormal.x, movementNormal.y) * maxSpeed);
		}

		//transform.rotation = Quaternion.Euler(0, 0, targetAngle);
	}

	public void decrementHealth(int amount) {
		health -= amount;
		if(health <= 0) {
			Destroy(this.gameObject);
		}
	}
}
