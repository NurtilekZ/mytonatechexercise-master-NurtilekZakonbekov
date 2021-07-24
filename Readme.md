# mytonatechexercise-master
 Tech exersice
 
#### 1. Fixed PowerUps dropping bugs:
-  Rewrote Randomized Dropping algorith according to PowerUp's weights.
-  If weapons is already equipped, it will not drop as PowerUp.
#### 2. Fixed Replay after Game Over or Win.
#### 3. Added Destroy() to Mobs after 2f in Death() method.
#### 4. Added new weapons: 
-  Granade 
-  Rocket Launcher
-  Sword
-  Bat
#### 5. Added new Mobs: 
-  Mage
-  Kamikaze
-  Granadier
#### 6. Added AttackSignal Sprite that appears before Mob's attack and disappears after.
#### 7. Added Text notify about taken damage and healing values
#### 8. Fixed Boss Behavior, now it's attacks if Player is inside the AttackDistance. 
#### 9. Added Health UI to Boss  
#### 10. Changed OnHPChange Action in Mob and Player to event to make it to be called only inside it's own class.
#### 11. Changed public access modificators to private and protected with [SerializeField] where it was nessessary.
#### 12. Added Custom Editor inspedtor for LevelData ScriptableObject
