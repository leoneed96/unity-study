using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void React()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-35, 0, 0);
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
