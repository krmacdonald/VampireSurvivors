using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;
	private bool sprint = false;

	public float verticalSpeed;
	private playerLifeManager healthGetter;
	private void Start()
    {
		CC.enabled = true;
		healthGetter = this.GetComponent<playerLifeManager>();
    }
	private void Update()
	{
		//handles x/z axes movement
		if(sprint == false && Input.GetButtonDown("Sprint")){
			MoveSpeed = MoveSpeed * 2;
			sprint = true;
		}else if(sprint == true && Input.GetButtonUp("Sprint")){
			MoveSpeed = MoveSpeed / 2;
			sprint = false;
		}
		Vector3 movement = Vector3.zero;
		float forwardMovement = Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;
		float sideMovement = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		//handles y movement, modify pub var jumpspeed and gravity to change
		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				verticalSpeed = JumpSpeed;
			}
		}
		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);

		//moves the character controller
		if (healthGetter.isAlive)
		{
			CC.Move(movement);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
			Debug.Log("quitting");
		}
        if (Input.GetKeyDown(KeyCode.P))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	private void OnTriggerEnter(Collider other){
		//reserved for pickups
	}
}
