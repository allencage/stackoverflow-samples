using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			IFoo iFoo = GetIFoo();
			if(iFoo is Foo)
			{
				Console.WriteLine($"foo is of type Foo + {iFoo.GetType()}");
			}
			Console.Read();
		}

		static IFoo GetIFoo()
		{
			var bar = new Bar
			{
				Name = "MyName",
				Surname = "MySurname"
			};
			return bar;
		}
	}

	public class Foo : IFoo
	{
		public string Name { get; set; }
	}

	public class Bar : Foo
	{
		public string Surname { get; set; }
	}

	public interface IFoo
	{

	}
}
