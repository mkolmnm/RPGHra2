README.md


# RPGHra2 – Dokumentace projektu

## Popis projektu
Konzolová RPG hra v C# kde si hráč vybere postavu a bojuje s nepřáteli v dungeonu.
Hra využívá objektově orientované programování – dědičnost, abstraktní třídy a polymorfismus.

---

## Architektura projektu

### Dědičnost
Character (abstraktní)
├── Warrior
├── Mage
├── Archer
└── Enemy (abstraktní)
	├── Bat
	├── Orc
	└── Zombie

---

## Implementace:

### 1. Třída `Character` (Character.cs)
- Abstraktní základní třída pro všechny postavy
- Vlastnosti: `Health`, `currentHealth`, `_maxHealth`, `Defence`, `Level`, `XP`
- Metoda `TakeDamage(int)` – odečte damage mínus defence, minimum 0
- Metoda `PridejXP(int)` – přidá XP, při dosažení prahu automaticky leveluje
- Property `XPToNextLevel` – vypočítá se jako `Level * 30`
- Abstraktní property `Damage` – každá postava si ji implementuje jinak

### 2. Hratelné postavy

**Warrior** (Warrior.cs)
- HP: 100, Damage: 10, Defence: 10
- Nejodolnější postava, stabilní damage bez náhody

**Mage** (Mage.cs)
- HP: 30, základní Damage: 5, Mana: 100
- Každý útok stojí 10 many a přidá 10 k damage (celkem 15)
- Když dojde mana, útočí jen za 5
- Nejslabší HP ale nejvyšší burst damage

**Archer** (Archer.cs)
- HP: 50, Damage: 8 (nebo 16 při critu)
- 30% šance na Critical Hit – dvojnásobný damage
- Používá `Random` pro výpočet critu

### 3. Nepřátelé

**Enemy** (Enemy.cs)
- Abstraktní třída dědící z `Character`
- Přidává `EnemyName`, `ExperiencePoints`
- Abstraktní metoda `EnemyAtack(Character target)`

**Bat** (bat.cs)
- HP: 8, Damage: 4, XP: 10-14
- 50% šance že vůbec zaútočí – nejslabší nepřítel

**Orc** (Orc.cs)
- HP: 50, Damage: 8, XP: 40-54
- Vždy útočí, nejsilnější nepřítel

**Zombie** (Zombie.cs)
- HP: 20, XP: 20-29
- Vždy útočí za 4, 20% šance na útok za 8 navíc

### 4. Soubojový systém (StartBattle.cs)
- Tahový boj ve smyčce `while (player.Health > 0 && enemy.Health > 0)`
- Hráč vidí HP obou stran a vybírá akci (Útok / Útěk)
- Po hráčově útoku nepřítel automaticky útočí
- Po výhře hráč dostane XP přes `PridejXP()`
- Po prohře se zobrazí ASCII Game Over obrazovka
- Možnost hrát znovu (reset hrdiny) nebo odejít

### 5. Výběr postavy (VybratHrdinu.cs)
- Dynamický seznam postav přes `List<Character>`
- Název postavy se načítá přes `GetType().Name` – není hardcoded
- Vrací vybranou instanci postavy

### 6. UI – Interaktivní menu (VykresliMoznosti.cs)
- Ovládání šipkami nahoru/dolů + Enter
- Vybraná položka zvýrazněna bílým pozadím
- Při výběru postavy zobrazí statistiky dané třídy
- Univerzální – používá se pro hlavní menu, souboj i výběr postavy

### 7. Hlavní smyčka (Program.cs)
- Menu: Play / Choose a Character / Exit
- Hráč musí nejdřív vybrat postavu, pak teprve může hrát
- Po výběru dveří se spawnuje nepřítel a spustí boj
- Po Game Over se hrdina resetuje na null
