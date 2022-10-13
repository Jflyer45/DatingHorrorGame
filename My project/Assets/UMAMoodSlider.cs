using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;
using UMA.PoseTools;

public class UMAMoodSlider : MonoBehaviour
{

    private DynamicCharacterAvatar avatar;
    private ExpressionPlayer expression;
    private bool connected = false;

    [Range(-3, 3)]
    public int mood;

    void OnEnable()
    {
        avatar = GetComponent<DynamicCharacterAvatar>();
        avatar.CharacterCreated.AddListener(OnCreated);
    }

    void OnDisable()
    {
        avatar.CharacterCreated.RemoveListener(OnCreated);
    }

    public void OnCreated(UMAData data)
    {
        expression = GetComponent<ExpressionPlayer>();
        expression.enableBlinking = true;
        expression.enableSaccades = true;
        connected = true;
    }

    void Update()
    {
        if (connected)
        {
            float delta = 10 * Time.deltaTime;
            switch (mood)
            {
                // Reset nuetural
                case 0:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, 0, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, 0, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, 0, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, 0, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, 0, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, 0, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, 0, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    break;
                // Slight happyness.
                case 1:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, .7f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, .3f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, .3f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, .3f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, .3f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -.5f, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -.5f, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    break;
                // Happy
                case 2:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, .7f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, .7f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, .5f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, .5f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, .5f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -.6f, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -.6f, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    break;
                // Very Happy
                case 3:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, 1f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, 1f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, 1f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, .5f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, .5f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -1f, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -1f, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    expression.mouthUp_Down = Mathf.Lerp(expression.mouthUp_Down, -1, delta);
                    break;
                case -1:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, -.3f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, -.3f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, -.3f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, .3f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, .3f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, .3f, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, .3f, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, 0, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, 0, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, .3f, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    expression.mouthUp_Down = Mathf.Lerp(expression.mouthUp_Down, 0, delta);
                    break;
                case -2:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, -.6f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, -.6f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, -.6f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, .6f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, .6f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, .6f, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, .6f, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, 0, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, 0, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, .6f, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    expression.mouthUp_Down = Mathf.Lerp(expression.mouthUp_Down, 0, delta);
                    break;
                case -3:
                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, -1f, delta);
                    expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, -1f, delta);
                    expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, -1f, delta);
                    expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, 1f, delta);
                    expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, 1f, delta);
                    expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 1f, delta);
                    expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 1f, delta);
                    expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, 0, delta);
                    expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, 0, delta);
                    expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0, delta);
                    expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0, delta);
                    expression.noseSneer = Mathf.Lerp(expression.noseSneer, 1f, delta);
                    expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0, delta);
                    expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0, delta);
                    expression.mouthUp_Down = Mathf.Lerp(expression.mouthUp_Down, 0, delta);
                    break;
                default:
                    break;
            }
        }
    }
}

//case 1:
//                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, 0.7f, delta);
//expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, 0.7f, delta);
//expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, -0.7f, delta);
//expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, 0f, delta);
//expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, 0f, delta);
//expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0f, delta);
//expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0f, delta);
//expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -0f, delta);
//expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -0f, delta);
//expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0f, delta);
//expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0f, delta);
//expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0.1f, delta);
//expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, -0.2f, delta);
//expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, -0.2f, delta);
//break;
//                case 2:
//                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, -0.8f, delta);
//expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, -0.8f, delta);
//expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, 0.7f, delta);
//expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, -0.3f, delta);
//expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, -0.3f, delta);
//expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0f, delta);
//expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0, delta);
//expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, 0f, delta);
//expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, 0f, delta);
//expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, -0.7f, delta);
//expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0f, delta);
//expression.noseSneer = Mathf.Lerp(expression.noseSneer, -0.1f, delta);
//expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 0.5f, delta);
//expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 0.5f, delta);
//break;
//                case 3:
//                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, -0.3f, delta);
//expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, -0.3f, delta);
//expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, -1f, delta);
//expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, 1f, delta);
//expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, 1f, delta);
//expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0.7f, delta);
//expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0.7f, delta);
//expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -0.7f, delta);
//expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -0.7f, delta);
//expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, 0.7f, delta);
//expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, -0.3f, delta);
//expression.noseSneer = Mathf.Lerp(expression.noseSneer, 0.3f, delta);
//expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, -0.2f, delta);
//expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, -0.2f, delta);
//break;
//                case 4:
//                    expression.leftMouthSmile_Frown = Mathf.Lerp(expression.leftMouthSmile_Frown, 0f, delta);
//expression.rightMouthSmile_Frown = Mathf.Lerp(expression.rightMouthSmile_Frown, 0f, delta);
//expression.midBrowUp_Down = Mathf.Lerp(expression.midBrowUp_Down, 1f, delta);
//expression.leftBrowUp_Down = Mathf.Lerp(expression.leftBrowUp_Down, 1f, delta);
//expression.rightBrowUp_Down = Mathf.Lerp(expression.rightBrowUp_Down, 1f, delta);
//expression.rightUpperLipUp_Down = Mathf.Lerp(expression.rightUpperLipUp_Down, 0f, delta);
//expression.leftUpperLipUp_Down = Mathf.Lerp(expression.leftUpperLipUp_Down, 0f, delta);
//expression.rightLowerLipUp_Down = Mathf.Lerp(expression.rightLowerLipUp_Down, -0f, delta);
//expression.leftLowerLipUp_Down = Mathf.Lerp(expression.leftLowerLipUp_Down, -0f, delta);
//expression.mouthNarrow_Pucker = Mathf.Lerp(expression.mouthNarrow_Pucker, -1f, delta);
//expression.jawOpen_Close = Mathf.Lerp(expression.jawOpen_Close, 0.8f, delta);
//expression.noseSneer = Mathf.Lerp(expression.noseSneer, -0.3f, delta);
//expression.leftEyeOpen_Close = Mathf.Lerp(expression.leftEyeOpen_Close, 1f, delta);
//expression.rightEyeOpen_Close = Mathf.Lerp(expression.rightEyeOpen_Close, 1f, delta);
//break;