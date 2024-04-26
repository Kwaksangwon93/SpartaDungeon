


public class GameManager
{
    private Player player;
    private List<Item> inventory;
    private List<Item> store;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player = new Player("  곽상원", "어둠의 개발자", 32, 5, 10, 100, 50000);

        inventory = new List<Item>();

        store = new List<Item>();

        store.Add(new Item("낡은 창", "낡아빠진 창", ItemType.Weapon, 5, 0, 0, 500));
        store.Add(new Item("기본 창", "보편화된 창", ItemType.Weapon, 8, 0, 0, 1000));
        store.Add(new Item("좋은 창", "성능 좋은 창", ItemType.Weapon, 12, 0, 0, 1700));
        store.Add(new Item("예리한 창", "날카로운 창", ItemType.Weapon, 17, 0, 0, 2700));
        store.Add(new Item("300의 투지", "전설속의 창", ItemType.Weapon, 25, 0, 0, 4500));

        store.Add(new Item("천 갑옷", "천으로 만든 갑옷", ItemType.Armor, 0, 2, 0, 200));
        store.Add(new Item("가죽 갑옷", "가죽으로 만든 갑옷", ItemType.Armor, 0, 5, 0, 600));
        store.Add(new Item("경갑 갑옷", "경갑으로 만든 갑옷", ItemType.Armor, 0, 10, 0, 1400));
        store.Add(new Item("중갑 갑옷", "중갑으로 만든 갑옷", ItemType.Armor, 0, 15, 0, 2400));
        store.Add(new Item("300의 의지", "전설속의 갑옷", ItemType.Armor, 0, 30, 0, 5400));

        store.Add(new Item("천 신발", "천으로 만든 신발", ItemType.Shoes, 0, 0, 5, 300));
        store.Add(new Item("가죽 신발", "가죽으로 만든 신발", ItemType.Shoes, 0, 0, 10, 800));
        store.Add(new Item("경갑 부츠", "경갑으로 만든 신발", ItemType.Shoes, 0, 0, 20, 2000));
        store.Add(new Item("중갑 부츠", "중갑으로 만든 신발", ItemType.Shoes, 0, 0, 30, 3600));
        store.Add(new Item("300의 집념", "전설속의 신발", ItemType.Shoes, 0, 0, 50, 7000));
    }

    public void StartGame()
    {
        Console.Clear();
        ConsoleUtility.PrintGameHeader();
        Console.ReadLine();
        MainMenu();
    }

    private void MainMenu()
    {
        //구성
        // 0. 화면 정리
        Console.Clear();

        // 1. 선택 멘트 할당
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("  └( ◎ ω ◎)┐");
        Console.ResetColor();
        Console.WriteLine("   어서오시게 낯선 이여      ");
        Console.WriteLine("    이곳은 스파르타 던전 마을이라네     ");
        Console.WriteLine("   던전으로 가기 전에 정비를 해보게나   ");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("                                        ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("              <1.상태보기>              ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("              <2.인벤토리>              ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                <3.상점>                ");
        Console.ResetColor();
        Console.WriteLine("                                        ");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

        // 2. 선택한 결과 검증
        int choice = ConsoleUtility.PromptMenuChoice(1, 3);

        // 3. 선택한 결과에 따라 전송
        switch (choice)
        {
            case 1:
                StatusMenu();
                break;
            case 2:
                inventoryMenu();
                break;
            case 3:
                StoreMenu();
                break;

        }
        MainMenu();
    }

    private void StatusMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        ConsoleUtility.ShowTitle("  < 상 태 보 기 >");
        Console.WriteLine("  자네의 능력치가 보여진다네");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{player.Name} ({player.Job})");
        Console.ResetColor();
        ConsoleUtility.PrintTextHighlights("  레  벨 : ", player.Level.ToString("00"));
        Console.WriteLine("");

        //Todo : 능력치 강화분을 표현하도록 변경
        int bonusAtk = inventory.Select(item => item.IsEquip ? item.Atk : 0).Sum();
        int bonusDef = inventory.Select(item => item.IsEquip ? item.Def : 0).Sum();
        int bonusHp = inventory.Select(item => item.IsEquip ? item.Hp : 0).Sum();

        ConsoleUtility.PrintTextHighlights("  공격력 : ", (player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? $" (+{bonusAtk})" : "");
        ConsoleUtility.PrintTextHighlights("  방어력 : ", (player.Def + bonusDef).ToString(), bonusDef > 0 ? $" (+{bonusDef})" : "");
        ConsoleUtility.PrintTextHighlights("  체  력 : ", (player.Hp + bonusHp).ToString(), bonusHp > 0 ? $" (+{bonusHp})" : "");        

        ConsoleUtility.PrintTextHighlights("  골  드 : ", player.Gold.ToString());
        Console.WriteLine("");
        Console.WriteLine("  <0. 뒤로가기>");
        Console.WriteLine("");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

        switch (ConsoleUtility.PromptMenuChoice(0,0))
        {
             case 0:
                MainMenu();
                break;
        }
    }

    private void inventoryMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        ConsoleUtility.ShowTitle("  < 인 벤 토 리 >");
        Console.WriteLine("  자네가 가지고 있는 잡동사니일세");
        Console.WriteLine("");
        Console.WriteLine("  [아 이 템 목 록]");

        for(int i = 0; i < inventory.Count; i++)
        {
            inventory[i].PrintItemStatDescription();
        }

        Console.WriteLine("");
        Console.WriteLine("  <1. 장착관리>");
        Console.WriteLine("  <0. 뒤로가기>");
        Console.WriteLine("");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

        switch (ConsoleUtility.PromptMenuChoice(0, 1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                EquipMenu();
                break;
        }
    }

    private void EquipMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        ConsoleUtility.ShowTitle("  < 인 벤 토 리 - 장 착 관 리 >");
        Console.WriteLine("  그래 던전에 가려면 뭐라도 입어야지");
        Console.WriteLine("");
        Console.WriteLine("  [아 이 템 목 록]");
        for(int i = 0;i < inventory.Count;i++)
        {
            inventory[i].PrintItemStatDescription(true, i +1); // 나가기가 0번 고정, 나머지가 1번부터 배정
        }
        Console.WriteLine("");
        Console.WriteLine("  <0. 뒤로가기>");

        int KeyInput = ConsoleUtility.PromptMenuChoice(0, inventory.Count);

        switch (KeyInput)
        {
            case 0:
                inventoryMenu();
                break;
            default:
                inventory[KeyInput-1].ToggleEquipStatus();
                EquipMenu();
                break;
        }
    }

    private void StoreMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        ConsoleUtility.ShowTitle("  < 상 점 >");
        Console.WriteLine("  자네한테만 싸게 줄 테니 어서 골라보게");
        Console.WriteLine("");
        Console.WriteLine("  [보 유 골 드]");
        ConsoleUtility.PrintTextHighlights("", player.Gold.ToString(), " G");
        Console.WriteLine("");
        Console.WriteLine("  [아 이 템 목 록]");
        for(int i = 0; i < store.Count;i++)
        {
            store[i].PrintItemStoreDescription();
        }
        Console.WriteLine("");
        Console.WriteLine("  <1. 아이템 구매>");
        Console.WriteLine("  <0. 뒤로가기>");
        Console.WriteLine("");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        switch(ConsoleUtility.PromptMenuChoice(0,1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                PurchaseMenu();
                break;
        }
    }

    private void PurchaseMenu(string ? prompt = null)
    {
        if(prompt != null)
        {
            Console.Clear();
            ConsoleUtility.ShowTitle(prompt);
            Thread.Sleep(600);
        }

        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        ConsoleUtility.ShowTitle("  < 상 점 - 아 이 템 구 매 >");
        Console.WriteLine("  자네한테만 싸게 줄 테니 어서 골라보게");
        Console.WriteLine("");
        Console.WriteLine("  [보 유 골 드]");
        ConsoleUtility.PrintTextHighlights("", player.Gold.ToString(), " G");
        Console.WriteLine("");
        Console.WriteLine("  [아 이 템 목 록]");
        for (int i = 0; i < store.Count; i++)
        {
            store[i].PrintItemStoreDescription(true, i+1);
        }
        Console.WriteLine("");
        Console.WriteLine("  <0. 뒤로가기>");
        Console.WriteLine("");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

        int KeyInput = ConsoleUtility.PromptMenuChoice(0, store.Count);

        switch (KeyInput)
        {
            case 0:
                StoreMenu();
                break;
            default:
                // 1 : 이미 구매한 경우
                if (store[KeyInput -1].IsPurchase)
                {
                    PurchaseMenu("  그건 이미 구매하지 않았는가?");
                }
                // 2 : 돈이 충분하여 구매 가능한 경우
                else if(player.Gold >= store[KeyInput -1].Price)
                {
                    player.Gold -= store[KeyInput - 1].Price;
                    store[KeyInput - 1].Purchased();
                    inventory.Add(store[KeyInput - 1]);
                    PurchaseMenu();
                }
                // 3 : 돈이 모자라는 경우
                else
                {
                    PurchaseMenu("  그 돈으로는 택도 없다네 더 벌어오게");
                }
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}