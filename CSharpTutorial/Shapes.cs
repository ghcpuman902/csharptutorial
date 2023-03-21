using System;
namespace Shapes
{

		/*
		 * <summary>
		 * Class <c>Shape</c> （形狀）是一個抽象的Class。
		 * 它需要被更具象的Class繼承，如正方形、長方形、圓形、三角形等。 
		 * </summary>
		 */
		abstract class Shape
		{
			protected const float PI = 3.1415926f;

			public abstract float GetArea();

			public virtual float GetEdgeLength()    //virtual -> 告訴繼承者我雖然已經實作了，你還是可以override。你可以刪掉試試看。
			{
				return 1f;
			}

			public override string ToString()       // override -> 複寫從“Object”繼承來的ToString（預設所有人都繼承Object，所以都會有ToString）；
			{
				return $"形狀: 面積={this.GetArea()} 邊長={this.GetEdgeLength()}";
				// C# 6 的新功能，叫Interpolated Strings。相比string.Format()或者加號可讀性更好，也更不容易出錯。
				// 見 https://stackoverflow.com/questions/32878549/whats-with-the-dollar-sign-string
			}

		}


		/*
		 * <summary>
		 * Class <c>Square</c> （正方形）繼承 <c>Shape</c> 。
		 * 它四個邊一樣，所以可以通過邊長定義。 
		 * </summary>
		 * <param name="n"></param>
		 */
		class Square : Shape
		{
			private readonly float side;



			/////////////////////////////////////////////////////
			//public Square(float n)
			//{
			//	side = n; // Constructor<param name="n"></param>
			//}
			////////////// 上面這段代碼和下面這一行一樣 //////////////
			public Square(float n) => side = n; // Constructor 


			public override float GetArea() => side * side; // 因為繼承的Shape要求一定要有，所以沒有會報錯。


			/////////////////////////////////////////////////////
			//public override float GetEdgeLength()
			//{
			//	return side * 4;
			//}
			////////////// 上面這段代碼和下面這一行一樣 //////////////
			public override float GetEdgeLength() => side * 4;

			//因為ToString()是virtual，所以可以overwrite也可以不overwrite

		}


		/*
		 * <summary>
		 * Class <c>Rectangle</c> （長方形）繼承 <c>Shape</c> 。
		 * 它兩個邊各自一樣，所以可以通過兩個邊長定義。 
		 * </summary>
		 */
		class Rectangle : Shape
		{
			private readonly float sideA;
			private readonly float sideB;

			// 這個就沒辦法用 “=>”，自己想為什麼。
			public Rectangle(float a, float b)
			{
				sideA = a;
				sideB = b;
			}

			public override float GetArea() => sideA * sideB;
			public override float GetEdgeLength() => (sideA + sideB) * 2;
			public float GetWidth() => sideA >= sideB ? sideA : sideB;
			public float GetHeight() => sideA < sideB ? sideA : sideB;

			public override string ToString() => $"長方形: 面積 = {this.GetArea()} 邊長={this.GetEdgeLength()} 寬={this.GetWidth()} 高={this.GetHeight()} ";

		}


		class Circle : Shape
		{
			private readonly float radius;

			public Circle(float r)
			{
				radius = r;
			}

			public override float GetArea() => PI * radius * radius;
			public override float GetEdgeLength() => PI * radius;

			public override string ToString() => $"圓形: 面積 = {this.GetArea()} 邊長={this.GetEdgeLength()}";

		}


		//static void Main()
		//{
		//	var sq = new Square(12);

		//	var rect = new Rectangle(4, 5);

		//	var circ = new Circle(6);

		//	Console.WriteLine($"我有三個形狀，\n{sq}\n{rect}\n{circ}。");
		//	//可以試試看把class Shape裡面，ToString前面的 "overwride" 改成 "virtual new", 看這裡印出來的東西有什麼不同。
		//}

}