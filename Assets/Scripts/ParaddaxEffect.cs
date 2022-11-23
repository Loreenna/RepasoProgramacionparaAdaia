using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaddaxEffect : MonoBehaviour
{
    [SerializeField]private float paraddaxMultiplier;

    private Transform cameraTransform;
    private Vector3 cameraPreviousPos;

    private float spriteWidth;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        //camera.main para acceder a la camara principal
        cameraTransform = Camera.main.transform;
        cameraPreviousPos = cameraTransform.position;

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = (cameraTransform.position.x - cameraPreviousPos.x) * paraddaxMultiplier;
        //para saber cuanto se ha movido nuestra imagen
        float spriteMoveAmount = cameraTransform.position.x * (1 - paraddaxMultiplier);
        transform.Translate(new Vector3(x, 0f, 0f));
        cameraPreviousPos = cameraTransform.position;
        
        if(spriteMoveAmount > startPos + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0f, 0f));
            startPos += spriteWidth;
        }
        else if(spriteMoveAmount < startPos - spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0f, 0f));
            startPos += spriteWidth;
        }
    }
}
