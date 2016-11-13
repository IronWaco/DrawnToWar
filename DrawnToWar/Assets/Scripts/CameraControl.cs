using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	Transform _player;
	float _desiredRotation;

	public float MovementSmoothness = 2f;
	public float RotationSmoothness = 2f;

	public float RotationVelocity = 3.0f;

	void Start () 
	{
		GameObject pl = GameObject.FindGameObjectWithTag("Player");
		if(pl==null)
			throw new UnityException("Should add a Player to scene");

		_player = pl.transform;

		_desiredRotation = transform.rotation.eulerAngles.y;
	}



	void Update () 
	{
		transform.position = Vector3.Lerp(transform.position, _player.position, MovementSmoothness * Time.deltaTime);

		float rotationFactor = Input.GetAxis("RotateCamera");


		_desiredRotation += rotationFactor * RotationVelocity;

		Quaternion targetRotation = Quaternion.Euler(0, _desiredRotation, 0);

		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSmoothness * Time.deltaTime);
	}
}
