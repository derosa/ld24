using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class PlayerAudio : MonoBehaviour {

	public AudioClip jump;
	public AudioClip die;
	public AudioClip coin;
	public AudioClip laser;
	
	public void SoundJump ()
	{
		audio.PlayOneShot (jump);
	}
	
	public void SoundDie ()
	{
		audio.PlayOneShot (die);
	}

	public void SoundCoin ()
	{
		audio.PlayOneShot (coin);
	}
	
	public void SoundLaser ()
	{
		audio.PlayOneShot (laser);
	}
	
	
}
