using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // E�er do�ru cevap verildiyse k�p� hareket ettir
        if (MathQuestionManager.correctAnswerGiven)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.fixedDeltaTime * speed, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.fixedDeltaTime * speed, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.fixedDeltaTime * speed, Space.World);
            }
        }
    }
}
