using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class HumanoidHandPoseHelper : MonoBehaviour {

    public bool isShowEditHandPose = true;//編集中のポーズを表示に反映するか

    Animator animator;
    public string animationClipName = "";

    public static Dictionary<string, string> TraitLeftHandPropMap = new Dictionary<string, string>
    {
            {"Left Thumb 1 Stretched", "LeftHand.Thumb.1 Stretched"},
            {"Left Thumb Spread", "LeftHand.Thumb.Spread"},
            {"Left Thumb 2 Stretched", "LeftHand.Thumb.2 Stretched"},
            {"Left Thumb 3 Stretched", "LeftHand.Thumb.3 Stretched"},
            {"Left Index 1 Stretched", "LeftHand.Index.1 Stretched"},
            {"Left Index Spread", "LeftHand.Index.Spread"},
            {"Left Index 2 Stretched", "LeftHand.Index.2 Stretched"},
            {"Left Index 3 Stretched", "LeftHand.Index.3 Stretched"},
            {"Left Middle 1 Stretched", "LeftHand.Middle.1 Stretched"},
            {"Left Middle Spread", "LeftHand.Middle.Spread"},
            {"Left Middle 2 Stretched", "LeftHand.Middle.2 Stretched"},
            {"Left Middle 3 Stretched", "LeftHand.Middle.3 Stretched"},
            {"Left Ring 1 Stretched", "LeftHand.Ring.1 Stretched"},
            {"Left Ring Spread", "LeftHand.Ring.Spread"},
            {"Left Ring 2 Stretched", "LeftHand.Ring.2 Stretched"},
            {"Left Ring 3 Stretched", "LeftHand.Ring.3 Stretched"},
            {"Left Little 1 Stretched", "LeftHand.Little.1 Stretched"},
            {"Left Little Spread", "LeftHand.Little.Spread"},
            {"Left Little 2 Stretched", "LeftHand.Little.2 Stretched"},
            {"Left Little 3 Stretched", "LeftHand.Little.3 Stretched"},
    };

    public static Dictionary<string, string> TraitRightHandPropMap = new Dictionary<string, string>
    {
            {"Right Thumb 1 Stretched", "RightHand.Thumb.1 Stretched"},
            {"Right Thumb Spread", "RightHand.Thumb.Spread"},
            {"Right Thumb 2 Stretched", "RightHand.Thumb.2 Stretched"},
            {"Right Thumb 3 Stretched", "RightHand.Thumb.3 Stretched"},
            {"Right Index 1 Stretched", "RightHand.Index.1 Stretched"},
            {"Right Index Spread", "RightHand.Index.Spread"},
            {"Right Index 2 Stretched", "RightHand.Index.2 Stretched"},
            {"Right Index 3 Stretched", "RightHand.Index.3 Stretched"},
            {"Right Middle 1 Stretched", "RightHand.Middle.1 Stretched"},
            {"Right Middle Spread", "RightHand.Middle.Spread"},
            {"Right Middle 2 Stretched", "RightHand.Middle.2 Stretched"},
            {"Right Middle 3 Stretched", "RightHand.Middle.3 Stretched"},
            {"Right Ring 1 Stretched", "RightHand.Ring.1 Stretched"},
            {"Right Ring Spread", "RightHand.Ring.Spread"},
            {"Right Ring 2 Stretched", "RightHand.Ring.2 Stretched"},
            {"Right Ring 3 Stretched", "RightHand.Ring.3 Stretched"},
            {"Right Little 1 Stretched", "RightHand.Little.1 Stretched"},
            {"Right Little Spread", "RightHand.Little.Spread"},
            {"Right Little 2 Stretched", "RightHand.Little.2 Stretched"},
            {"Right Little 3 Stretched", "RightHand.Little.3 Stretched"},
    };

    public Dictionary<string, float> leftHandPoseValueMap = new Dictionary<string, float>
    {
            {"Left Thumb 1 Stretched", 0f},
            {"Left Thumb Spread", 0f},
            {"Left Thumb 2 Stretched", 0f},
            {"Left Thumb 3 Stretched", 0f},
            {"Left Index 1 Stretched", 0f},
            {"Left Index Spread", 0f},
            {"Left Index 2 Stretched", 0f},
            {"Left Index 3 Stretched", 0f},
            {"Left Middle 1 Stretched", 0f},
            {"Left Middle Spread", 0f},
            {"Left Middle 2 Stretched", 0f},
            {"Left Middle 3 Stretched", 0f},
            {"Left Ring 1 Stretched", 0f},
            {"Left Ring Spread", 0f},
            {"Left Ring 2 Stretched", 0f},
            {"Left Ring 3 Stretched", 0f},
            {"Left Little 1 Stretched",0f},
            {"Left Little Spread", 0f},
            {"Left Little 2 Stretched", 0f},
            {"Left Little 3 Stretched", 0f},
    };
    public Dictionary<string, float> rightHandPoseValueMap = new Dictionary<string, float>
    {
                    {"Right Thumb 1 Stretched", 0f},
            {"Right Thumb Spread", 0f},
            {"Right Thumb 2 Stretched", 0f},
            {"Right Thumb 3 Stretched", 0f},
            {"Right Index 1 Stretched", 0f},
            {"Right Index Spread", 0f},
            {"Right Index 2 Stretched", 0f},
            {"Right Index 3 Stretched", 0f},
            {"Right Middle 1 Stretched", 0f},
            {"Right Middle Spread", 0f},
            {"Right Middle 2 Stretched", 0f},
            {"Right Middle 3 Stretched",0f},
            {"Right Ring 1 Stretched", 0f},
            {"Right Ring Spread", 0f},
            {"Right Ring 2 Stretched", 0f},
            {"Right Ring 3 Stretched", 0f},
            {"Right Little 1 Stretched", 0f},
            {"Right Little Spread", 0f},
            {"Right Little 2 Stretched", 0f},
            {"Right Little 3 Stretched", 0f},
    };

#if UNITY_EDITOR
    private void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
    }

    private void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
    }
#endif

    private void Start()
    {
        Reset();
    }

    // Use this for initialization
    void Reset () {
        animator = GetComponent<Animator>();//animator取得

	}
	
	// Update is called once per frame
	void EditorUpdate () {
        if (!isShowEditHandPose) { return; }
        if (animator == null) { return; }

        HumanPose pose=new HumanPose();
        var handler = new HumanPoseHandler(animator.avatar, animator.transform);

        handler.GetHumanPose(ref pose); //ポーズ取得

        //ハンドポーズを流し込む
        for (int i = 0; i < pose.muscles.Length; i++)
        {
            var muscle = HumanTrait.MuscleName[i];
            if (TraitLeftHandPropMap.ContainsKey(muscle)) //左手ポーズプロパティ
            {
                pose.muscles[i] = leftHandPoseValueMap[muscle];
            }
            else if (TraitRightHandPropMap.ContainsKey(muscle)) //右手ポーズプロパティ
            {
                pose.muscles[i] = rightHandPoseValueMap[muscle];
            }
        }

        handler.SetHumanPose(ref pose); //ポーズセット
	}
}
