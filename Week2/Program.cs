namespace Week2
{
    internal class Program
    {
        // 아이템 클래스
        // - 아이템 타입(string type), 아이템 이름(string name), 아이템 장착 여부(bool equip)
        // - 추가 공격력(int ap), 추가 방어력(int dp), 추가 체력(int hp), 아이템 가격(int gold), 설명(string description)
        class Item
        {
            private string type;
            private string name;
            private bool equip;
            private int ap {  get; set; }
            private int dp {  get; set; }
            private int hp {  get; set; }
            private int gold;
            private string description;
            private bool isBuy;
            

            public Item(string type, string name, int ap, int dp, int hp, int gold, string description)
            {
                this.type = type;
                this.name = name;
                this.equip = false;
                this.ap = ap;
                this.dp = dp;
                this.hp = hp;
                this.gold = gold;
                this.description = description;
                this.isBuy = false;
            }

            public bool GetIsBuy()
            {
                return this.isBuy;
            }

            public void ToggleIsBuy(Character character)
            {
                if(this.isBuy == true)
                {
                    this.isBuy = false;
                }
                else if(this.isBuy == false)
                {
                    if (character.GetGold() >= this.gold)
                    {
                        this.isBuy = true;
                        character.ItemToInv(this);
                        Console.WriteLine("구매 완료!");
                        character.UseGold(this.gold);
                    }
                    else if(character.GetGold() < this.gold)
                    {
                        Console.WriteLine("Gold 가 부족합니다...");
                    }
                    
                }
            }

            public bool GetEquipState()
            {
                return this.equip;
            }

            public void ToggleEquipState(Character character)
            {
                if (this.equip == true)
                {
                    this.equip = false;
                    this.UnequipItem(character);
                }
                else if (this.equip == false)
                {
                    this.equip = true;
                    this.EquipItem(character);
                }
            }

            public void PrintItemShop()
            {
                Console.Write("- ");
                Console.Write(this.name);
                Console.Write("\t| ");
                if (this.ap != 0)
                {
                    Console.Write("공격력 + {0}", this.ap);
                    Console.Write("\t| ");
                }
                if (this.dp != 0)
                {
                    Console.Write("방어력 + {0}", this.dp);
                    Console.Write("\t| ");
                }
                if (this.hp != 0)
                {
                    Console.Write("체력 + {0}", this.hp);
                    Console.Write("\t| ");
                }
                Console.Write("{0}\t| " ,this.description);
                if (this.isBuy != true)
                {
                    Console.WriteLine("{0} G", this.gold);
                }
                else if(this.isBuy == true)
                {
                    Console.WriteLine("구매완료");
                }
            }

            public void PrintItemInv()
            {
                Console.Write("- ");
                if (this.equip == true)
                {
                    Console.Write("[E]");
                }
                Console.Write(this.name);
                Console.Write("\t| ");
                if (this.ap != 0)
                {
                    Console.Write("공격력 + {0}", this.ap);
                    Console.Write("\t| ");
                }
                if (this.dp != 0)
                {
                    Console.Write("방어력 + {0}", this.dp);
                    Console.Write("\t| ");
                }
                if (this.hp != 0)
                {
                    Console.Write("체력 + {0}", this.hp);
                    Console.Write("\t| ");
                }
                Console.WriteLine(this.description);
            }



            public void EquipItem(Character character)
            {
                if (this.ap != 0)
                {
                    character.EquipItemAp(this.ap);
                }
                if(this.dp != 0)
                {
                    character.EquipItemDp(this.dp);
                }
                if(this.hp != 0)
                {
                    character.EquipItemHp(this.hp);
                }
            }
            public void UnequipItem(Character character)
            {
                if (this.ap != 0)
                {
                    character.UnequipItemAp(this.ap);
                }
                if (this.dp != 0)
                {
                    character.UnequipItemDp(this.dp);
                }
                if (this.hp != 0)
                {
                    character.UnequipItemHp(this.hp);
                }
            }
        }

        // 캐릭터 클래스
        // - 레벨(level), 이름(name), 직업(job), 공격력(ap), 방어력(dp), 체력(hp), Gold, 인벤토리(아이템 시퀀스)
        // - 상태 보기 메서드
        // - 인벤토리 메서드
        // - 아이템 장착 메서드

        class Character
        {
            private int level {  get; set; }
            private string name {  get; set; }
            private string job { get; set; }
            private int ap {  get; set; }
            private int dp {  get; set; }
            private int hp {  get; set; }
            private int gold {  get; set; }
            private List<Item> inventory;
            private int itemAp;
            private int itemDp;
            private int itemHp;
            private List<Item> shop;

            public Character(string name, string job)
            {
                this.level = 1;
                this.name = name;
                this.job = job;
                this.ap = 10;
                this.dp = 5;
                this.hp = 100;
                this.gold = 1500;
                this.inventory = new List<Item>();
                this.itemAp = 0;
                this.itemDp = 0;
                this.itemHp = 0;
                this.shop = new List<Item>();
            }

            public void EquipItemAp(int ap)
            {
                this.itemAp += ap;
            }
            public void UnequipItemAp(int ap)
            {
                this.itemAp -= ap;
            }
            public void EquipItemDp(int dp)
            {
                this.itemDp += dp;
            }
            public void UnequipItemDp(int dp)
            {
                this.itemDp -= dp;
            }
            public void EquipItemHp(int hp)
            {
                this.itemHp += hp;
            }
            public void UnequipItemHp(int hp)
            {
                this.itemHp -= hp;
            }



            public void Cheat()
            {
                this.gold += 10000;
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                while (true)
                {
                    Console.Write(">> ");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "0":
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 나가려면 0을 입력하세요.");
                            break;

                    }
                }
            }

            public void Status()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("상태 보기");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("닉네임 : {0}", this.name);
                Console.WriteLine("Lv. {0}", this.level);
                Console.WriteLine("직업 : {0}", this.job);
                Console.Write("공격력 : {0}", this.ap + this.itemAp);
                if(this.itemAp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemAp);
                }
                else if(this.itemAp == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("방어력 : {0}", this.dp + this.itemDp);
                if (this.itemDp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemDp);
                }
                else if (this.itemDp == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("체력 : {0}", this.hp + this.itemHp);
                if (this.itemHp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemHp);
                }
                else if (this.itemHp == 0)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("골드 : {0}", this.gold);
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                while (true)
                {
                    Console.Write(">> ");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "0":
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 나가려면 0을 입력하세요.");
                            break;

                    }
                }
            }

            public void Inventory()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("인벤토리");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                this.PrintInv();
                Console.WriteLine();

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                while (true)
                {
                    Console.Write(">> ");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "0":
                            return;
                        case "1":
                            while (true)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("인벤토리 - 장착 관리");
                                Console.ForegroundColor = ConsoleColor.White;
                                if (inventory == null)
                                {
                                    Console.WriteLine("아이템이 없습니다.");
                                    Thread.Sleep(500);
                                    break;
                                }
                                else
                                {

                                    this.PrintEquip();
                                    Console.WriteLine();
                                    Console.WriteLine("0. 나가기");
                                    Console.WriteLine();
                                    Console.WriteLine("원하시는 항목을 입력해주세요.");
                                    Console.Write(">> ");
                                    string num2 = Console.ReadLine();
                                    switch (num2)
                                    {
                                        case "0":
                                            return;
                                        default:

                                            int index = int.Parse(num2);
                                            if (index <= inventory.Count)
                                            {
                                                bool temp = inventory[index - 1].GetEquipState();
                                                inventory[index - 1].ToggleEquipState(this);
                                                if (temp == false)
                                                {
                                                    Console.WriteLine("장착 되었습니다.");
                                                }
                                                else if(temp == true)
                                                {
                                                    Console.WriteLine("해제 되었습니다.");
                                                }
                                                Thread.Sleep(500);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("잘못된 입력입니다.");
                                                Thread.Sleep(500);
                                                break;
                                            }
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 나가려면 0을 입력하세요.");
                            break;

                    }
                }
            }

            public void Shop()
            {
                while (true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("상점");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("필요한 아이템을 구매할 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine("{0} G", this.gold);
                    Console.WriteLine();
                    Console.WriteLine("[아이템 목록]");
                    this.PrintShop();
                    Console.WriteLine();
                    Console.WriteLine("1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "1":
                            while (true)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("상점 - 아이템 구매");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("필요한 아이템을 구매할 수 있는 상점입니다.");
                                Console.WriteLine();
                                Console.WriteLine("[보유 골드]");
                                Console.WriteLine("{0} G", this.gold);
                                Console.WriteLine();
                                Console.WriteLine("[아이템 목록]");
                                this.PrintBuy();
                                Console.WriteLine();
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.WriteLine("원하시는 항목을 입력해주세요.");
                                Console.Write(">> ");
                                string num2 = Console.ReadLine();
                                int index = int.Parse(num2);
                                if (index <= shop.Count && index != 0)
                                {
                                    bool temp = shop[index - 1].GetIsBuy();
                                    if (temp == false)
                                    {
                                        shop[index - 1].ToggleIsBuy(this);
                                    }
                                    else if (temp == true)
                                    {
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                    }
                                    Thread.Sleep(500);
                                    break;
                                }
                                else if (index == 0)
                                {
                                    Console.WriteLine("상점메뉴로 돌아갑니다.");
                                    Thread.Sleep(500);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                    Thread.Sleep(500);
                                }
                            }
                            break;
                            
                        case "0":
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }
                    
                    
                }
            }

            public void PrintShop()
            {
                if (shop != null)
                {
                    for (int i = 0; i < shop.Count; i++)
                    {
                        shop[i].PrintItemShop();
                    }

                }
            }
            public void PrintBuy()
            {
                if (shop != null)
                {
                    for (int i = 0; i < shop.Count; i++)
                    {
                        Console.Write("{0}. ", i + 1);
                        shop[i].PrintItemShop();
                    }

                }
            }

            public void PrintInv()
            {
                if (inventory != null)
                {
                    for(int i = 0; i< inventory.Count; i++)
                    {
                        inventory[i].PrintItemInv();
                    }
                    
                }
            }
            public void PrintEquip()
            {
                if (inventory != null)
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.Write("{0}. ", i + 1);
                        inventory[i].PrintItemInv();
                    }

                }
            }

            public void UseGold(int gold)
            {
                this.gold -= gold;
            }

            public void GainGold(int gold)
            {
                this.gold += gold;
            }

            public int GetGold()
            {
                return this.gold;
            }

            public void ItemToInv(Item item)
            {
                this.inventory.Add(item);
            }

            public void Init()
            {
                Item item1 = new Item("무기", "목검", 2, 0, 0, 500, "나뭇가지를 깎아 만든 목검");
                this.shop.Add(item1);
                Item item2 = new Item("무기", "의천세검", 10, 0, 0, 1500, "모든 것을 꿰뚫는 얇은 검");
                this.shop.Add(item2);
                Item item3 = new Item("무기", "청룡언월도", 30, 10, 10, 10000, "관우가 사용했다고 전해지는 전설의 보검");
                this.shop.Add(item3);
                Item item4 = new Item("전신갑옷", "천 갑옷", 0, 0, 10, 1000, "천을 여러 겹 겹쳐 만든 갑옷입니다.");
                this.shop.Add(item4);
                Item item5 = new Item("전신갑옷", "전투용 혁대", 5, 10, 0, 3000, "경량화 하여 공격에 특화된 허리띠");
                this.shop.Add(item5);
                Item item6 = new Item("전신갑옷", "어린갑", 0, 10, 5, 3000, "금속 조각을 물고기 비늘처럼 엮어 만든 갑옷");
                this.shop.Add(item6);
                Item item7 = new Item("전신갑옷", "판금 갑옷", 0, 15, 0, 3000, "판금으로 몸 전체를 덮는 갑옷");
                this.shop.Add(item7);
                Item item8 = new Item("투구", "스파르타의 투구", 0, 30, 30, 5000, "스파르타의 전사들이 사용했다는 전설의 투구");
                this.shop.Add(item8);
                Item item9 = new Item("투구", "아르테미스의 월광모", 15, 10, 10, 5000, "아르테미스로부터 전해졌다는 전설의 투구");
                this.shop.Add(item9);
                Item item10 = new Item("투구", "장비의 투구", 0, 45, 15, 5000, "장비가 착용했다고 전해지는 투구");
                this.shop.Add(item10);
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("닉네임을 입력하세요 : ");
            string name = Console.ReadLine();
            Character character = new Character(name, "전사");
            character.Init();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("0. 게임 종료");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                string remote = Console.ReadLine();

                switch (remote)
                {
                    case "1":
                        character.Status();
                        break;
                    case "2":
                        character.Inventory();
                        break;
                    case "3":
                        character.Shop();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                    case "showmethemoney":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("치트 사용!! 골드를 10000 얻습니다.");
                        Console.ForegroundColor = ConsoleColor.White;
                        character.Cheat();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;

                }
            }
        }
    }
}
