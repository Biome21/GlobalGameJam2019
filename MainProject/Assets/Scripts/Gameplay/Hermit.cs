﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermit : MonoBehaviour 
{
	private readonly float[] VELOCITIES = new float[]{12.0f, 10.0f, 8.0f, 7.0f, 6.0f};

	[SerializeField] private Transform m_ShellAnchor = null;
	private Rigidbody2D m_Rigidbody = null;
	private int m_Fatness = 0;
	private PlayerInputManager.ControllerInput m_Controller;
	private bool m_IsReady = false;

	public int Fatness
	{
		get
		{
			return m_Fatness;
		}
	}

	private float Velocity
	{
		get
		{
			return VELOCITIES[Mathf.Clamp(m_Fatness, 0, VELOCITIES.Length)];
		}
	}

	public bool IsReady
	{
		get
		{
			return m_IsReady;
		}
	}

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		
	}

	private void Update() 
	{
		//PlayerInputManager.Instance.DebugButton();

		Vector2 joystick = PlayerInputManager.Instance.GetLeftJoystick(m_Controller);
		Vector3 position = m_Rigidbody.position;
		position.x += Velocity * joystick.x * Time.deltaTime;
		position.y += Velocity * joystick.y * Time.deltaTime;

		// TODO: Prevent hermits from going out of bounds
		m_Rigidbody.MovePosition(position);
	}

	public void OnControllerReady(PlayerInputManager.ControllerInput controller)
	{	
		m_Controller = controller;

		m_IsReady = !m_IsReady;
		if (m_IsReady)
		{
			OnReady();
		}
		else
		{
			OnNotReady();
		}
	}

	private void OnReady()
	{
	}

	private void OnNotReady()
	{
	}
}
