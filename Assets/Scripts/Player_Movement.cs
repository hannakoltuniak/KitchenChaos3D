using System.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private Game_Input gameInput;
    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        float moveDis = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeigth = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigth, playerRadius, moveDir, moveDis);
        
        if (!canMove)
        {
            //nie może się ruszyć w stronę moveDir

            //X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigth, playerRadius, moveDirX, moveDis);

            if (canMove)
            {
                //ruch tylko na linii X

                moveDir = moveDirX;
            }
            else 
            {
                //nie może się ruszać na linii X

                //tylko ruch na Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigth, playerRadius, moveDirX, moveDis);

                if (canMove)
                {
                    //ruch tylko na Z

                    moveDir = moveDirZ;
                }
                else 
                {
                    //nie może się ruszać na Z

                }
            }
        }

        if (canMove)
            transform.position +=  moveDir *moveDis;

        isWalking = moveDir != Vector3.zero;

        //lerp -> do pozycji, Slerp -> do rotacji 
        float rotationSpeed = 18f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    public bool Is_Walking()
    {
        return isWalking;
    }
    
}
