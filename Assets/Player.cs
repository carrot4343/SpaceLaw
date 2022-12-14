using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	private Animator anim;
	private CharacterController controller;

	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	public float jumppower = 7.0f;
	public float speed = 6.0f;

	private AudioSource audio;//Stage manager로 이동
	public AudioClip earnSound;//Stage manager로 이동

	RaycastHit hit;
	private float maxRaycastDistance;

	float moveX, moveZ, mouseSensitivity;
	float mouseX = 0.0f;

	private Inventory inventory;
	private Boss boss;

	void Start () 
	{
		boss = FindObjectOfType<Boss>();
		inventory = FindObjectOfType<Inventory>();
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		this.audio = this.gameObject.AddComponent<AudioSource>();
		this.audio.clip = this.earnSound;
		this.audio.loop = false;
		maxRaycastDistance = 0.15f;
		mouseSensitivity = 3.0f;
	}
	void Update ()
	{
		if (speed > 0)
			anim.SetFloat("Speed", controller.velocity.magnitude);

		if(SceneManager.GetActiveScene().name == "Main2" || SceneManager.GetActiveScene().name == "Boss1")
        {
			if(gameObject.transform.position.y < 4)
            {
				Stg_manager.instance.decreaseLife();
			}
        }

		playerMovement();
		useItem();
		playerAtk();
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Goal" || other.tag == "SecondGoal")
        {
			this.audio.Play();
			Destroy(other.gameObject);
		}

		if (other.tag == "LastGoal")
        {
			Stg_manager.instance.loadNextScene();
        }

		if (other.tag == "Item1")
		{
			inventory.getNewItem(1);
			this.audio.Play();
			Destroy(other.gameObject);
		}
		else if(other.tag =="Item2")
        {
			inventory.getNewItem(2);
			this.audio.Play();
			Destroy(other.gameObject);
		}
		else if (other.tag == "Item3")
		{
			inventory.getNewItem(3);
			this.audio.Play();
			Destroy(other.gameObject);
		}

		if (other.tag == "Enemy")
        {
			Stg_manager.instance.decreaseLife();
		}
	}

    public bool isOnGround()
    {
		if(controller.isGrounded)
        {
			return true;
        }

		return Physics.Raycast(transform.position, Vector3.down, out hit, maxRaycastDistance);
	}

	public void playerMovement()
    {
		mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.eulerAngles = new Vector3(0, mouseX, 0);

		if (isOnGround())
		{
			moveX = Input.GetAxis("Horizontal");
			moveZ = Input.GetAxis("Vertical");
			moveDirection = new Vector3(moveX, 0, moveZ);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumppower;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void useItem()
    {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
			inventory.useItem(1);
        }
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			inventory.useItem(2);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			inventory.useItem(3);
		}
	}

	private void playerAtk()
    {
		
    }
}
