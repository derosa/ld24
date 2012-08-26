using UnityEngine;
using System.Collections;

public class Screen09_BulletController : MonoBehaviour {
	
	public float bulletSpeed;
	
	private Vector3 direction;
	private bool _active = true;
	
	void Start ()
	{
		GetComponent<RagePixelSprite> ().PlayNamedAnimation("idle");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!_active) {
			collider.enabled = false;
			return;
		}
		transform.Translate (direction * Time.deltaTime * bulletSpeed);

		if (!IsInBounds ()) {
			Destroy (gameObject);
		}
	}
	
	private bool IsInBounds ()
	{
		
		return ScreenInfo.GetInstance().InScreen(transform.position);
	}
	
	public void SetTarget (Vector3 t)
	{
		direction = (t - transform.position);
		direction.Normalize ();
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("cat")) {
			Debug.Log ("Fuera gato");
			GameObject.FindGameObjectWithTag("GameController").SendMessage("KilledCat");
			other.SendMessage ("Die");
			Die ();
			
		}
	}
	
	public void Die ()
	{
		AnimateAndDestroy (gameObject, "explode");
		_active = false;
	}
	
	public void AnimateAndDestroy (GameObject rage, string animationName)
	{
		StartCoroutine (DoAnimateAndDestroy (rage, animationName));
	}
	
	IEnumerator DoAnimateAndDestroy (GameObject _rage, string animationName)
	{
		IRagePixel rage = _rage.GetComponent<RagePixelSprite> ();
			
		rage.StopAnimation ();
		rage.PlayNamedAnimation (animationName);
		while (rage.isPlaying()) {
			yield return new WaitForSeconds(0.1f);
		}
		Destroy (_rage);
		yield return 0;
	}
		
}
