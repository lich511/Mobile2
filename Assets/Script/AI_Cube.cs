using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Cube : MonoBehaviour
{
    public float _speed;
    public float _radius;

    private Vector3 _startpose;
    public Vector3 _target = new Vector3();
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startpose = _rb.position;
        _target = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(_startpose,_rb.position) < _radius)
		{
            _rb.velocity = _target * _speed;
		}
        else
		{
            _rb.velocity = Vector3.zero;
            if (gameObject.transform.localScale.x > 0.1f)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
            }
            else
                Destroy(gameObject);
		}
    }
}
