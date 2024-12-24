using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private float swipeThreshold = 50.0f;
    
    #region public variables
    public bool tap
    {
        get { return _tap; }
    }
    public Vector2 touchPosition
    {
        get { return _touchPosition; }
    }
    public bool swipeLeft
    {
        get
        {
            _swiperLeftCounter++;
            return _swipeLeft;
        }
    }
    public bool swipeRight
    {
        get
        {
            _swipeRightCounter++;
            return _swipeRight;
        }
    }
    public bool swipeUp
    {
        get
        {
            _swipeUpCounter++;
            return _swipeUp;
        }
    }
    public bool swipeDown
    {
        get
        {
            _swipeDownCounter++;
            return _swipeDown;
        }
    }
    #endregion

    #region private variables
    private bool _tap;
    private Vector2 _touchPosition;
    private Vector2 _startDrag;
    private bool _swipeLeft;
    private bool _swipeRight;
    private bool _swipeUp;
    private bool _swipeDown;
    private int _swiperLeftCounter;
    private int _swipeRightCounter;
    private int _swipeUpCounter;
    private int _swipeDownCounter;
    
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

    private void LateUpdate()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        _tap = _swipeRight = _swipeLeft = _swipeUp = _swipeDown = false;
        _touchPosition = Vector2.zero;
    }

    private void Controls()
    {
        actionScheme = new Runner();
        actionScheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionScheme.Gameplay.TouchPosition.performed += ctx => OnTouchPosition(ctx);
        actionScheme.Gameplay.StartDrag.performed += ctx => OnStartDrag(ctx);
        actionScheme.Gameplay.ReleaseDrag.performed += ctx => OnReleaseDrag(ctx);
    }

    private void OnReleaseDrag(InputAction.CallbackContext ctx)
    {
        Vector2 delta = _touchPosition - _startDrag;
        float sqrDistance = delta.sqrMagnitude;
        
        if (sqrDistance > swipeThreshold)
        {
            float horizontal = Mathf.Abs(delta.x);
            float vertical = Mathf.Abs(delta.y);

            if (vertical > horizontal)
            {
                if (delta.y > 0)
                {
                    _swipeUp = true;
                }
                else
                {
                    _swipeDown = true;
                }
            }
            else
            {
                if (delta.x > 0)
                {
                    _swipeRight = true;
                }
                else
                {
                    _swipeLeft = true;
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
