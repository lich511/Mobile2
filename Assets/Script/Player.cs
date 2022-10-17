using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _time, _speed, _dist, _kuldaun = 0;
    public InputField _IFtime, _IFspeed, _IFdist;
	public GameObject _cube, _tower;
	private bool _col = true;
	private bool _gra = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(_kuldaun <= 0 && _time != 0)
		{
			GameObject temp_cube = Instantiate(_cube);
			temp_cube.transform.position = new Vector3(_tower.transform.position.x, Random.Range(1f, 2f), _tower.transform.position.z);
			temp_cube.GetComponent<AI_Cube>()._radius = _dist;
			temp_cube.GetComponent<AI_Cube>()._speed = _speed;
			temp_cube.GetComponent<BoxCollider>().enabled = _col;
			temp_cube.GetComponent<Rigidbody>().useGravity = _gra;

			_kuldaun = _time;
		}
		else
			_kuldaun -= Time.deltaTime;
	}
    public void _Settime()
	{
		try
		{
            _time = float.Parse(_IFtime.text);
		}
		catch
		{
            _IFtime.text = _time.ToString();
		}
	}
    public void _Setspeed()
	{
		try
		{
			_speed = float.Parse(_IFspeed.text);
		}
		catch 
		{
			_IFspeed.text = _speed.ToString();
		}
	}
    public void _Setdist()
	{
		try
		{
			_dist = float.Parse(_IFdist.text);
		}
		catch 
		{
			_IFdist.text = _dist.ToString();
		}
	}
	public void _Clear()
	{
		GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
		foreach (var item in list)
		{
			Destroy(item.gameObject);
		}
	}
	public void _CCollid()
	{
		_col = !_col;
		GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
		foreach (var item in list)
		{
			item.GetComponent<BoxCollider>().enabled = _col;
		}
	}
	public void _CGravity()
	{
		_gra = !_gra;
		GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
		foreach (var item in list)
		{
			item.GetComponent<Rigidbody>().useGravity = _gra;
		}
	}
}
