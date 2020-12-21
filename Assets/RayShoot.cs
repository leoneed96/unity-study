using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ProcessShoot();
    }
    void OnGUI()
    {
        var pointSize = 12;

        var pos = (
            x: _camera.pixelWidth / 2 - pointSize / 4, 
            y: _camera.pixelHeight / 2 - pointSize / 2);

        GUI.Label(new Rect(pos.x, pos.y, pointSize, pointSize), "*");
    }
    private void ProcessShoot()
    {
        var middlePoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
        var ray = _camera.ScreenPointToRay(middlePoint);

        if (Physics.Raycast(ray, out var hit))
        {
            var target = hit.transform.gameObject.GetComponent<ReactiveTarget>();
            if (target != null)
                target.React();
            else
                StartCoroutine(PointShoot(hit.point));
        }
    }

    private IEnumerator PointShoot(Vector3 hitPoint)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hitPoint;
        yield return new WaitForSeconds(2);

        Destroy(sphere);
    }
}
