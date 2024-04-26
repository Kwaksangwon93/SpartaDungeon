



public enum ItemType
{
    Weapon,
    Armor,
    Shoes
}

internal class Item
{
    public string Name { get; }
    public string Desc { get; }
    
    private ItemType Type;

    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }

    public int Price { get; }

    public bool IsEquip { get; private set;  }
    public bool IsPurchase { get; private set; }

    public Item(string name, string desc, ItemType type, int atk, int def, int hp, int price, bool isEquip =  false, bool IsPurchase = false)
    {
        Name = name;
        Desc = desc;
        Type = type;
        Atk = atk;
        Def = def;
        Hp = hp;
        Price = price;
        IsEquip = isEquip;
        IsPurchase = IsPurchase;
    }

    // 아이템 정보를 보여줄 때 타입이 비슷한 게 2가지
    // 1. 인벤토리에서 가지고 있는 아이템
    // 2. 장착관리에서 낄지 말지 결정할 아이템
    internal void PrintItemStatDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("  - ");
        if(withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx} ");
            Console.ResetColor();
        }
        if(IsEquip)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("]");
            Console.ResetColor();
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 9));
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));

        Console.Write(" | ");

        if(Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk}");
        if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def}");
        if (Hp != 0) Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{Hp}");

        Console.Write(" | ");
        Console.WriteLine(Desc);
    }

    internal void ToggleEquipStatus()
    {
        IsEquip = !IsEquip;
    }

    internal void PrintItemStoreDescription(bool withNumber = false, int idx = 0)
    {
        Console.Write("  - ");
        if (withNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0} ", idx);
            Console.ResetColor();
        }
        else Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));

        Console.Write(" | ");

        if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk}");
        if (Def != 0) Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def}");
        if (Hp != 0) Console.Write($"체  력 {(Hp >= 0 ? "+" : "")}{Hp}");

        Console.Write(" | ");
        Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 14));
        Console.Write(" | ");

        if(IsPurchase)
        {
            Console.WriteLine("구매완료");
        }
        else
        {
            ConsoleUtility.PrintTextHighlights("", Price.ToString(), " G");
        }
    }

    internal void Purchased()
    {
        IsPurchase = true;
    }
}