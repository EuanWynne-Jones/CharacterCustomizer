using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterCustomizer.Core
{
    public class BodyPartChanger : MonoBehaviour
    {
        public Slider raceSlider = null;
        public Slider genderSlider = null;
        public Slider faceSlider = null;
        public Slider hairstyleSlider = null;
        public Slider facialHairSlider = null;
        public Slider eyebrowsSlider = null;

        private DefaultBodyPartSetup setup;

        private void Awake()
        {
            setup = FindObjectOfType<DefaultBodyPartSetup>();
        }

        public void ChangeRace(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Renderer renderer = child.gameObject.GetComponent<Renderer>();
                    Material material = renderer.material;


                    material.SetColor("_Colour_Skin", setup.raceSkinColours[((int)raceSlider.value)]);
                    renderer.material = material;
                }

                // Recursively call the method for each child
                ChangeRace(child);
            }
        }
        public void ChangeGender()
        {
            if(genderSlider.value == 0)
            {
                setup.EnableDefaultMale();
                facialHairSlider.gameObject.SetActive(true);
                ChangeHairstyle();
                ChangeFace();
                eyebrowsSlider.maxValue = 9f;
            }
            else
            {
                facialHairSlider.gameObject.SetActive(false);
                setup.EnableDefaultFemale();
                ChangeHairstyle();
                ChangeFace();
                eyebrowsSlider.maxValue = 6f;

            }
        }
        public void ChangeHairstyle()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if(activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hairstyle)
                {
                    activePiece.SetActive(false);
                }
            }
            setup.hairstyles[((int)hairstyleSlider.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform,true);
        }
        public void ChangeFacialHair()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.FacialHair)
                {
                    activePiece.SetActive(false);
                }
            }
            setup.maleFacialHair[((int)facialHairSlider.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform, true);
        }
        public void ChangeFace()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head)
                {
                    activePiece.SetActive(false);
                }
            }
            if (setup.isMale == true)
            {
                setup.maleHeads[((int)faceSlider.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleHeads[((int)faceSlider.value)].gameObject.SetActive(true);
            }
            setup.UpdateActivePieces(setup.transform, true);
        }
        public void ChangeEyebrows()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows)
                {
                    activePiece.SetActive(false);
                }
            }
            if (setup.isMale == true)
            {

                setup.maleBrows[((int)eyebrowsSlider.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleBrows[((int)eyebrowsSlider.value)].gameObject.SetActive(true);
            }
            setup.UpdateActivePieces(setup.transform, true);
        }
    }
}
