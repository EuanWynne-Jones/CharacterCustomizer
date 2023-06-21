using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCustomizer.Core
{
    public class DefaultBodyPartSetup : MonoBehaviour
    {

        [Header("Races")]
        public List<Color> raceSkinColours = new List<Color>();
        public List<Color> secondaryRaceSkinColours = new List<Color>();
        public List<Color> tertiaryRaceSkinColours = new List<Color>();

        [Header("Ears")]
        public List<GameObject> ears = new List<GameObject>();

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

        [Header("Hair")]
        public List<GameObject> hairstyles = new List<GameObject>();

        [Header("HairColour")]
        public List<Color> hairColours = new List<Color>();
        public List<Color> stubbleColours = new List<Color>();

        [Header("BodyPaint")]
        public List<Color> paintColours = new List<Color>();

        [Header("ActivePieces")]
        public List<GameObject> currentlyActivePeices = new List<GameObject>();

        [Header("MaterialRefrence")]
        public Material reffenceMaterial = null;

        [HideInInspector] public bool isMale;
        [HideInInspector] public BodyPartChanger bodyPartChanger;

        private void Awake()
        {
            bodyPartChanger = FindObjectOfType<BodyPartChanger>();
        }
        private void Start()
        {
            GetAllBodyParts();
            UpdateCustomMaterial(transform);
            EnableDefaultMale();
            bodyPartChanger.SetSliderMaxValues();
            bodyPartChanger.ChangeHair();
            bodyPartChanger.ChangePaint();
            bodyPartChanger.ChangeRace();
        }
        public void EnableDefaultMale()
        {
            isMale = true;
            DisableBodyParts(transform);
            EnableMaleBodyParts();
            UpdateActivePieces(transform,true);

        }
        public void EnableDefaultFemale()
        {
            isMale = false;
            DisableBodyParts(transform);
            EnableFemaleBodyParts();
            UpdateActivePieces(transform,true);
        }
        public void UpdateActivePieces(Transform parent, bool firstCall)
        {
            if (firstCall) currentlyActivePeices.Clear();
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts) && child.gameObject.activeInHierarchy)
                {
                    currentlyActivePeices.Add(child.gameObject);
                }

                // Recursively call the method for each child
                UpdateActivePieces(child, false);
            }
        }
        public void UpdateCustomMaterial(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Material instanceMaterial = Instantiate(reffenceMaterial);
                    child.gameObject.GetComponent<Renderer>().material = instanceMaterial;
                }

                // Recursively call the method for each child
                UpdateCustomMaterial(child);
            }
        }
        private void GetAllBodyParts()
        {
            //Gender Specific BodyPiece Getter Functions
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.Head, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleHeads, femaleHeads, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.Torso, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleTorsos, femaleTorso, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.Eyebrows, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleBrows, femaleBrows, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.ArmUpperRight, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleArmsUpperRight, femaleArmsUpperRight, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.ArmLowerRight, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleArmsLowerRight, femaleArmsLowerRight, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.ArmUpperLeft, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleArmsUpperLeft, femaleArmsUpperLeft, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.ArmLowerLeft, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleArmsLowerLeft, femaleArmsLowerLeft, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.HandLeft, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleHandsLeft, femaleHandsLeft, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.HandRight, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleHandsRight, femaleHandsRight, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.Hips, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleHips, femaleHips, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.LegRight, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleLegRight, femaleLegRight, transform);
            GetGenderedBodyPieces(BodyPartCollection.BodyPieceType.LegLeft, BodyPartCollection.CharacterGender.Male, BodyPartCollection.CharacterGender.Female, maleLegLeft, femaleLegLeft, transform);
            //Non-Gender Specific BodyPiece Getter Functions
            GetNonGenderedBodyPieces(BodyPartCollection.BodyPieceType.Hairstyle, BodyPartCollection.CharacterGender.Both, hairstyles, transform);
            GetNonGenderedBodyPieces(BodyPartCollection.BodyPieceType.FacialHair, BodyPartCollection.CharacterGender.Male, maleFacialHair, transform);
            GetNonGenderedBodyPieces(BodyPartCollection.BodyPieceType.Ears, BodyPartCollection.CharacterGender.Both, ears, transform);
        }
        //Non-Gender specific function
        private void GetGenderedBodyPieces(BodyPartCollection.BodyPieceType bodyPieceType, BodyPartCollection.CharacterGender male, BodyPartCollection.CharacterGender female, List<GameObject> listToAddA, List<GameObject> listToAddB, Transform parent)
        {
            foreach (Transform child in parent)
            {
                BodyPartCollection bodyPartCollection = child.GetComponent<BodyPartCollection>();
                if (bodyPartCollection != null &&
                    bodyPartCollection.bodyPieceType == bodyPieceType &&
                    bodyPartCollection.gender == male)
                {
                    listToAddA.Add(child.gameObject);
                }
                if (bodyPartCollection != null &&
                    bodyPartCollection.bodyPieceType == bodyPieceType &&
                    bodyPartCollection.gender == female)
                {
                    listToAddB.Add(child.gameObject);
                }

                GetGenderedBodyPieces(bodyPieceType,male,female,listToAddA,listToAddB,child);
            }
        }
        //Gender specific function
        private void GetNonGenderedBodyPieces(BodyPartCollection.BodyPieceType bodyPieceType, BodyPartCollection.CharacterGender gender, List<GameObject> listToAdd, Transform parent)
        {
            foreach (Transform child in parent)
            {
                BodyPartCollection bodyPartCollection = child.GetComponent<BodyPartCollection>();
                if (bodyPartCollection != null &&
                    bodyPartCollection.bodyPieceType == bodyPieceType &&
                    bodyPartCollection.gender == gender)
                {
                    listToAdd.Add(child.gameObject);
                }

                GetNonGenderedBodyPieces(bodyPieceType, gender, listToAdd, child);
            }
        }
        private void EnableMaleBodyParts()
        {
            maleHeads[0].gameObject.SetActive(true);
            maleBrows[0].gameObject.SetActive(true);
            maleFacialHair[0].gameObject.SetActive(true);
            maleTorsos[0].gameObject.SetActive(true);
            maleArmsUpperRight[0].gameObject.SetActive(true);
            maleArmsLowerRight[0].gameObject.SetActive(true);
            maleArmsUpperLeft[0].gameObject.SetActive(true);
            maleArmsLowerLeft[0].gameObject.SetActive(true);
            maleHandsRight[0].gameObject.SetActive(true);
            maleHandsLeft[0].gameObject.SetActive(true);
            maleHips[0].gameObject.SetActive(true);
            maleLegLeft[0].gameObject.SetActive(true);
            maleLegRight[0].gameObject.SetActive(true);
            hairstyles[2].gameObject.SetActive(true);
            ears[0].gameObject.SetActive(true);
        }
        private void EnableFemaleBodyParts()
        {
            femaleHeads[0].gameObject.SetActive(true);
            femaleBrows[0].gameObject.SetActive(true);
            femaleTorso[0].gameObject.SetActive(true);
            femaleArmsUpperRight[0].gameObject.SetActive(true);
            femaleArmsLowerRight[0].gameObject.SetActive(true);
            femaleArmsUpperLeft[0].gameObject.SetActive(true);
            femaleArmsLowerLeft[0].gameObject.SetActive(true);
            femaleHandsRight[0].gameObject.SetActive(true);
            femaleHandsLeft[0].gameObject.SetActive(true);
            femaleHips[0].gameObject.SetActive(true);
            femaleLegRight[0].gameObject.SetActive(true);
            femaleLegLeft[0].gameObject.SetActive(true);
            hairstyles[0].gameObject.SetActive(true);
            ears[0].gameObject.SetActive(true);

        }
        private void DisableBodyParts(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null && child.gameObject.activeInHierarchy)
                {
                    child.gameObject.SetActive(false);
                }

                // Recursively call the method for each child
                DisableBodyParts(child);
            }
        }
    }

}