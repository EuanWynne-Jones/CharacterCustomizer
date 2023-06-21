using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCustomizer.Core
{
    public class BodyPartCollection : MonoBehaviour
    {
        public CharacterGender gender;
        public BodyPieceType bodyPieceType;

        [HideInInspector] public GameObject Piece;
        [System.Serializable]
        public enum CharacterGender
        {
            Male,
            Female,
            Both
        }

        [System.Serializable]
        public enum BodyPieceType
        {
            Head,
            Eyebrows,
            FacialHair,
            Torso,
            ArmUpperRight,
            ArmUpperLeft,
            ArmLowerRight,
            ArmLowerLeft,
            HandRight,
            HandLeft,
            Hips,
            LegRight,
            LegLeft,
            Hairstyle,
            Ears,
            Faceplate

        }

        

        private void Awake()
        {
            Piece = gameObject;
        }
    }
}
