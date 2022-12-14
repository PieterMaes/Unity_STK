using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterSeconds : MonoBehaviour
{

    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > 1) Destroy(this.gameObject);
    }
}
