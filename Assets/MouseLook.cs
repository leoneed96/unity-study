using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public RotateDirection RotateDirection;
    private float _rotationZ;
    public int MouseSensetivity = 3;
    void Start()
    {
        var body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateDirection == RotateDirection.Horizontal)
            ProcessHorizontal();
        else if (RotateDirection == RotateDirection.Vertical)
            ProcessVertical();
        else
        {
            ProcessHorizontal();
            ProcessVertical();
        }
    }

    private void ProcessHorizontal()
    {
        Debug.Log(Input.GetAxis("Mouse X"));
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
    private void ProcessVertical()
    {
        _rotationZ -= Input.GetAxis("Mouse Y");
        _rotationZ = Mathf.Clamp(_rotationZ, -45, 45);
        transform.localEulerAngles = new Vector3(_rotationZ, transform.localEulerAngles.y, 0);
    }
}

public enum RotateDirection
{
    Horizontal,
    Vertical,
    Both
}
