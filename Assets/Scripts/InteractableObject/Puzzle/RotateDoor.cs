using UnityEngine;

public class RotateDoor : ObjectAction
{

	[Header("Object References")]
	[SerializeField] private GameObject rotatingPoint;

	[Header("Object Specs")]
	[SerializeField] private float rotationSpeed = 100f;

	private Quaternion targetRotation;

	public override void Initialize () {

		base.Initialize();
		targetRotation = rotatingPoint.transform.rotation;
	}

	private void Update () {

		Quaternion newRotation = Quaternion.RotateTowards(rotatingPoint.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		rotatingPoint.transform.rotation = newRotation;

		if (isShouldActive && objectState == ObjectState.Off) {
			OpenDoor();

		} else if (!isShouldActive && objectState == ObjectState.Active) {
			CloseDoor();

		}

	}

	public void SetCollideStatus (bool isShouldActive) {
		this.isShouldActive = isShouldActive;
	}

	protected void OpenDoor () {

		targetRotation *= Quaternion.Euler(0f, 0f, -90f);
		objectState = ObjectState.Active;
	}

	protected void CloseDoor () {

		targetRotation *= Quaternion.Euler(0f, 0f, 90f);
		objectState = ObjectState.Off;
	}
}
