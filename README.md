# Mower2DSandbox - MonoGame
Mono2D sandbox minigame, written in C# using MonoGame Framework[^1], open-source implementation of the Microsoft XNA Framework that supports all gaming platforms.

![mowermono](https://github.com/MethodCa/Mower2DSandbox_monogame/assets/15893276/316c654b-0a90-4301-be2d-431e4c47b4a8)



The mini-game was written to test the MonoGame content pipeline, math libriary, sprite animation, sprite batching technology, texture atllas management, and game object collisions.

![mowerMonogame](https://github.com/MethodCa/Mower2DSandbox_monogame/assets/15893276/3b31a370-63f1-4ae8-844f-748d3f690ca9)


The mini-game simulates the behaviour of an electric grass mower that moves freely throughout a pre-defined grass area and collides with obstacles and area limits. When a collision is encountered the mower's direction is changed using trigonometric functions as shown in the next code snipped:

```c#
 public Vector2 calculateDirection(float angle, float velocity, float deltaTime)
 {
     float radianAngle = MathHelper.ToRadians(angle);
     Vector2 direction = new Vector2((float)Math.Sin(radianAngle), (float)Math.Cos(radianAngle));
     return direction * velocity * deltaTime;
 }
```
Original pixel art and animations were created in Aseprite[^2] to test a custom [Sprite animation](https://github.com/MethodCa/Mower2DSandbox_monogame/blob/9e6a44e7e2c2da5c1b81547d2832c1b1b772f954/MowerApp.cs#L9C5-L135C6) class written for the project.


![atlas](https://github.com/MethodCa/Mower2DSandbox_monogame/assets/15893276/78b00c86-7ddb-4fb9-9b1b-9eff8046eed5)


> [!NOTE]
> Please ignore any artifacts or lower framerate in the GIF, these are products of the GIF compression, in execution the game is displayed without artifacts and at 60 FPS.

[^1]: [MonoGame](https://monogame.net/) Open-source implementation of the Microsoft XNA Framework that supports all gaming platforms. 
[^2]: [Aseprite]([https://monogame.net/](https://www.aseprite.org/)) Animated sprite editor and pixel art tool.


