# RPGHra2 - Marek Ondryáš

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

## Implementace

### 1. Třída `Character` (Character.cs)
- Abstraktní základní třída pro všechny postavy
- Vlastnosti: `Health`, `_currentHealth`, `_maxHealth`, `Defence`, `Level`, `XP`, `BonusDamage`
- Metoda `TakeDamage(int)` – odečte damage mínus defence, minimum 0. BonusDamage je součástí útoku hráče, ne TakeDamage
- Metoda `PridejXP(int)` – přidá XP, při dosažení prahu automaticky leveluje (každý level vyžaduje `Level * 30` XP)
- Metoda `PridejTempDamage(int)` – přidá dočasný bonus k damage (používá se pro Strength Potion)
- Metoda `ResetujTempDamage(Character)` – resetuje BonusDamage na 0, volá se na konci každého tahu
- Property `XPToNextLevel` – vypočítá se jako `Level * 30`
- Abstraktní property `Damage` – každá postava si ji implementuje jinak, vždy zahrnuje `BonusDamage`

### 2. Hratelné postavy

**Warrior** (Warrior.cs)
- HP: 100, Damage: 10, Defence: 0-10 (náhodně při startu)
- Nejodolnější postava, stabilní damage bez náhody
- `Damage` getter vrací `_damage + BonusDamage`
- **Level up volba:** +2 Damage nebo +2 Defence

**Mage** (Mage.cs)
- HP: 30, základní Damage: 5, Mana: 100
- Každý útok stojí 10 many a přidá 10 k damage (celkem 15)
- Když dojde mana postupně, útočí za zbývající manu + base damage
- Když mana = 0, útočí jen za base damage
- `BonusDamage` se zahrnuje ve všech třech větvích Damage getteru
- **Level up volba:** +2 Spell Damage nebo +30 Max Mana (mana se plně doplní)

**Archer** (Archer.cs)
- HP: 50, Damage: 8 (nebo 16 při critu)
- `_critChance` začíná na 30%, ovlivňuje výpočet critu
- Critical Hit násobí `(_damage + BonusDamage) * 2`
- **Level up volba:** +2 Damage nebo +10% Crit Chance

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
- HP: 20, Damage: 4, XP: 20-29
- Vždy útočí za 4, při 20% šanci útočí za 8 místo 4 (ne navíc)

### 4. Inventář (Inventory.cs)
- Statická třída uchovávající předměty jako `Dictionary<string, int>`
- Metoda `PridejPotion(string)` – přidá potion nebo zvýší počet
- Metoda `OdeberPotion(string)` – odebere potion, kontroluje existenci klíče a počet > 0
- Metoda `ResetInventory()` – vymaže inventář a doplní výchozí potiony (1x Strength, 1x Heal)
- Reset se volá při prohře v `Program.cs`

### 5. Soubojový systém (StartBattle.cs)
- Tahový boj ve smyčce `while (player.Health > 0 && enemy.Health > 0)`
- Hráč vybírá akci: Útok nebo Inventář (po inventáři vždy následuje útok)
- Inventář zobrazuje aktuální počty potionů, potvrzení před použitím
- `BonusDamage` ze Strength Potion se resetuje na konci každého tahu přes `ResetujTempDamage`
- Po výhře hráč dostane XP přes `PridejXP()`, při level upu si vybere bonus
- Po prohře se zobrazí ASCII Game Over obrazovka s možností hrát znovu nebo odejít
- Konstantní status bar v levém dolním rohu konzole přes `VykresliStatus()` – zobrazuje HP hráče, Bonus DMG a HP nepřítele, aktualizuje se při každém překreslení menu i po útocích

### 6. Výběr postavy (VybratHrdinu.cs)
- Dynamický seznam postav přes `List<Character>`
- Název postavy se načítá přes `GetType().Name`
- Vrací vybranou instanci postavy

### 7. UI – Interaktivní menu (VykresliMoznosti.cs)
- Ovládání šipkami nahoru/dolů + Enter
- Vybraná položka zvýrazněna bílým pozadím
- Při výběru postavy zobrazí statistiky dané třídy
- Volitelný parametr `Action statusBar` – pokud je předán, zavolá se po každém překreslení menu (používá se pro status bar v boji)
- Univerzální – používá se pro hlavní menu, souboj, výběr postavy i level up

### 8. Hlavní smyčka (Program.cs)
- Menu: Play / Choose a Character / Exit
- Hráč musí nejdřív vybrat postavu, pak teprve může hrát
- Po výběru dveří se spawnuje nepřítel (Bat = slabší, Orc = silnější) a spustí boj
- Po prohře se hrdina resetuje na null a inventář se obnoví přes `ResetInventory()`

---