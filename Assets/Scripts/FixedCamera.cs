using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    private bool hasPosition = false;


    void Start()
    {
        if (Application.isPlaying)
        {
            Invoke(nameof(AutodetectAndPosition),0.1f);
        }else
        {
            TryEditorPreview();
        }
    }

   void TryEditorPreview()
    {
        var generate = FindAnyObjectByType<RandomGenetaror>();

        if ( generate)
        {
            PositionCamera(generate.width + (2 * generate.offset), generate.height, generate.offset);
        }
        else
        {
            PositionCamera(12, 8, 0);
        }
    }

    void AutodetectAndPosition()
    {
        if (hasPosition)
        {
            return;
        }

        RandomGenetaror genetaror = FindAnyObjectByType<RandomGenetaror> ();

        if( genetaror != null)
        {
            int totalWidth = genetaror.width + (2 * genetaror.offset);

            PositionCamera(totalWidth, genetaror. height, genetaror.offset);

            hasPosition = false;
        }
    }

    void PositionCamera(int roomWidth, int roomHeight, int offset)
    {
        Camera camera = Camera.main;

        if(camera == null || !camera.orthographic)
        {
            return;
        }

        float aspectRatio = (float) Screen.width / Screen.height;
        float halfHeight = roomHeight / 2;
        float padding = 0.5f;
        float requiredHeight = halfHeight + padding;
        float halfWidth = roomWidth / 2;
        float requiredWidth = (halfWidth / aspectRatio) + padding;

        camera.orthographicSize = Mathf.Max(requiredWidth, requiredHeight);

        camera.transform.position = new Vector3((roomWidth / 2f) - offset, (roomHeight / 2) - 0.5f, -10f);
    }
}
