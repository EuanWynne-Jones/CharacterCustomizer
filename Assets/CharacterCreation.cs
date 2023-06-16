using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCustomizer.Core
{
    public class CharacterCreation : MonoBehaviour
    {
        public CharacterGender gender;

        [Header("Male")]
        public List<GameObject> maleHeads = new List<GameObject>();
        public List<GameObject> maleBrows = new List<GameObject>();
        public List<GameObject> maleFacialHair = new List<GameObject>();
        public List<GameObject> maleTorsos = new List<GameObject>();
        public List<GameObject> maleArmsUpperRight = new List<GameObject>();
        public List<GameObject> maleArmsLowerRight = new List<GameObject>();
        public List<GameObject> maleArmsUpperLeft = new List<GameObject>();
        public List<GameObject> maleArmsLowerLeft = new List<GameObject>();
        public List<GameObject> maleHandsRight = new List<GameObject>();
        public List<GameObject> maleHandsLeft = new List<GameObject>();
        public List<GameObject> maleHips = new List<GameObject>();
        public List<GameObject> maleLegRight = new List<GameObject>();
        public List<GameObject> maleLegLeft = new List<GameObject>();


        [Header("Female")]
        public List<GameObject> femaleHeads = new List<GameObject>();
        public List<GameObject> femaleBrows = new List<GameObject>();
        public List<GameObject> femaleTorso = new List<GameObject>();
        public List<GameObject> femaleArmsUpperRight = new List<GameObject>();
        public List<GameObject> femaleArmsLowerRight = new List<GameObject>();
        public List<GameObject> femaleArmsUpperLeft = new List<GameObject>();
        public List<GameObject> femaleArmsLowerLeft = new List<GameObject>();
        public List<GameObject> femaleHandsRight = new List<GameObject>();
        public List<GameObject> femaleHandsLeft = new List<GameObject>();
        public List<GameObject> femaleHips = new List<GameObject>();
        public List<GameObject> femaleLegRight = new List<GameObject>();
        public List<GameObject> femaleLegLeft = new List<GameObject>();


        [System.Serializable]
        public enum CharacterGender
        {
            Male,
            Female
        }

        private void Start()
        {
            GetAllBodyParts();
        }

        private void GetAllBodyParts()
        {
            GetHeads(transform);
            GetEyebrows(transform);
            GetFacialHair(transform);
            GetTorsos(transform);
            GetArmsUpperRight(transform);
            GetArmsLowerRight(transform);
            GetArmsUpperLeft(transform);
            GetArmsLowerLeft(transform);
            GetRightHands(transform);
            GetLeftHands(transform);
            GetHips(transform);
            GetRightLeg(transform);
            GetLeftLeg(transform);
        }
        // Non-Gender specific functions for getting all body parts that meet the enum requirments, adding each of these to respective lists above
        private void GetHeads(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHeads.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHeads.Add(child.gameObject);
                }

                GetHeads(child);
            }
        }
        private void GetEyebrows(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleBrows.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleBrows.Add(child.gameObject);
                }

                GetEyebrows(child);
            }
        }
        private void GetFacialHair(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.FacialHair &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleFacialHair.Add(child.gameObject);
                }


                GetFacialHair(child);
            }
        }
        private void GetTorsos(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Torso &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleTorsos.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Torso &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleTorso.Add(child.gameObject);
                }

                GetTorsos(child);
            }
        }
        private void GetArmsUpperRight(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsUpperRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsUpperRight.Add(child.gameObject);
                }

                GetArmsUpperRight(child);
            }
        }
        private void GetArmsLowerRight(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsLowerRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsLowerRight.Add(child.gameObject);
                }

                GetArmsLowerRight(child);
            }
        }
        private void GetArmsUpperLeft(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsUpperLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsUpperLeft.Add(child.gameObject);
                }

                GetArmsUpperLeft(child);
            }
        }
        private void GetArmsLowerLeft(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsLowerLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsLowerLeft.Add(child.gameObject);
                }

                GetArmsLowerLeft(child);
            }
        }
        private void GetRightHands(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHandsRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHandsRight.Add(child.gameObject);
                }

                GetRightHands(child);
            }
        }
        private void GetLeftHands(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHandsLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    maleHandsLeft.Add(child.gameObject);
                }

                GetLeftHands(child);
            }
        }
        private void GetHips(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hips &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHips.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hips &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHips.Add(child.gameObject);
                }

                GetHips(child);
            }
        }
        private void GetRightLeg(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleLegRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleLegRight.Add(child.gameObject);
                }

                GetRightLeg(child);
            }
        }
        private void GetLeftLeg(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleLegLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleLegLeft.Add(child.gameObject);
                }

                GetLeftLeg(child);
            }
        }
    }

}