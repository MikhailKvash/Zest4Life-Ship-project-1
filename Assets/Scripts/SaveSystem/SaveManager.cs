using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private OilTower oilTower;
    [SerializeField] private MainBuilding mainBuilding;
    [SerializeField] private OilVillager oilVillager;
    [SerializeField] private ShipVillager shipVillager;
    [SerializeField] private ShipMovement ship;
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private UpgradeMenu upgradeMenu;
    [SerializeField] private TimeManager timeManager;
    
    public void SaveProgress()
    {
        SaveSystem.SaveStorage(storage);
        SaveSystem.SaveOilTower(oilTower);
        SaveSystem.SaveMainBuilding(mainBuilding);
        SaveSystem.SaveOilVillager(oilVillager);
        SaveSystem.SaveShipVillager(shipVillager);
        SaveSystem.SaveShip(ship);
        SaveSystem.SaveTradeMenu(tradeMenu);
        SaveSystem.SaveUpgradeMenu(upgradeMenu);
        SaveSystem.SaveTimeManager(timeManager);
    }

    public void LoadProgress()
    {
        StorageData storageData = SaveSystem.LoadStorage();
        OilTowerData oilTowerData = SaveSystem.LoadOilTower();
        MainBuildingData mainBuildingData = SaveSystem.LoadMainBuilding();
        OilVillagerData oilVillagerData = SaveSystem.LoadOilVillager();
        ShipVillagerData shipVillagerData = SaveSystem.LoadShipVillager();
        ShipData shipData = SaveSystem.LoadShip();
        TradeMenuData tradeMenuData = SaveSystem.LoadTradeMenu();
        UpgradeMenuData upgradeMenuData = SaveSystem.LoadUpgradeMenu();
        TimeManagerData timeManagerData = SaveSystem.LoadTimeManager();
        

        storage.Oil = storageData.oil;
        storage.Fuel = storageData.fuel;
        storage.Stone = storageData.stone;
        storage.Wood = storageData.wood;
        storage.Gems = storageData.gems;
        storage.Coins = storageData.coins;
        storage.Capacity = storageData.capacity;

        oilTower.Oil = oilTowerData.oil;
        oilTower.Capacity = oilTowerData.capacity;
        oilTower.Level = oilTowerData.level;
        
        mainBuilding.Level = mainBuildingData.level;

        oilVillager.CarryingOil = oilVillagerData.carryingOil;
        oilVillager.Speed = oilVillagerData.speed;
        oilVillager.Capacity = oilVillagerData.capacity;
        oilVillager.TakeOilOnce = oilVillagerData.takeOilOnce;
        oilVillager.DropOilOnce = oilVillagerData.dropOilOnce;
        Vector3 oilVillagerPosition;
        oilVillagerPosition.x = oilVillagerData.position[0];
        oilVillagerPosition.y = oilVillagerData.position[1];
        oilVillagerPosition.z = oilVillagerData.position[2];
        oilVillager.transform.position = oilVillagerPosition;

        shipVillager.SingleDelivery = shipVillagerData.singleDelivery;

        ship.WaypointIndex = shipData.waypointIndex;
        ship.SingleDelivery = shipData.singleDelivery;
        Vector3 shipPosition;
        shipPosition.x = shipData.position[0];
        shipPosition.y = shipData.position[1];
        shipPosition.z = shipData.position[2];
        ship.transform.position = shipPosition;

        tradeMenu.OilAmount = tradeMenuData.oil;
        tradeMenu.ProfitCoins = tradeMenuData.coins;
        tradeMenu.ShipAway = tradeMenuData.shipAway;

        upgradeMenu.OilLevelValue = upgradeMenuData.oilLevelValue;
        upgradeMenu.OilCapacityValue = upgradeMenuData.oilCapacityValue;
        upgradeMenu.CarrierSpeedValue = upgradeMenuData.carrierSpeedValue;
        upgradeMenu.CarrierCapacityValue = upgradeMenuData.carrierCapacityValue;
        upgradeMenu.StorageCapacityValue = upgradeMenuData.storageCapacityValue;
        upgradeMenu.MainBuildingLevelValue = upgradeMenuData.mainBuildingLevelValue;

        timeManager.TimeLeft = timeManagerData.timeLeft;
        timeManager.TakingAway = timeManagerData.takingAway;
    }
}
