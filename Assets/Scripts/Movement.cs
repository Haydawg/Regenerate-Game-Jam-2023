using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;
    [SerializeField] private float yMovement;
    [SerializeField] private float xMovement;

    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;
    public int movementPoints;

    private Camera cam;

    bool moving;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<Camera>();
    }

    public void AddMovementPoints(int points)
    {
        movementPoints += points;
        HUD.Instance.UpdateMovementPointUI(movementPoints);
    }

    public void ResetMovementPoints(int points)
    {
        movementPoints = points;
        HUD.Instance.UpdateMovementPointUI(movementPoints);
    }

    public void MoveCamera(int direction)
    {
        if (moving) return;
        if(movementPoints > 0)
        {
            switch (direction)
            {

                case 0:
                    if (transform.position.x > minBounds.x)
                    {
                        Debug.Log("Test");
                        StartCoroutine(TransitionCamera((new Vector3(-xMovement, 0, 0))));
                        movementPoints--;
                    }
                    break;
                case 1:
                    if (transform.position.y < maxBounds.y)
                    {
                        StartCoroutine(TransitionCamera((new Vector3(0, yMovement, 0))));
                        movementPoints--;
                    }
                    break;
                case 2:
                    if (transform.position.x < maxBounds.x)
                    {
                        StartCoroutine(TransitionCamera((new Vector3(xMovement, 0, 0))));
                        movementPoints--;
                    }
                    break;
                case 3:
                    if (transform.position.y > minBounds.y)
                    {
                        StartCoroutine(TransitionCamera((new Vector3(0, -yMovement, 0))));
                        movementPoints--;
                    }
                    break;
            }
            
            HUD.Instance.UpdateMovementPointUI(movementPoints);
        }
    }
    IEnumerator TransitionCamera(Vector3 moveDirection)
    {
        moving = true;
        var time = 0f;
        Vector3 start = cam.transform.position;
        while (time < 1)
        {
            time += Time.deltaTime;
            cam.transform.position = Vector2.Lerp(start, start + moveDirection, time);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
            yield return null;

        }
        moving = false;
    }

    public void ReturnToCentre()
    {
        StartCoroutine(TransitionCamera(Vector3.zero));
    }
}
