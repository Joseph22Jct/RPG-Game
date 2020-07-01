using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStep : MonoBehaviour
{
    // Start is called before the first frame update

    public int typeOfAnimation;
    public Transform TargetT;

    public int typeOfMovement;
    public Transform ObjLookAt;
    public GameObject ThisObject;
    public float speed;
    public int selectedFrame;
    public int selectedcharacter;
    public int Particle;
    public float Timer;
    public float HowLong;
    public AnimationStep MoveCamera(int TypeOfMovement, Transform TargetTransform, Transform ObjectToLookAt, float Speed, float timer){
        typeOfAnimation = 0;
        typeOfMovement = TypeOfMovement;
        TargetT= TargetTransform;
        ObjLookAt = ObjectToLookAt;
        speed = Speed;
        Timer = timer;
        

        return this;
    }

    public AnimationStep MoveCharacter(int TypeOfMovement, Transform TargetTransform, Transform ObjectToLookAt, float Speed, float timer){
        typeOfAnimation = 1;
        typeOfMovement = TypeOfMovement;
        TargetT= TargetTransform;
        ObjLookAt = ObjectToLookAt;
        speed = Speed;
        Timer = timer;
       
        return this;
    }

    public AnimationStep PlayParticleEffect(int particle, Transform TargetTransform, Transform ObjectToLookAt, float Speed, float timer){
        typeOfAnimation = 2;
        Particle = particle;
        TargetT= TargetTransform;
        ObjLookAt = ObjectToLookAt;
        speed = Speed;
        Timer = timer;
        
        return this;
    }

    public AnimationStep ChangeCharacterAnimation(int whatFrame, int whichCharacter, float timer){
        typeOfAnimation = 3;
        selectedFrame = whatFrame;
        selectedcharacter = whichCharacter;
        Timer = timer;
        return this;
    }

    public AnimationStep End(){
        typeOfAnimation = -1;
        return this;
    }
}
