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
		private int jNum=0;
		private int rNum=0;
		private int lNum=0;
		private int time=0;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			jNum=UnityEngine.Random.Range(0,jumpKey.Length);
			rNum=UnityEngine.Random.Range(0,rightKey.Length);
			lNum=UnityEngine.Random.Range(0,leftKey.Length);
			print ("Jump: "+jumpKey[jNum]);
			print ("Right: "+rightKey[rNum]);
			print ("Left: "+leftKey[lNum]);
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
			time++;
			if (time == 1200) {
				jNum=UnityEngine.Random.Range(0,jumpKey.Length);
				rNum=UnityEngine.Random.Range(0,rightKey.Length);
				lNum=UnityEngine.Random.Range(0,leftKey.Length);
				print ("Jump: "+jumpKey[jNum]);
				print ("Right: "+rightKey[rNum]);
				print ("Left: "+leftKey[lNum]);
				time = 0;
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
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
