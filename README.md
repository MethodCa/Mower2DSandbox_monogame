# Mower2DSandbox - MonoGame
Mono2D sandbox minigame, written in C# using MonoGame Framework[^1], open-source implementation of the Microsoft XNA Framework that supports all gaming platforms.

![mowermono](https://github.com/MethodCa/Mower2DSandbox_monogame/assets/15893276/316c654b-0a90-4301-be2d-431e4c47b4a8)



The mini-game was written to test the MonoGame content pipeline, math libriary, sprite animation, sprite batching technology, texture atllas management, and game object collisions.

![mowerMonogame](https://github.com/MethodCa/Mower2DSandbox_monogame/assets/15893276/3b31a370-63f1-4ae8-844f-748d3f690ca9)


The mini-game simulates the behaviour of an electric grass mower that moves freely throughout a pre-defined grass area and collides with obstacles and area limits. When a collision is encountered the mower's direction is changed using trigonometric functions as shown in the next code snipped:

```c++
glm::vec2 calculateDirection(float angle, float velocity, float deltaTime)
{
	float radianAngle = glm::radians(angle);
	glm::vec2 direction = glm::vec2(sin(radianAngle), cos(radianAngle));
	return direction * velocity * deltaTime;
}
```

The mower has a battery that lasts 50 seconds, after the battery has depleted its charge the mower will return to its docking station to recharge for 5 seconds.

![mowertodock](https://github.com/MethodCa/Mower2DSandbox/assets/15893276/ef005b4d-ac47-4b42-9fd2-58a206fecd25)


> [!NOTE]
> Please ignore any artifacts or lower framerate in the GIF, these are products of the GIF compression, in execution the 3D model is displayed without artifacts and at 60 FPS.

[^1]: [MonoGame](https://monogame.net/) Open-source implementation of the Microsoft XNA Framework that supports all gaming platforms. 
[^2]: OpenGL Extension Wrangler Library [GLEW](https://glew.sourceforge.net/)_
[^3]: Multi-platform library for OpenGL, OpenGL ES and Vulkan development. [GLFW](https://www.glfw.org/)
[^4]: OpenGL mathematics library [GLM](ttps://glm.g-truc.net/)

