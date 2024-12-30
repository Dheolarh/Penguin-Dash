using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject
                    {
                        name = nameof(InputManager)
                    };
                    instance = go.AddComponent<InputManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private Runner actionScheme;
    
    //Configurations
    [SerializeField] private float swipeThreshold;
    
    #region public variables
    public bool tap { get { return _tap; } }
    public Vector2 touchPosition { get { return _touchPosition; } }
    public bool swipeLeft { get { return _swipeLeft; } }
    public bool swipeRight { get { return _swipeRight; } }
    public bool swipeUp { get { return _swipeUp; } }
    public bool swipeDown { get { return _swipeDown; } }
    #endregion
    
    #region private variables
    private Vector2 _touchPosition, _startDrag;
    private bool _tap, _swipeLeft, _swipeRight, _swipeUp, _swipeDown;
    private int _swiperLeftCounter, _swipeRightCounter, _swipeUpCounter, _swipeDownCounter;
    #endregion
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Controls();
    }

    private void Start()
    {
       swipeThreshold = Screen.dpi / 5;
    }
    
    private void LateUpdate()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        _tap = _swipeRight = _swipeLeft = _swipeUp = _swipeDown = false;
    }

    private void Controls()
    {
        actionScheme = new Runner();
        actionScheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionScheme.Gameplay.TouchPosition.performed += ctx => OnTouchPosition(ctx);
        actionScheme.Gameplay.StartDrag.performed += ctx => OnStartDrag(ctx);
        actionScheme.Gameplay.ReleaseDrag.performed += ctx => OnReleaseDrag(ctx);
        actionScheme.Gameplay.KeyboardInput.performed += ctx => OnKeyboardInput(ctx);
    }

    private void OnKeyboardInput(InputAction.CallbackContext ctx)
    {
        if (ctx.control is KeyControl key)
        {
            switch (key.keyCode)
            {
                case UnityEngine.InputSystem.Key.LeftArrow:
                    _swipeLeft = true;
                    break;
                case UnityEngine.InputSystem.Key.RightArrow:
                    _swipeRight = true;
                    break;
                case UnityEngine.InputSystem.Key.UpArrow:
                    _swipeUp = true;
                    break;
                case UnityEngine.InputSystem.Key.DownArrow:
                    _swipeDown = true;
                    break;
            }
        }
    }


    private void OnReleaseDrag(InputAction.CallbackContext ctx)
    {
        Vector2 delta = _touchPosition - _startDrag;
        float sqrDistance = delta.sqrMagnitude;
        
        if (sqrDistance > swipeThreshold)
        {
            float horizontal = Mathf.Abs(delta.x);
            float vertical = Mathf.Abs(delta.y);

            if (horizontal > vertical)
            {
                if (delta.x > 0)
                {
                    _swipeRight = true;
                    Debug.Log("Swipe Right");
                }
                else
                {
                    _swipeLeft = true;
                    Debug.Log("Swipe Left");
                }
            }
            else
            {
                if (delta.y > 0)
                {
                    _swipeUp = true;
                    Debug.Log("Swipe Up");
                }
                else
                {
                    _swipeDown = true;
                    Debug.Log("Swipe Down");
                }
            }
        }
        
        _startDrag = Vector2.zero;
    }

    private void OnStartDrag(InputAction.CallbackContext ctx)
    {
        _startDrag = _touchPosition;
    }

    private void OnTouchPosition(InputAction.CallbackContext ctx)
    {
        _touchPosition = ctx.ReadValue<Vector2>();
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        _tap = true;
    }

    public void OnEnable()
    {
        actionScheme.Enable();
    }
    public void OnDisable()
    {
        actionScheme.Disable();
    }
}
