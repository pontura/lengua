using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<InteractiveObject> OnCharacterHitInteractiveObject = delegate { };
	public static System.Action<InteractiveObject, Vector3> OnCharacterWalkToInteractiveObject = delegate { };
	public static System.Action<InteractiveObject> OnCharacterReachInteractiveObject = delegate { };
	public static System.Action<Vector3> OnFloorClicked = delegate { };
	public static System.Action OnCharacterStopWalking = delegate {	};
	public static System.Action<string, int> OnSaveNewData = delegate {	};
	public static System.Action<string> OnTip = delegate {	};
	public static System.Action OnInteractiveTextsLoaded = delegate {	};
	public static System.Action<string, string, System.Action> OnTexts = delegate {	};
	public static System.Action<List<DialoguesData.Dialogue>, System.Action> OnDialogue = delegate {	};
	public static System.Action<string> OpenTrivia = delegate {	};
	public static System.Action<Inventary.Item> AddToInventary = delegate {	};
	public static System.Action<Room.types, Vector2> ChangeRoom = delegate {	};
	public static System.Action<Room> OnEnterNewRoom = delegate {	};
	public static System.Action<Vector3> ForceCharacterPosition = delegate {	};
	public static System.Action<string> RemoveFromInventary = delegate {	};
	public static System.Action<string> InventoryButtonClicked = delegate {	};
	public static System.Action OnRefreshInventary = delegate {	};
	public static System.Action<string> UseItem = delegate {	};

	public static System.Action<string> SetTrivia = delegate {	};
	public static System.Action<int> NormativaDone = delegate {	};
	public static System.Action OnBookComplete = delegate {	};
	public static System.Action OnTriviaWrong = delegate {	};
	public static System.Action TriviaClose = delegate {	};
	public static System.Action<Cutscenes.types> OnCutscene = delegate {	};

	public static System.Action ClickSfx = delegate {	};
	public static System.Action OpenBagSfx = delegate {	};
	public static System.Action CloseBagSfx = delegate {	};
	public static System.Action OpenBookSfx = delegate {};
	public static System.Action CloseBookSfx = delegate {};
	public static System.Action CorrectoSfx = delegate {};
	public static System.Action IncorrectoSfx = delegate {};

	public static System.Action OnCuadernoWin = delegate {};

	public static System.Action NextMusicTrack = delegate {};
	public static System.Action StopMusic = delegate {};
	public static System.Action<bool> CutsceneMusic = delegate {};
	public static System.Action<bool> PhoneMusic = delegate {};

	public static System.Action<string,string,string,long> LogEvent = delegate {};
	public static System.Action<bool> ShowCredits = delegate {};
}

