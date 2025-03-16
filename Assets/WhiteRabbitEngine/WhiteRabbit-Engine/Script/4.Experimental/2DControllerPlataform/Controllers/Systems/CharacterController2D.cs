using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[HideInInspector] private Transform m_CeilingCheck;							// A position marking where to check for ceilings. This varible is hide, because, at this moment, the player cant be on a position that can be stop the crouch.
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	public Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	
	//private LayerMask LayerMaskCollision;
	/*
	[Header("Events")]
	[Space]
	*/

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	private void Awake()
	{
		//get the rigidbody of this object
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		//init the events.
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();

		//LayerMaskCollision = LayerMask.NameToLayer("Plataform");
	}

	/// <summary>
	/// This function is called every fixed frame. This means it is called in a fixed time step.
	/// In this method we check if the character is on ground.
	/// </summary>
	private void FixedUpdate()
	{
		//check if the character was on the ground in the last frame.
		bool wasGrounded = m_Grounded;
		//set the state to not grounded, until we check if it is.
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		// 1. We use Physics2D.OverlapCircleAll to detect all colliders within a circular area.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		//iterate all the colliders detected.
		for (int i = 0; i < colliders.Length; i++)
		{
			//2. We make sure we are not colliding with our self.
			if (colliders[i].gameObject != gameObject)
			{
				//if (colliders[i].gameObject.layer != LayerMaskCollision)
				//{
					// 3. Check if the object is on ground.
					m_Grounded = true;
					//4. Check if the state has change from not grounded to grounded.
					if (!wasGrounded)
						//5. Call the OnLandEvent if it is the case.
						OnLandEvent.Invoke();
				//}
			}
			
		}
		//Debug.Log(m_Grounded);
		//Debug.Log(wasGrounded);
	}

	/// <summary>
	/// This method is called to move the character.
	/// </summary>
	/// <param name="move"> The movement of the character in the x axis</param>
	/// <param name="crouch"> true if the character is crouching, false if not</param>
	/// <param name="jump"> true if the character is jumping, false if not</param>
	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			//we check if the character is in an area where can not stand up.
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				//1. check if the state has change.
				if (!m_wasCrouching)
				{
					//2. if it has change we update the state and call the event.
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
				//1. check if the state has change.
				if (m_wasCrouching)
				{
					//2. if it has change we update the state and call the event.
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			//1. We create a target velocity using the move value. We maintain the y of the current velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.linearVelocity.y);
			// And then smoothing it out and applying it to the character
			//2. We use smoothdamp to control the velocity, applying the targetVelocity.
			//This method make a smooth transition between the current velocity and the targetVelocity.
			//m_Velocity is a reference that SmoothDamp uses to smooth the movement.
			m_Rigidbody2D.linearVelocity = Vector3.SmoothDamp(m_Rigidbody2D.linearVelocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}
	/// <summary>
	/// This method is used to draw a gizmos in the editor.
	/// </summary>
	private void OnDrawGizmos()
	{
		//draw a sphere to represent the area where the player is on ground.
		Gizmos.DrawWireSphere(m_GroundCheck.position, k_GroundedRadius);
		
		}
	/// <summary>
	/// This method flip the player to the other direction.
	/// </summary>
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		
	}
	/// <summary>
	/// This method return the scale of the player.
	/// </summary>
	/// <returns> the scale of the object</returns>
	public Vector3 getFlip()
	{
		return transform.localScale;
	}
}
