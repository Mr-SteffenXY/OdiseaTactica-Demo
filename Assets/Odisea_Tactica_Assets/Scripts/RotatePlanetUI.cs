using UnityEngine;

/// <summary>
/// This class is used to rotate the planet in the UI.
/// </summary>
public class RotatePlanetUI : MonoBehaviour
{
    /// <summary>
    /// The camera that renders the UI.
    /// </summary>
    public Camera renderCamera;

    /// <summary>
    /// The speed at which the planet rotates.
    /// </summary>
    public float rotationSpeed = 100f;

    private Vector3 screenPoint;
    private Vector3 mousePosition;
    private float angleX;
    private float angleY;

    /// <summary>
    /// Update is called once per frame. It is used to rotate the planet based on the mouse position.
    /// </summary>
    private void Update()
    {
        mousePosition = Input.mousePosition;
        screenPoint = renderCamera.ScreenToViewportPoint(mousePosition);

        angleX = (screenPoint.y - 0.5f) * rotationSpeed;
        angleY = (screenPoint.x - 0.5f) * rotationSpeed;

        transform.rotation = Quaternion.Euler(angleX, -angleY, 0);
    }
}
