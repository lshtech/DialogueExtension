using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Locations;

namespace SDV.Shared.Abstractions
{
  public class NPCWrapper : CharacterWrapper, INPCWrapper, IWrappedType<NPC>
  {
    public NPCWrapper(Character character) : base(character)
    {
    }

    public Dictionary<int, SchedulePathDescription> Schedule { get; set; }
    public Dictionary<string, string> Dialogue { get; }
    public SchedulePathDescription DirectionsToNewLocation { get; set; }
    public int DirectionIndex { get; set; }
    public Texture2D Portrait { get; set; }
    public bool IsWalkingInSquare { get; set; }
    public bool IsWalkingTowardPlayer { get; set; }
    public string Birthday_Season { get; set; }
    public int Birthday_Day { get; set; }
    public int Age { get; set; }
    public int Manners { get; set; }
    public int SocialAnxiety { get; set; }
    public int Optimism { get; set; }
    public int Gender { get; set; }
    public bool Breather { get; set; }
    public bool HideShadow { get; set; }
    public bool IsInvisible { get; set; }
    public int DefaultFacingDirection { get; set; }
    public Vector2 DefaultPosition { get; set; }
    public string DefaultMap { get; set; }
    public Stack<Dialogue> CurrentDialogue { get; set; }
    public bool HasPartnerForDance { get; }
    public bool CanSocialize { get; }

    public void reloadData()
    {
    }

    public void reloadDefaultLocation()
    {
    }

    public bool canTalk() => false;

    public string getName() => null;

    public string getTextureName() => null;

    public bool PathToOnFarm(Point destination, PathFindController.endBehavior on_path_success = null) => false;

    public void OnFinishPathForActivity(Character c, GameLocation location)
    {
    }

    public void resetPortrait()
    {
    }

    public void resetSeasonalDialogue()
    {
    }

    public void reloadSprite()
    {
    }

    public void showTextAboveHead(string Text, int spriteTextColor = -1, int style = 2, int duration = 3000,
      int preTimer = 0)
    {
    }

    public void moveToNewPlaceForEvent(int xTile, int yTile, string oldMap)
    {
    }

    public bool hitWithTool(Tool t) => false;

    public bool canReceiveThisItemAsGift(Item i) => false;

    public int getGiftTasteForThisItem(Item item) => 0;

    public bool CheckTasteContextTags(Item item, string[] list) => false;

    public void tryToReceiveActiveObject(Farmer who)
    {
    }

    public string GetDispositionModifiedString(string path, params object[] substitutions) => null;

    public void haltMe(Farmer who)
    {
    }

    public bool checkAction(Farmer who, GameLocation l) => false;

    public void grantConversationFriendship(Farmer who, int amount = 20)
    {
    }

    public void AskLeoMemoryPrompt()
    {
    }

    public bool CanRevisitLeoMemory(KeyValuePair<string, int>? event_data) => false;

    public KeyValuePair<string, int>? GetUnseenLeoEvent() => null;

    public void OnLeoMemoryResponse(Farmer who, string whichAnswer)
    {
    }

    public bool isDivorcedFrom(Farmer who) => false;

    public GameLocation getHome() => null;

    public void behaviorOnFarmerPushing()
    {
    }

    public void behaviorOnFarmerLocationEntry(GameLocation location, Farmer who)
    {
    }

    public void behaviorOnLocalFarmerLocationEntry(GameLocation location)
    {
    }

    public void facePlayer(Farmer who)
    {
    }

    public void doneFacingPlayer(Farmer who)
    {
    }

    public void UpdateFarmExploration(GameTime time, GameLocation location)
    {
    }

    public void InitializeFarmActivities()
    {
    }

    public bool FindFarmActivity() => false;

    public void wearIslandAttire()
    {
    }

    public void wearNormalClothes()
    {
    }

    public void performTenMinuteUpdate(int timeOfDay, GameLocation l)
    {
    }

    public void sayHiTo(Character c)
    {
    }

    public string getHi(string nameToGreet) => null;

    public bool isFacingToward(Vector2 tileLocation) => false;

    public void arriveAt(GameLocation l)
    {
    }

    public void addExtraDialogues(string dialogues)
    {
    }

    public void PerformDivorce()
    {
    }

    public string tryToGetMarriageSpecificDialogueElseReturnDefault(string dialogueKey, string defaultMessage = "") =>
      null;

    public void resetCurrentDialogue()
    {
    }

    public bool checkForNewCurrentDialogue(int heartLevel, bool noPreface = false) => false;

    public Dialogue tryToRetrieveDialogue(string preface, int heartLevel, string appendToEnd = "") => null;

    public void clearSchedule()
    {
    }

    public void checkSchedule(int timeOfDay)
    {
    }

    public void checkForMarriageDialogue(int timeOfDay, GameLocation location)
    {
    }

    public bool isOnSilentTemporaryMessage() => false;

    public bool hasTemporaryMessageAvailable() => false;

    public bool setTemporaryMessages(Farmer who) => false;

    public void playSleepingAnimation()
    {
    }

    public bool IsReturningToEndPoint() => false;

    public void StartActivityWalkInSquare(int square_width, int square_height, int pause_offset)
    {
    }

    public void EndActivityRouteEndBehavior()
    {
    }

    public void StartActivityRouteEndBehavior(string behavior_name, string end_message)
    {
    }

    public void warp(bool wasOutdoors)
    {
    }

    public void shake(int duration)
    {
    }

    public void setNewDialogue(string s, bool add = false, bool clearOnMovement = false)
    {
    }

    public void setNewDialogue(string dialogueSheetName, string dialogueSheetKey, int numberToAppend = -1,
      bool add = false,
      bool clearOnMovement = false)
    {
    }

    public string GetDialogueSheetName() => null;

    public void setSpouseRoomMarriageDialogue()
    {
    }

    public void setRandomAfternoonMarriageDialogue(int time, GameLocation location, bool countAsDailyAfternoon = false)
    {
    }

    public bool isBirthday(string season, int day) => false;

    public object getFavoriteItem() => null;

    public void receiveGift(object o, Farmer giver, bool updateGiftLimitInfo = true,
      float friendshipChangeMultiplier = 1,
      bool showResponse = true)
    {
    }

    public bool NeedsBirdieEmoteHack() => false;

    public void warpToPathControllerDestination()
    {
    }

    public Rectangle getMugShotSourceRect() => default;

    public void getHitByPlayer(Farmer who, GameLocation location)
    {
    }

    public void walkInSquare(int squareWidth, int squareHeight, int squarePauseOffset)
    {
    }

    public void moveTowardPlayer(int threshold)
    {
    }

    public bool withinPlayerThreshold() => false;

    public bool withinPlayerThreshold(int threshold) => false;

    public Dictionary<int, SchedulePathDescription> parseMasterSchedule(string rawData) => null;

    public Dictionary<int, SchedulePathDescription> getSchedule(int dayOfMonth) => null;

    public void handleMasterScheduleFileLoadError(Exception e)
    {
    }

    public void InvalidateMasterSchedule()
    {
    }

    public Dictionary<string, string> getMasterScheduleRawData() => null;

    public string getMasterScheduleEntry(string schedule_key) => null;

    public bool hasMasterScheduleEntry(string key) => false;

    public bool isRoommate() => false;

    public bool isMarried() => false;

    public bool isMarriedOrEngaged() => false;

    public void dayUpdate(int dayOfMonth)
    {
    }

    public void resetForNewDay(int dayOfMonth)
    {
    }

    public void returnHomeFromFarmPosition(Farm farm)
    {
    }

    public Vector2 GetSpousePatioPosition() => default;

    public void setUpForOutdoorPatioActivity()
    {
    }

    public bool isGaySpouse() => false;

    public bool canGetPregnant() => false;

    public void marriageDuties()
    {
    }

    public void popOffAnyNonEssentialItems()
    {
    }

    public void addMarriageDialogue(string dialogue_file, string dialogue_key, bool gendered = false,
      params string[] substitutions)
    {
    }

    public void clearTextAboveHead()
    {
    }

    public bool isVillager() => false;

    public void arriveAtFarmHouse(FarmHouse farmHouse)
    {
    }

    public Farmer getSpouse() => null;

    public string getTermOfSpousalEndearment(bool happy = true) => null;

    public bool spouseObstacleCheck(MarriageDialogueReference backToBedMessage, GameLocation currentLocation,
      bool force = false) => false;

    public void setTilePosition(Point p)
    {
    }

    public void setTilePosition(int x, int y)
    {
    }

    public void ReachedEndPoint()
    {
    }

    public void changeSchedulePathDirection()
    {
    }

    public void moveCharacterOnSchedulePath()
    {
    }

    public void randomSquareMovement(GameTime time)
    {
    }

    public void returnToEndPoint()
    {
    }

    public void SetMovingOnlyUp()
    {
    }

    public void SetMovingOnlyRight()
    {
    }

    public void SetMovingOnlyDown()
    {
    }

    public void SetMovingOnlyLeft()
    {
    }

    public int CompareTo(object obj) => 0;

    public void Removed()
    {
    }

    public NPC GetBaseType { get; }
  }
}