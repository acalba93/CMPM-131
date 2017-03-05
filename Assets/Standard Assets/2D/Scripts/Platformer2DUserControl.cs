using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private KeyCode[] jumpKey={KeyCode.Q,KeyCode.W,KeyCode.E,KeyCode.R,KeyCode.T,KeyCode.Y,KeyCode.U,KeyCode.I,KeyCode.O,KeyCode.P};
		private KeyCode[] rightKey={KeyCode.H,KeyCode.J,KeyCode.K,KeyCode.L,KeyCode.Semicolon};
		private KeyCode[] leftKey={KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.F,KeyCode.G};
		private KeyCode[] crouchKey={KeyCode.Z,KeyCode.X,KeyCode.C,KeyCode.V,KeyCode.B,KeyCode.N,KeyCode.M};
		private int jNum=0;
		private int rNum=0;
		private int lNum=0;
		private int cNum=0;
		private int time=0;
		private GameObject key;
		private Transform lightUp;
		private Transform lightRight;
		private Transform lightLeft;
		private Transform lightCrouch;
		private	string keyName;
		[SerializeField] public int SwitchTime = 300;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			jNum=UnityEngine.Random.Range(0,jumpKey.Length);
			rNum=UnityEngine.Random.Range(0,rightKey.Length);
			lNum=UnityEngine.Random.Range(0,leftKey.Length);
			cNum=UnityEngine.Random.Range(0,crouchKey.Length);
			lightRight=GameObject.Find("Canvas/Keyboard/Q/Right").transform;
			lightLeft=GameObject.Find("Canvas/Keyboard/Q/Left").transform;
			lightUp=GameObject.Find("Canvas/Keyboard/Q/Jump").transform;
			lightCrouch=GameObject.Find("Canvas/Keyboard/Q/Crouch").transform;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
				if (Input.GetKey(jumpKey[jNum])) {
					m_Jump = true;
				}
            }
			time--;
			if (time <= 0) {
				time = SwitchTime;
				if (!Input.GetKey(jumpKey[jNum]))jNum=UnityEngine.Random.Range(0,jumpKey.Length);
				if (!Input.GetKey(rightKey[rNum]))rNum=UnityEngine.Random.Range(0,rightKey.Length);
				if (!Input.GetKey(leftKey[lNum]))lNum=UnityEngine.Random.Range(0,leftKey.Length);
				if (!Input.GetKey(crouchKey[cNum]))cNum=UnityEngine.Random.Range(0,crouchKey.Length);
				keyName = rightKey[rNum].ToString();
				if (keyName.CompareTo ("Semicolon") == 0) {
					keyName = ";";
				}
				key=GameObject.Find("Canvas/Keyboard/Q/"+keyName);
				lightRight.SetParent(key.transform,false);
				lightRight.SetAsFirstSibling();
				keyName = leftKey[lNum].ToString ();
				key=GameObject.Find("Canvas/Keyboard/Q/"+keyName);
				lightLeft.SetParent(key.transform,false);
				lightLeft.SetAsFirstSibling();
				keyName = jumpKey[jNum].ToString ();
				if (keyName.CompareTo ("Q") == 0) {
					key = GameObject.Find ("Canvas/Keyboard/" + keyName);
				} else {
					key = GameObject.Find ("Canvas/Keyboard/Q/" + keyName);
				}
				lightUp.SetParent(key.transform,false);
				lightUp.SetAsFirstSibling();
				keyName = crouchKey[cNum].ToString ();
				key=GameObject.Find("Canvas/Keyboard/Q/"+keyName);
				lightCrouch.SetParent(key.transform,false);
				lightCrouch.SetAsFirstSibling();
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
			bool crouch = Input.GetKey(crouchKey[cNum]);
			float h=0;
			if (Input.GetKey (rightKey[rNum])) {
				h = 1;
			} else if (Input.GetKey (leftKey[lNum])) {
				h = -1;
			}
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
