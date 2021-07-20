using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Locations;

namespace SDV.Shared.Abstractions
{
  public interface INPCWrapper : ICharacterWrapper, IWrappedType<NPC>
  {
    new NPC GetBaseType { get; }
    Dictionary<int, SchedulePathDescription> Schedule { get; set; }
    Dictionary<string, string> Dialogue { get; }
    SchedulePathDescription DirectionsToNewLocation { get; set; }
    int DirectionIndex { get; set; }
    Texture2D Portrait { get; set; }
    bool IsWalkingInSquare { get; set; }
    bool IsWalkingTowardPlayer { get; set; }
    string Birthday_Season { get; set; }
    int Birthday_Day { get; set; }
    int Age { get; set; }
    int Manners { get; set; }
    int SocialAnxiety { get; set; }
    int Optimism { get; set; }
    int Gender { get; set; }
    bool Breather { get; set; }
    bool HideShadow { get; set; }
    bool IsInvisible { get; set; }
    int DefaultFacingDirection { get; set; }
    Vector2 DefaultPosition { get; set; }
    string DefaultMap { get; set; }
    Stack<Dialogue> CurrentDialogue { get; set; }
    bool HasPartnerForDance { get; }
    bool CanSocialize { get; }
    void reloadData();
    void reloadDefaultLocation();
    bool canTalk();
    string getName();
    string getTextureName();

    bool PathToOnFarm(
      Point destination,
      PathFindController.endBehavior on_path_success = null);

    void OnFinishPathForActivity(Character c, GameLocation location);
    void resetPortrait();
    void resetSeasonalDialogue();
    void reloadSprite();

    void showTextAboveHead(
      string Text,
      int spriteTextColor = -1,
      int style = 2,
      int duration = 3000,
      int preTimer = 0);

    void moveToNewPlaceForEvent(int xTile, int yTile, string oldMap);
    bool hitWithTool(Tool t);
    bool canReceiveThisItemAsGift(Item i);
    int getGiftTasteForThisItem(Item item);
    bool CheckTasteContextTags(Item item, string[] list);
    void tryToReceiveActiveObject(Farmer who);
    string GetDispositionModifiedString(string path, params object[] substitutions);
    void haltMe(Farmer who);
    bool checkAction(Farmer who, GameLocation l);
    void grantConversationFriendship(Farmer who, int amount = 20);
    void AskLeoMemoryPrompt();
    bool CanRevisitLeoMemory(KeyValuePair<string, int>? event_data);
    KeyValuePair<string, int>? GetUnseenLeoEvent();
    void OnLeoMemoryResponse(Farmer who, string whichAnswer);
    bool isDivorcedFrom(Farmer who);


    GameLocation getHome();
    void behaviorOnFarmerPushing();
    void behaviorOnFarmerLocationEntry(GameLocation location, Farmer who);
    void behaviorOnLocalFarmerLocationEntry(GameLocation location);
    void facePlayer(Farmer who);
    void doneFacingPlayer(Farmer who);
    void UpdateFarmExploration(GameTime time, GameLocation location);
    void InitializeFarmActivities();
    bool FindFarmActivity();
    void wearIslandAttire();
    void wearNormalClothes();
    void performTenMinuteUpdate(int timeOfDay, GameLocation l);
    void sayHiTo(Character c);
    string getHi(string nameToGreet);
    bool isFacingToward(Vector2 tileLocation);
    void arriveAt(GameLocation l);
    void addExtraDialogues(string dialogues);
    void PerformDivorce();

    string tryToGetMarriageSpecificDialogueElseReturnDefault(
      string dialogueKey,
      string defaultMessage = "");

    void resetCurrentDialogue();
    bool checkForNewCurrentDialogue(int heartLevel, bool noPreface = false);

    Dialogue tryToRetrieveDialogue(
      string preface,
      int heartLevel,
      string appendToEnd = "");

    void clearSchedule();
    void checkSchedule(int timeOfDay);
    void checkForMarriageDialogue(int timeOfDay, GameLocation location);
    bool isOnSilentTemporaryMessage();
    bool hasTemporaryMessageAvailable();
    bool setTemporaryMessages(Farmer who);
    void playSleepingAnimation();
    bool IsReturningToEndPoint();
    void StartActivityWalkInSquare(int square_width, int square_height, int pause_offset);
    void EndActivityRouteEndBehavior();
    void StartActivityRouteEndBehavior(string behavior_name, string end_message);
    void warp(bool wasOutdoors);
    void shake(int duration);
    void setNewDialogue(string s, bool add = false, bool clearOnMovement = false);

    void setNewDialogue(
      string dialogueSheetName,
      string dialogueSheetKey,
      int numberToAppend = -1,
      bool add = false,
      bool clearOnMovement = false);

    string GetDialogueSheetName();
    void setSpouseRoomMarriageDialogue();

    void setRandomAfternoonMarriageDialogue(
      int time,
      GameLocation location,
      bool countAsDailyAfternoon = false);

    bool isBirthday(string season, int day);
    object getFavoriteItem();

    void receiveGift(
      object o,
      Farmer giver,
      bool updateGiftLimitInfo = true,
      float friendshipChangeMultiplier = 1f,
      bool showResponse = true);

    bool NeedsBirdieEmoteHack();
    void warpToPathControllerDestination();
    Rectangle getMugShotSourceRect();
    void getHitByPlayer(Farmer who, GameLocation location);
    void walkInSquare(int squareWidth, int squareHeight, int squarePauseOffset);
    void moveTowardPlayer(int threshold);
    bool withinPlayerThreshold();
    bool withinPlayerThreshold(int threshold);

    Dictionary<int, SchedulePathDescription> parseMasterSchedule(
      string rawData);

    Dictionary<int, SchedulePathDescription> getSchedule(
      int dayOfMonth);

    void handleMasterScheduleFileLoadError(Exception e);
    void InvalidateMasterSchedule();
    Dictionary<string, string> getMasterScheduleRawData();
    string getMasterScheduleEntry(string schedule_key);
    bool hasMasterScheduleEntry(string key);
    bool isRoommate();
    bool isMarried();
    bool isMarriedOrEngaged();
    void dayUpdate(int dayOfMonth);
    void resetForNewDay(int dayOfMonth);
    void returnHomeFromFarmPosition(Farm farm);
    Vector2 GetSpousePatioPosition();
    void setUpForOutdoorPatioActivity();
    bool isGaySpouse();
    bool canGetPregnant();
    void marriageDuties();
    void popOffAnyNonEssentialItems();

    void addMarriageDialogue(
      string dialogue_file,
      string dialogue_key,
      bool gendered = false,
      params string[] substitutions);

    void clearTextAboveHead();
    bool isVillager();
    void arriveAtFarmHouse(FarmHouse farmHouse);
    Farmer getSpouse();
    string getTermOfSpousalEndearment(bool happy = true);

    bool spouseObstacleCheck(
      MarriageDialogueReference backToBedMessage,
      GameLocation currentLocation,
      bool force = false);

    void setTilePosition(Point p);
    void setTilePosition(int x, int y);
    void ReachedEndPoint();
    void changeSchedulePathDirection();
    void moveCharacterOnSchedulePath();
    void randomSquareMovement(GameTime time);
    void returnToEndPoint();
    void SetMovingOnlyUp();
    void SetMovingOnlyRight();
    void SetMovingOnlyDown();
    void SetMovingOnlyLeft();
    int CompareTo(object obj);
    void Removed();
  }
}