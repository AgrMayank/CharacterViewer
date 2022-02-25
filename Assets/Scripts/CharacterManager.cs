using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mainCharacter;

    [SerializeField]
    private Material m_mainCharacterClothMaterial, m_mainCharacterSkinMaterial;

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
            m_animator = m_mainCharacter.GetComponent<Animator>();
        }

        m_animator.SetTrigger(animName);
    }

    // Change Skybox
    public void ChangeSkybox()
    {
        m_currentSkyboxIndex = (m_currentSkyboxIndex + 1) % m_skyboxMaterials.Length;
        RenderSettings.skybox = m_skyboxMaterials[m_currentSkyboxIndex];
    }
}