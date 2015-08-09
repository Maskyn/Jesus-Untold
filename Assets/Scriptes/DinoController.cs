using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DinoController : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.

	private float currentSpeed;
	private float timeForSpeed = 0f;
	private float maxSpeed = 20f;
	public float coefficentIncreaseSpeed = 1f;

	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

	public Text pointsText;

	private int highScore;

	public AudioClip hitClip;

	public AnimationClip[] clips;

	public GameObject ariaSotto;

	public Vector2[] boxColliderOffsets;
	
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();

		int id = PlayerPrefs.GetInt("Character");

		GetComponent<BoxCollider2D>().offset = boxColliderOffsets[id];

		anim.Play(clips[id].name);

		ariaSotto.SetActive(id == 1); // budda
	}

	void Start() {
		highScore = PlayerPrefs.GetInt("High Score");
	}
	
	
	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((
			(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		    || Input.GetButtonDown("Jump")
			|| Input.GetKeyDown(KeyCode.JoystickButton0)
			|| Input.GetKeyDown(KeyCode.JoystickButton1)
			|| Input.GetKeyDown(KeyCode.JoystickButton2)
			|| Input.GetKeyDown(KeyCode.JoystickButton3)
			|| Input.GetMouseButtonDown(0)
		    ) 
			&& grounded)
			jump = true;
		
		pointsText.text = "HI " + highScore + " PTS " + ((int) (transform.position.x)).ToString();

		timeForSpeed += Time.deltaTime;

		currentSpeed = Mathf.Min(5f + (timeForSpeed * coefficentIncreaseSpeed), maxSpeed);

		/*if (!wasJumping && jump) {
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");
			print("Jump");
			wasJumping = true;
		} else if (wasJumping && grounded) {
			wasJumping = false;
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("StopJump");
			print("StopJump");
		}*/
		
	}
	
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = 1;//Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < currentSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > currentSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * currentSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		/*// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip(); */
		
		// If the player should jump...
		if(jump)
		{
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;

			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Hit() {
		AudioSource.PlayClipAtPoint(hitClip, transform.position);

		Camera.main.GetComponent<GameController>().EndGame();
	}

	public void Bonus() {
		timeForSpeed = Mathf.Max(0f, timeForSpeed -6f);
	}
}
