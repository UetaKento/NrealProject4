using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using VRM;

public class MotionManager : MonoBehaviour
{
    Animator animator;
    private VRMBlendShapeProxy proxy;
    public GameObject model; // VRMモデルのオブジェクトを設定
    public HandEnum handEnum_R; //ハンドトラッキングの様々な情報を参照できる。
    public HandEnum handEnum_L;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Switch文で書こう。
    void Update()
    {

        var handState_R = NRInput.Hands.GetHandState(handEnum_R); //Update()の中に記述することで常に手の状態をチェックして更新する。
        var handState_L = NRInput.Hands.GetHandState(handEnum_L);

        //HandGesture handGesture = handState.currentGesture;
        if (handState_L.currentGesture == HandGesture.Point)
        {
            animator.SetBool("Is_Jump", true);
        }
        else
        {
            animator.SetBool("Is_Jump", false);
        }
        if (handState_L.currentGesture == HandGesture.Victory)
        {
            animator.SetBool("Is_Piece", true);
        }
        else
        {
            animator.SetBool("Is_Piece", false);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("右手にぶつかった!");
    //    animator.SetTrigger("Jump");
    //}
    
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("右手にぶつかっている!");
        animator.SetBool("Is_Joy", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("右手が離れた！");
        animator.SetBool("Is_Joy", false);
    }
}
