using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	[Header("Steering")]
	[SerializeField] private float turnRate = 150;
	[SerializeField] private float maxTurn = 45;

	[Header("Wheels")]
	[SerializeField] private Transform leftWheel;
	[SerializeField] private Transform rightWheel;

	private float steer = 0;

	private void Update() {
		float horizontal = -Input.GetAxisRaw("Horizontal");

		if (Input.GetKey(KeyCode.LeftShift) && horizontal != 0) {
			steer = horizontal * maxTurn;

			return;
		}

		steer += horizontal * Time.deltaTime * turnRate;

		if (steer > maxTurn) steer = maxTurn;
		if (steer < -maxTurn) steer = -maxTurn;
	}

	private void FixedUpdate() {
		leftWheel.eulerAngles = rightWheel.eulerAngles = new Vector3(0, 0, steer);
	}
}
