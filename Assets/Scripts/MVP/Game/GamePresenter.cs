public class GamePresenter : OnFightListener
{
    private IGameView view;
    private GameModel model;
    private IShipPresenter shipPresenterA;
    private IShipPresenter shipPresenterB;

    public GamePresenter(IGameView view)
    {
        this.view = view;
        this.model = new GameModel();
        view.ShowLobby();
        view.AddOnFightListener(this);
    }

    void OnFightListener.OnFight(string[] weaponsA, string[] modulesA, string[] weaponsB, string[] modulesB)
    {
        if (weaponsA.Length > 2 || modulesA.Length > 2 || weaponsB.Length > 2 || modulesB.Length > 3)
        {
            view.ShowError("Некорректные данные.");
            return;
        }

        Ship shipA = new ShipA();
        shipA = AddModules(shipA, modulesA);
        shipA = AddWeapons(shipA, weaponsA);

        Ship shipB = new ShipB();
        shipB = AddModules(shipB, modulesB);
        shipB = AddWeapons(shipB, weaponsB);

        model.shipModelA = new ShipModel(shipA);
        model.shipModelB = new ShipModel(shipB);

        shipPresenterA = new ShipPresenter(view.CreateShipA(), model.shipModelA);
        shipPresenterB = new ShipPresenter(view.CreateShipB(), model.shipModelB);

        model.shipModelA.SetOnZeroHealthListener(() => {
            view.CloseBattle();
            view.ShowWinShipB();
        });
        model.shipModelB.SetOnZeroHealthListener(() => {
            view.CloseBattle();
            view.ShowWinShipA();
        });

        shipPresenterA.SetEnemy((Enemy)shipPresenterB);
        shipPresenterB.SetEnemy((Enemy)shipPresenterA);

        view.CloseLobby();
        view.ShowBattle();
    }

    private Ship AddWeapons(Ship ship, string[] weapons)
    {
        foreach (string weapon in weapons)
        {
            if (weapon == "A")
            {
                ship = new WeaponA(ship);
            }
            if (weapon == "B")
            {
                ship = new WeaponB(ship);
            }
            if (weapon == "C")
            {
                ship = new WeaponC(ship);
            }
        }
        return ship;
    }

    private Ship AddModules(Ship ship, string[] modules)
    {
        foreach (string module in modules)
        {
            if (module == "A")
            {
                ship = new ModuleA(ship);
            }
            if (module == "B")
            {
                ship = new ModuleB(ship);
            }
            if (module == "C")
            {
                ship = new ModuleC(ship);
            }
            if (module == "D")
            {
                ship = new ModuleD(ship);
            }
        }
        return ship;
    }

}