# PacGhost_v1
A variation of the classic PacMan game. 

![image](https://user-images.githubusercontent.com/65459827/123516055-cb744800-d6cc-11eb-855e-e4bfc3e20ba6.png)
![image](https://user-images.githubusercontent.com/65459827/123515830-b0ed9f00-d6cb-11eb-875a-4d1479e54dec.png)
![image](https://user-images.githubusercontent.com/65459827/123543949-8bbc6780-d783-11eb-804f-435f30a9576a.png)
![image](https://user-images.githubusercontent.com/65459827/123543973-a393eb80-d783-11eb-92c1-1fb226a54c43.png)

## Enemy specifications ** 
Real enemies can pass through maze walls. Player dies upon collision with real enemies.
Fake enemies cannot pass through maze walls. Player does not die upon collision with fake enemies. (Player can push fake enemies around.)

## Scoring system
White coins: 1 point each. 
Blue coins: 3 points each
Total possible points/Points required to win game: 300

### Bugs **
Invisible walls might appear at random axes (a horizontal or vertical strip across the scene) which causes the player to be unable to move beyond a certain x(horizontal) or y(vertical) direction after a certain point. 
Invisible walls which form tend to disappear on their own after a while. 
Cause of invisible walls is presently unknown. 
### Current solution: Player to walk around the areas of the maze further from the side where the invisible walls seem to appear, and periodically try different paths to get to the original intended destination/coins after a while.


### Additional details
Player only has 1 life.
Option to restart or quit game available after Player dies, or in-game.
Fake Enemies and Real Enemies are deliberately set to be the same sprite for additional challenge.


