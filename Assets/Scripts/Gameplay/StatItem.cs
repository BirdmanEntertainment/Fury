using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour {

	private string _key;

	private float _content;

	public StatItem(string key, float value)
	{
		_key = key;
		_content = value;
	}

	public string Key
	{
		get { return _key; }
	}

	public float Content
	{
		get { return _content; }
		set { _content = value; }
	}
}
