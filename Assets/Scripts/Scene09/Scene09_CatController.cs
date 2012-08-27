using UnityEngine;
using System.Collections;

public class Scene09_CatController : MonoBehaviour {

	public float catSpeed = 100f;
	private Vector3 direction;
	private IRagePixel rage;
	private bool _active = true;
	private float seekTime;
	private GameObject player;
	
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		direction = (player.transform.position - transform.position);
		direction.Normalize ();
		direction.y = 0.0f;
		
		rage = GetComponent<RagePixelSprite> ();
		rage.SetTintColor (ColorUtils.RandomColor ());
		rage.PlayNamedAnimation ("idle");
		
		seekTime = Time.time + Random.Range (0f, 5.0f);
	}
	
	void Update ()
	{
		if (!_active) {
			collider.enabled = false;
			return;
		}
		

		if (Time.time > seekTime) {
			direction = (player.transform.position - transform.position);
			direction.Normalize ();
		}
		transform.Translate (direction * Time.deltaTime * catSpeed);
		rage.SetHorizontalFlip (direction.x>0.0f);


	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			GameObject.FindGameObjectWithTag ("GameController").SendMessage ("PlayerHit");
			Die ();
		}
	}
	
	public void Die ()
	{
		_active = false;
		audio.Play ();
		AnimateAndDestroy (gameObject, "die");
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
