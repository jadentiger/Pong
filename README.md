# Pong
## Description:

This is a simple classic game Pong using C# Windows Forms. The game features a player-controlled paddle and a computer-controlled paddle, with the objective of bouncing a ball past the opponent's paddle to score points.

# Flowchart for Pong Game

---

**Start**

1. Initialize components
2. Subscribe to KeyDown and KeyUp events
3. Start background music

**Game Loop:**

4. Move ball
5. Check if ball hits top or bottom boundaries
6. Check if ball goes out of left boundary
    - Increment player score if true
7. Check if ball goes out of right boundary
    - Increment computer score if true
8. Ensure computer paddle stays within boundaries
9. Move computer paddle based on ball position
10. Decrease speed change timer
11. Change computer paddle speed randomly
12. Move player paddle based on user input
13. Check collision between ball and player paddle
14. Check collision between ball and computer paddle
15. Check if player or computer score reaches winning score
    - If true, proceed to "Game Over"

**Game Over:**

16. Play score sound
17. Stop game timer
18. Show game over message
19. Reset scores, ball speed, and timer
20. Restart background music

**End**

---

## Features:

Control your paddle with the arrow keys while the computer controls the opponent's paddle.
Score tracking: Keep track of player and computer scores displayed on the game window title.
Randomized ball and computervmovements: The ball's speed and direction change randomly upon collision with paddles and so does the computer's reaction speed.
Sound effects: Enjoy chime sound effects for scoring points and background music during gameplay.

## How to Play:

Use the up and down arrow keys to move your paddle up and down, respectively.
The game ends when one player reaches a score of 5.
A message box appears announcing the winner, and the game restarts automatically.

## Customization:

Additionally you can add more features to your game such as power-ups, walls or other mechanics that make the game more engaging. Sound effects are also something else and fairly easy to add. If I would have had more time, I would have added different difficulty levels for the computer you play against.