using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour {

	private string _key;

	private int _content;

	public StatItem(string key, int content)
	{
		_key = key;
		_content = content;
	}

	public string Key
	{
		get { return _key; }
	}

	public int Content
	{
		get { return _content; }
		set { _content = value; }
	}
}
