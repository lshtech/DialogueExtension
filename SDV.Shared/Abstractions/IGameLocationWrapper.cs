using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Monsters;
using StardewValley.Network;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using xTile;
using xTile.Dimensions;
using Object = System.Object;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SDV.Shared.Abstractions
{
  public interface IGameLocationWrapper : IWrappedType<GameLocation>
  {
    Map Map { get; set; }
    OverlaidDictionary Objects { get; }
    List<TemporaryAnimatedSprite> TemporarySprites { get; }
    string Name { get; }
    float LightLevel { get; set; }
    bool IsFarm { get; set; }
    bool IsOutdoors { get; set; }
    bool IsGreenhouse { get; set; }
    NetFields NetFields { get; }
    NetRoot<GameLocation> Root { get; }
    string NameOrUniqueName { get; }
    ModDataDictionary modDataForSerialization { get; set; }
    bool SeedsIgnoreSeasonsHere();
    bool CanPlantSeedsHere(int crop_index, int tile_x, int tile_y);
    bool CanPlantTreesHere(int sapling_index, int tile_x, int tile_y);

    void InvalidateCachedMultiplayerMap(
      Dictionary<string, CachedMultiplayerMap> cached_data);

    void MakeMapModifications(bool force = false);

    bool ApplyCachedMultiplayerMap(
      Dictionary<string, CachedMultiplayerMap> cached_data,
      string requested_map_path);

    void StoreCachedMultiplayerMap(
      Dictionary<string, CachedMultiplayerMap> cached_data);

    void TransferDataFromSavedLocation(GameLocation l);
    void OnTerrainFeatureAdded(TerrainFeature feature, Vector2 location);
    void OnTerrainFeatureRemoved(TerrainFeature feature);
    void UpdateTerrainFeatureUpdateSubscription(TerrainFeature feature);
    string GetSeasonForLocation();
    bool isTemp();
    void playSound(string audioName, NetAudio.SoundContext soundContext = NetAudio.SoundContext.Default);

    void playSoundPitched(string audioName, int pitch,
      NetAudio.SoundContext soundContext = NetAudio.SoundContext.Default);

    void playSoundAt(string audioName, Vector2 position,
      NetAudio.SoundContext soundContext = NetAudio.SoundContext.Default);

    void localSound(string audioName);
    void localSoundAt(string audioName, Vector2 position);

    void ApplyMapOverride(
      Map override_map,
      string override_key,
      Rectangle? source_rect = null,
      Rectangle? dest_rect = null);

    void ApplyMapOverride(
      string map_name,
      Rectangle? source_rect = null,
      Rectangle? destination_rect = null);

    void ApplyMapOverride(
      string map_name,
      string override_key_name,
      Rectangle? source_rect = null,
      Rectangle? destination_rect = null);

    bool RunLocationSpecificEventCommand(
      Event current_event,
      string command_string,
      bool first_run,
      params string[] args);

    void UpdateMapSeats();
    void loadMap(string mapPath, bool force_reload = false);
    void reloadMap();
    bool canSlimeMateHere();
    bool canSlimeHatchHere();
    void addCharacter(NPC character);
    NetCollection<NPC> getCharacters();
    Warp isCollidingWithWarp(Rectangle position, Character character);
    Warp isCollidingWithWarpOrDoor(Rectangle position, Character character = null);
    Warp isCollidingWithDoors(Rectangle position, Character character = null);
    Warp getWarpFromDoor(Point door, Character character = null);

    void addResourceClumpAndRemoveUnderlyingTerrain(
      int resourceClumpIndex,
      int width,
      int height,
      Vector2 tile);

    bool canFishHere();
    bool CanRefillWateringCanOnTile(int tileX, int tileY);
    bool isTileBuildingFishable(int tileX, int tileY);
    bool isTileFishable(int tileX, int tileY);
    bool isFarmerCollidingWithAnyCharacter();
    bool isCollidingPosition(Rectangle position, xTile.Dimensions.Rectangle viewport, bool isFarmer);
    bool isCollidingPosition(Rectangle position, xTile.Dimensions.Rectangle viewport, Character character);

    bool isCollidingPosition(
      Rectangle position,
      xTile.Dimensions.Rectangle viewport,
      bool isFarmer,
      int damagesFarmer,
      bool glider);

    bool isCollidingPosition(
      Rectangle position,
      xTile.Dimensions.Rectangle viewport,
      bool isFarmer,
      int damagesFarmer,
      bool glider,
      Character character);

    bool isCollidingPosition(
      Rectangle position,
      xTile.Dimensions.Rectangle viewport,
      bool isFarmer,
      int damagesFarmer,
      bool glider,
      Character character,
      bool pathfinding,
      bool projectile = false,
      bool ignoreCharacterRequirement = false);

    Furniture GetFurnitureAt(Vector2 tile_position);
    bool isTilePassable(Location tileLocation, xTile.Dimensions.Rectangle viewport);
    bool isTilePassable(Rectangle nextPosition, xTile.Dimensions.Rectangle viewport);
    bool isPointPassable(Location location, xTile.Dimensions.Rectangle viewport);
    bool isTileOnMap(Vector2 position);
    bool isTileOnMap(int x, int y);
    void busLeave();
    int numberOfObjectsWithName(string name);
    Point getWarpPointTo(string location, Character character = null);
    Point getWarpPointTarget(Point warpPointLocation, Character character = null);
    bool HasLocationOverrideDialogue(NPC character);
    string GetLocationOverrideDialogue(NPC character);
    void boardBus(Vector2 playerTileLocation);
    NPC doesPositionCollideWithCharacter(float x, float y);
    NPC doesPositionCollideWithCharacter(Rectangle r, bool ignoreMonsters = false);
    void switchOutNightTiles();
    void checkForMusic(GameTime time);
    NPC isCollidingWithCharacter(Rectangle box);
    void drawAboveAlwaysFrontLayer(SpriteBatch b);
    bool moveObject(int oldX, int oldY, int newX, int newY);
    void performTouchAction(string fullActionString, Vector2 playerStandingPosition);
    void updateMap();
    LargeTerrainFeature getLargeTerrainFeatureAt(int tileX, int tileY);
    void UpdateWhenCurrentLocation(GameTime time);
    void updateWater(GameTime time);
    NPC getCharacterFromName(string name);
    void updateEvenIfFarmerIsntHere(GameTime time, bool ignoreWasUpdatedFlush = false);
    Response[] createYesNoResponses();
    void createQuestionDialogue(string question, Response[] answerChoices, string dialogKey);

    void createQuestionDialogue(
      string question,
      Response[] answerChoices,
      GameLocation.afterQuestionBehavior afterDialogueBehavior,
      NPC speaker = null);

    void createQuestionDialogue(
      string question,
      Response[] answerChoices,
      string dialogKey,
      Object actionObject);

    void createQuestionDialogueWithCustomWidth(
      string question,
      Response[] answerChoices,
      string dialogKey);

    Point GetMapPropertyPosition(string key, int default_x, int default_y);
    void monsterDrop(Monster monster, int x, int y, Farmer who);
    bool HasUnlockedAreaSecretNotes(Farmer who);

    bool damageMonster(
      Rectangle areaOfEffect,
      int minDamage,
      int maxDamage,
      bool isBomb,
      Farmer who);

    bool damageMonster(
      Rectangle areaOfEffect,
      int minDamage,
      int maxDamage,
      bool isBomb,
      float knockBackModifier,
      int addedPrecision,
      float critChance,
      float critMultiplier,
      bool triggerMonsterInvincibleTimer,
      Farmer who);

    bool BlocksDamageLOS(int x, int y);
    void moveCharacters(GameTime time);
    void growWeedGrass(int iterations);
    void removeDamageDebris(Monster monster);
    void spawnWeeds(bool weedsOnly);
    bool addCharacterAtRandomLocation(NPC n);
    void OnMiniJukeboxAdded();
    void OnMiniJukeboxRemoved();
    void UpdateMiniJukebox();
    bool IsMiniJukeboxPlaying();
    void DayUpdate(int dayOfMonth);
    void addLightGlows();
    NPC isCharacterAtTile(Vector2 tileLocation);
    void ResetCharacterDialogues();
    string getMapProperty(string propertyName);
    void tryToAddCritters(bool onlyIfOnScreen = false);
    void addClouds(double chance, bool onlyIfOnScreen = false);
    void addOwl();
    void setFireplace(bool on, int tileLocationX, int tileLocationY, bool playSound = true);
    void addWoodpecker(double chance, bool onlyIfOnScreen = false);
    void addSquirrels(double chance, bool onlyIfOnScreen = false);
    void addBunnies(double chance, bool onlyIfOnScreen = false);
    void instantiateCrittersList();
    void addCritter(Critter c);
    void addButterflies(double chance, bool onlyIfOnScreen = false);
    void addBirdies(double chance, bool onlyIfOnScreen = false);
    void addJumperFrog(Vector2 tileLocation);
    void addFrog();
    void checkForSpecialCharacterIconAtThisTile(Vector2 tileLocation);
    bool isAreaClear(Rectangle area);

    void refurbishMapPortion(
      Rectangle areaToRefurbish,
      string refurbishedMapName,
      Point mapReaderStartPoint);

    Vector2 getRandomTile();
    void setUpLocationSpecificFlair();
    void hostSetup();
    bool HasFarmerWatchingBroadcastEventReturningHere();
    void resetForPlayerEntry();
    void SelectRandomMiniJukeboxTrack();
    LightSource getLightSource(int identifier);
    bool hasLightSource(int identifier);
    void removeLightSource(int identifier);
    void repositionLightSource(int identifier, Vector2 position);
    bool isTileOccupiedForPlacement(Vector2 tileLocation, Object toPlace = null);
    Farmer isTileOccupiedByFarmer(Vector2 tileLocation);

    bool isTileOccupied(
      Vector2 tileLocation,
      string characterToIgnore = "",
      bool ignoreAllCharacters = false);

    bool isTileOccupiedIgnoreFloors(Vector2 tileLocation, string characterToIgnore = "");
    bool isTileHoeDirt(Vector2 tileLocation);

    void playTerrainSound(
      Vector2 tileLocation,
      Character who = null,
      bool showTerrainDisturbAnimation = true);

    bool checkTileIndexAction(int tileIndex);
    bool checkAction(Location tileLocation, xTile.Dimensions.Rectangle viewport, Farmer who);
    bool CanFreePlaceFurniture();
    bool LowPriorityLeftClick(int x, int y, Farmer who);
    bool CanPlaceThisFurnitureHere(Furniture furniture);
    List<Rectangle> getWalls();
    bool leftClick(int x, int y, Farmer who);
    int getExtraMillisecondsPerInGameMinuteForThisLocation();
    bool isTileLocationTotallyClearAndPlaceable(int x, int y);
    bool isTileLocationTotallyClearAndPlaceable(Vector2 v);
    bool isTileLocationTotallyClearAndPlaceableIgnoreFloors(Vector2 v);
    void ActivateKitchen(NetRef<Chest> fridge);
    bool isTilePlaceable(Vector2 v, Item item = null);
    bool shouldShadowBeDrawnAboveBuildingsLayer(Vector2 p);
    void openDoor(Location tileLocation, bool playSound);
    void doStarpoint(string which);
    string FormatCompletionLine(Func<Farmer, float> check);

    string FormatCompletionLine(
      Func<Farmer, bool> check,
      string true_value,
      string false_value);

    void ShowQiCat();
    bool performAction(string action, Farmer who, Location tileLocation);
    void showPrairieKingMenu();

    Vector2 findNearestObject(
      Vector2 startingPoint,
      int objectIndex,
      bool bigCraftable);

    void lockedDoorWarp(string[] actionParams);
    void playElliottPiano(int key);
    void readNote(int which);
    void mailbox();
    void farmerFile();
    void openItemChest(Location location, int whichObject);
    void getWallDecorItem(Location location);
    bool openShopMenu(string which);
    bool isObjectAt(int x, int y);
    bool isObjectAtTile(int tileX, int tileY);
    Object getObjectAt(int x, int y);
    Object getObjectAtTile(int x, int y);
    bool saloon(Location tileLocation);
    bool carpenters(Location tileLocation);
    bool blacksmith(Location tileLocation);
    bool animalShop(Location tileLocation);
    void openChest(Location location, int debrisType, int numberOfChunks);
    void openChest(Location location, int[] debrisType, int numberOfChunks);
    string actionParamsToString(string[] actionparams);
    void removeTile(Location tileLocation, string layer);
    void removeTile(int x, int y, string layer);
    void characterTrampleTile(Vector2 tile);
    bool characterDestroyObjectWithinRectangle(Rectangle rect, bool showDestroyedObject);
    Object removeObject(Vector2 location, bool showDestroyedObject);
    void removeTileProperty(int tileX, int tileY, string layer, string key);
    void setTileProperty(int tileX, int tileY, string layer, string key, string value);
    void removeBatch(List<Vector2> locations);
    void setObjectAt(float x, float y, Object o);
    void cleanupBeforeSave();
    void cleanupForVacancy();
    void cleanupBeforePlayerExit();
    bool answerDialogueAction(string questionAndAnswer, string[] questionParams);
    bool answerDialogue(Response answer);
    void setObject(Vector2 v, Object o);
    bool catchOceanCrabPotFishFromThisSpot(int x, int y);
    float getExtraTrashChanceForCrabPot(int x, int y);
    void tryToBuyNewBackpack();
    void checkForMapChanges();
    void removeStumpOrBoulder(int tileX, int tileY, Object o);
    void destroyObject(Vector2 tileLocation, Farmer who);
    void destroyObject(Vector2 tileLocation, bool hardDestroy, Farmer who);
    GameLocation.LocationContext GetLocationContext();
    bool sinkDebris(Debris debris, Vector2 chunkTile, Vector2 chunkPosition);
    bool doesTileSinkDebris(int xTile, int yTile, Debris.DebrisType type);

    bool doesEitherTileOrTileIndexPropertyEqual(
      int xTile,
      int yTile,
      string propertyName,
      string layerName,
      string propertyValue);

    string doesTileHaveProperty(
      int xTile,
      int yTile,
      string propertyName,
      string layerName);

    string doesTileHavePropertyNoNull(
      int xTile,
      int yTile,
      string propertyName,
      string layerName);

    bool isWaterTile(int xTile, int yTile);
    bool isOpenWater(int xTile, int yTile);
    bool isCropAtTile(int tileX, int tileY);

    bool dropObject(
      Object obj,
      Vector2 dropLocation,
      xTile.Dimensions.Rectangle viewport,
      bool initialPlacement,
      Farmer who = null);

    bool dropObject(Object obj);

    void explode(
      Vector2 tileLocation,
      int radius,
      Farmer who,
      bool damageFarmers = true,
      int damage_amount = -1);

    void explosionAt(float x, float y);
    void removeTemporarySpritesWithID(int id);
    void removeTemporarySpritesWithID(float id);
    void removeTemporarySpritesWithIDLocal(float id);
    void makeHoeDirt(Vector2 tileLocation, bool ignoreChecks = false);
    int numberOfObjectsOfType(int index, bool bigCraftable);
    void passTimeForObjects(int timeElapsed);
    void performTenMinuteUpdate(int timeOfDay);
    void performOrePanTenMinuteUpdate(Random r);
    int getFishingLocation(Vector2 tile);
    bool IsUsingMagicBait(Farmer who);

    Object getFish(
      float millisecondsAfterNibble,
      int bait,
      int waterDepth,
      Farmer who,
      double baitPotency,
      Vector2 bobberTile,
      string locationName = null);

    bool isActionableTile(int xTile, int yTile, Farmer who);
    void digUpArtifactSpot(int xLocation, int yLocation, Farmer who);

    string checkForBuriedItem(
      int xLocation,
      int yLocation,
      bool explosion,
      bool detectOnly,
      Farmer who);

    void setAnimatedMapTile(
      int tileX,
      int tileY,
      int[] animationTileIndexes,
      long interval,
      string layer,
      string action,
      int whichTileSheet = 0);

    bool AllowMapModificationsInResetState();

    void setMapTile(
      int tileX,
      int tileY,
      int index,
      string layer,
      string action,
      int whichTileSheet = 0);

    void setMapTileIndex(
      int tileX,
      int tileY,
      int index,
      string layer,
      int whichTileSheet = 0);

    void shiftObjects(int dx, int dy);
    int getTileIndexAt(Point p, string layer);
    int getTileIndexAt(int x, int y, string layer);
    string getTileSheetIDAt(int x, int y, string layer);
    void OnStoneDestroyed(int indexOfStone, int x, int y, Farmer who);
    bool isBehindBush(Vector2 Tile);
    bool isBehindTree(Vector2 Tile);
    void spawnObjects();
    bool isTileLocationOpen(Location location);
    bool isTileLocationOpenIgnoreFrontLayers(Location location);
    void spawnWeedsAndStones(int numDebris = -1, bool weedsOnly = false, bool spawnFromOldWeeds = true);
    void removeEverythingExceptCharactersFromThisTile(int x, int y);
    string getFootstepSoundReplacement(string footstep);
    void removeEverythingFromThisTile(int x, int y);
    Dictionary<string, string> GetLocationEvents();
    void checkForEvents();
    Event findEventById(int id, Farmer farmerActor = null);
    void startEvent(Event evt);
    void drawBackground(SpriteBatch b);
    void drawWater(SpriteBatch b);
    void drawWaterTile(SpriteBatch b, int x, int y);
    void drawWaterTile(SpriteBatch b, int x, int y, Color color);
    void drawFloorDecorations(SpriteBatch b);
    TemporaryAnimatedSprite getTemporarySpriteByID(int id);
    bool shouldHideCharacters();
    void DrawFarmerUsernames(SpriteBatch b);
    void draw(SpriteBatch b);
    void drawAboveFrontLayer(SpriteBatch b);
    void drawLightGlows(SpriteBatch b);
    Object tryToCreateUnseenSecretNote(Farmer who);
    bool performToolAction(Tool t, int tileX, int tileY);
    void seasonUpdate(string season, bool onLoad = false);
    void updateSeasonalTileSheets(Map map = null);
    int checkEventPrecondition(string precondition);
    void updateWarps();
    void loadWeeds();
    bool CanLoadPathObjectHere(Vector2 tile);
    void loadObjects();
    void updateDoors();
    bool isTerrainFeatureAt(int x, int y);
    void loadLights();
    bool isFarmBuildingInterior();
    bool CanBeRemotedlyViewed();
    bool Equals(object obj);
    bool Equals(GameLocation other);
  }


}