using Rainfall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameState : State
{
	public static GameState instance { get; private set; }


	Scene scene;

	Model cube;
	DirectionalLight sun;


	public GameState()
	{
		instance = this;
	}

	public override void init()
	{
		scene = new Scene();

		cube = Resource.GetModel("res/rainfall/cube.gltf");
		sun = new DirectionalLight(new Vector3(-1, -1, 1).normalized, Vector3.One * 3, Renderer.graphics);

		scene.addEntity(new FreeCamera(), new Vector3(3, 3, 3));
	}

	public override void destroy()
	{
		scene.destroy();
	}

	public override void update()
	{
		scene.update();
	}

	public override void draw(GraphicsDevice graphics)
	{
		scene.draw(graphics);

		Renderer.DrawDirectionalLight(sun);
		Renderer.DrawModel(cube, Matrix.Identity);
	}
}
