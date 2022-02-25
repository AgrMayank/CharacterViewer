using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CharacterManager : MonoBehaviour
{
    private GameObject m_mainCharacter;

    [SerializeField]
    private GameObject m_mainCharacterPrefab;

    [SerializeField]
    private Material m_mainCharacterClothMaterial, m_mainCharacterSkinMaterial;

    [SerializeField]
    public FlexibleColorPicker m_clothColorPicker, m_skinColorPicker;

    [SerializeField]
    private Material[] m_skyboxMaterials;
    private int m_currentSkyboxIndex = 0;

    private Animator m_animator;

    private void Start()
    {
        RenderSettings.skybox = m_skyboxMaterials[m_currentSkyboxIndex];
    }

    // Change main character animation
    public void ChangeAnimation(string animName)
    {
        if (m_animator == null)
        {
            if (m_mainCharacter == null)
            {
                m_mainCharacter = GameObject.FindGameObjectWithTag("Player");
            }

            m_animator = m_mainCharacter.GetComponentInChildren<Animator>();
        }

        m_animator.SetTrigger(animName);
    }

    // Change Skybox
    public void ChangeSkybox()
    {
        m_currentSkyboxIndex = (m_currentSkyboxIndex + 1) % m_skyboxMaterials.Length;
        RenderSettings.skybox = m_skyboxMaterials[m_currentSkyboxIndex];
    }

    private void Update()
    {
        // Change main character skin & cloth color
        m_mainCharacterClothMaterial.color = m_clothColorPicker.color;
        m_mainCharacterSkinMaterial.color = m_skinColorPicker.color;

        // Check if the main character is null and instantiate it if it is
        if (m_mainCharacter == null)
        {
            m_mainCharacter = GameObject.FindGameObjectWithTag("Player");

            if (m_mainCharacter == null)
            {
                m_mainCharacter = Instantiate(m_mainCharacterPrefab) as GameObject;
                m_mainCharacter.transform.position = Camera.main.transform.forward * 2 + new Vector3(0, -0.6f, 0);
                m_mainCharacter.transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles + new Vector3(0, 180, 0));
                m_mainCharacter.transform.localScale = new Vector3(2f, 2f, 2f);
                m_mainCharacter.AddComponent<ARAnchor>();
            }
        }
    }
}