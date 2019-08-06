using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Talker : MonoBehaviour {

    AudioSource audioSource;
    public GameObject soundListener;

    [Header("GUI")]
    public Font font;

    /// <summary>
    /// The text gui that the text will be written on
    /// </summary>
    public Text textGUI;
    /// <summary>
    /// Gui that displays page information
    /// </summary>
	public Text pageNumberGUI;
    /// <summary>
    /// Gui that displays text when the script is waiting for player input
    /// </summary>
	public Text nextPagePromptGUI;

    [Space(20)]
	public string nextPagePromptText;
    public KeyCode textPageKey;

    [Space(20)]
    [Header("Sound Settings")]
	public AudioClip[] letters;
    public AudioClip[] letterSounds { get; set; }

    public float letterTime = 1f;
    [Space(20)]
    public bool useLetterSounds = true;
	public bool canChangeSpeed = true;
	public bool useSounds = true;
	public bool useRandomPitch = false;

    [Space(20)]
	[Range(0, 10f)]
	public float basePitch = 1.5f;
	[Range(0f, 3f)]
	public float pitchShift = 0.5f;
    
    // There is no support for this to be false.
    // When false, you'll need to call it from another script, or change this script.
	public bool speakAtInstantiation = true; 

    [Space(20)]
    [Header("Text")]
    public string[] sentences;
	
	float time;

	bool isWriting = false;
	bool isPrompted = false;
    bool nextPagePrompt = false;

    void Start() {

        letterSounds = letters;
        audioSource = gameObject.GetComponent<AudioSource>();

        if(speakAtInstantiation)
            StartCoroutine(PrintSentences(sentences));
    }

    public IEnumerator PrintSentences(string[] sentences)
    {
        isPrompted = true;

        for (int i = 0; i < sentences.Length; i++)
        {

            // Write page number.
            pageNumberGUI.text = (i + 1) + " / " + sentences.Length;

            while(nextPagePrompt)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nextPagePrompt = false;

                    // Remove page prompt text.
                    nextPagePromptGUI.text = "";
                }

                yield return null;
            }

            yield return StartCoroutine(PrintText(sentences[i]));

            if (i < sentences.Length -1)
            {
                nextPagePrompt = true;

                if (nextPagePromptGUI != null)
                    nextPagePromptGUI.text = nextPagePromptText;
            }
        }
    }

	protected IEnumerator PrintText(string text) {

        textGUI.text = string.Empty;
        isWriting = true;

        // Go through all letters of the text.
		for (int i = 0; i < text.Length; i++) {

            time = letterTime;

            // Cancel text if user isn't prompted.
            if (!isPrompted) {
				isWriting = false;
				break;
			}

            // Insert current letter. 
            textGUI.text = textGUI.text.Insert(i, char.ToString(text[i]));

            // set the pitch of the letter based on settings.
			if(useRandomPitch)
				audioSource.pitch = Random.Range(basePitch - (pitchShift / 2), basePitch + (pitchShift / 2));
			else
				audioSource.pitch = basePitch;
			
			if (useLetterSounds && letterSounds != null) {

                // If all letter sounds excists
				if (letterSounds.Length >= 26) {				
                    int audioID = GetLetterSound(text[i].ToString());

                    audioSource.clip = (audioID <= 25) ? letterSounds[audioID] : letterSounds[0];

                } else
					Debug.LogError("In order to use letter sounds, you need 26 sounds, one sound for each letter of the alphabet.");
				
			} else { // If unique letter sounds aren't used

                if (letterSounds[0] != null) {
					if(audioSource.clip != letterSounds[0])
						audioSource.clip = letterSounds[0];
				} else {
					Debug.LogError("Cannot play sounds because lettersounds[0] is null.");
				}

			}

            // Play sound
			audioSource.Play ();

            // Speed up text if holding space key.
            if(Input.GetKey(KeyCode.Space))
                time /= 2;

            // don't wait for spaces
			if (text [i].ToString () != " ") {
                // Speed up text at dots.
				if(text[i].ToString() == ".")
					time /= 2;

                // Have a pause between letters.
				yield return new WaitForSeconds (time * 0.1f);
			}

		}

		isWriting = false;
	}

    /// <summary>
    /// Get ID of letter. returns 26 if letter is not defined (punctuations, numbers etc.)
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
	int GetLetterSound(string letter) {

		letter = letter.ToLower();

        switch(letter)
        {
            case "a":
                return 0;
            case "b":
                return 1;
            case "c":
                return 2;
            case "d":
                return 3;
            case "e":
                return 4;
            case "f":
                return 5;
            case "g":
                return 6;
            case "h":
                return 7;
            case "i":
                return 8;
            case "j":
                return 9;
            case "k":
                return 10;
            case "l":
                return 11;
            case "m":
                return 12;
            case "n":
                return 13;
            case "o":
                return 14;
            case "p":
                return 15;
            case "q":
                return 16;
            case "r":
                return 17;
            case "s":
                return 18;
            case "t":
                return 19;
            case "u":
                return 20;
            case "v":
                return 21;
            case "w":
                return 22;
            case "x":
                return 23;
            case "y":
                return 24;
            case "z":
                return 25;
            default:
                return 26;
        }

	}

}
