﻿using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour
{

	public AudioClip click;
	AudioSource audio;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}
	

	// Use this for initialization
	void OnMouseDown ()
	{
		Debug.Log ("Click");
		audio.PlayOneShot (click, 1.0f);

	}
}
