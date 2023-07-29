using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DelegateModel(object sender, object args);

public class InputController : MonoBehaviour
{

    public static InputController instance;

    float verticalColdown = 0;
    float horizontalColdown = 0;
    float coldownTimer = 0.5f;

    public DelegateModel OnMove;
    public DelegateModel OnFire;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Vector3Int moved = new Vector3Int(0, 0, 0);
        if (horizontal != 0)
        {
            moved.x = GetMoved(ref horizontalColdown, horizontal);
        }
        else
            horizontalColdown = 0;

        if (vertical != 0)
        {
            moved.y = GetMoved(ref verticalColdown, vertical);
        }
        else
            verticalColdown = 0;


        if (moved != Vector3Int.zero && OnMove != null)
        {
            OnMove(null, moved);
        }

        if (Input.GetButtonDown("Fire1") && OnFire != null)
        {
            OnFire(null, 1);
        }
        if (Input.GetButtonDown("Fire2") && OnFire != null)
        {
            OnFire(null, 2);
        }
    }

    int GetMoved(ref float coldownSum, int value)
    {
        if (Time.time > coldownSum)
        {
            coldownSum += Time.time + coldownTimer;
            return value;
        }
        return 0;
    }
}
