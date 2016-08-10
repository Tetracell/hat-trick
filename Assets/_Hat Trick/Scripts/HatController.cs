using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

    public Camera cam;
    private Rigidbody2D hatBody;
    private float maxWidth;
    private Renderer hatWidth;
    public EdgeCollider2D hatCatch;

	// Use this for initialization
	void Start () {
	    if (cam == null)
        {
            cam = Camera.main;
        }
        hatBody = GetComponent<Rigidbody2D>();
        hatWidth = GetComponentInChildren<Renderer>(); // Needed because there is no sprite attached to this object.
        hatCatch = GetComponentInChildren<EdgeCollider2D>();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        var boner = hatWidth.bounds.extents.x;
        maxWidth = targetWidth.x - boner;
    }
	
	// Called once per physics timestep
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 1.1f, 0.0f);        
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        hatBody.MovePosition(targetPosition);
    }
}
